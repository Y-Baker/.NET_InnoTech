namespace StudentAffairs;
public interface IEmailService
{
    Task SendSurvey(SurveyData survey);
    Task SendEmail(string toEmail, string subject, string body);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ICourseService _service;

    public EmailService(IConfiguration configuration, ICourseService service)
    {
        _configuration = configuration;
        _service = service;
    }

    public async Task SendSurvey(SurveyData survey)

    {
        Course course = await _service.GetCourse(survey.CourseId);
        Doctor doctor = await _service.GetInstructor(course);

        string emailContent = await FormatSurveyEmail(survey);

        string? instructorEmail = doctor.Email;
        if (instructorEmail is not null)
        {
            await SendEmail(instructorEmail, "New Survey Submission", emailContent);
        }
        List<string> adminEmails = _configuration.GetSection("Admins").Get<List<string>>() ?? new();
        foreach (string adminEmail in adminEmails)
        {
            await SendEmail(adminEmail, "New Survey Submission", emailContent);
        }

        Console.WriteLine("Survey saved and emails sent successfully.");
    }
    public async Task SendEmail(string toEmail, string subject, string body)
    {
        SmtpClient? smtpClient = new SmtpClient(_configuration["Smtp:Host"])
        {
            Port = int.Parse(_configuration["Smtp:Port"] ?? "587"),
            Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
            EnableSsl = true,
        };

        MailMessage? mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["Smtp:FromEmail"]!),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);
        await smtpClient.SendMailAsync(mailMessage);
    }

    private async Task<string> FormatSurveyEmail(SurveyData survey)
    {
        Course course = await _service.GetCourse(survey.CourseId);
        Doctor doctor = await _service.GetInstructor(course);

        return $@"
        <h2>New Survey Submission</h2>
        <p><strong>Academic Year:</strong> {survey.AcademicYear}</p>
        <p><strong>Semester:</strong> {survey.Semester}</p>
        <p><strong>Course:</strong> {course.Name}</p>
        <p><strong>Instructor:</strong> {doctor.Name}</p>
        <hr/>
        <h3>Survey Ratings</h3>
        <p><strong>Content Update Rating:</strong> {survey.ContentUpdateRating}/10</p>
        <p><strong>Expectation Rating:</strong> {survey.ExpectationRating}/10</p>
        <p><strong>Lab Rating:</strong> {survey.LapRating}/10</p>
        <p><strong>Instructor Rating:</strong> {survey.InstructorRation}/10</p>
        <p><strong>Overall Experience Rating:</strong> {survey.ExperienceRating}/10</p>
        <hr/>
        <h3>Additional Comments</h3>
        <p>{survey.Others}</p>
        <hr/>
        <p>This email is automatically generated. Please do not reply.</p>";
    }
}
