using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace StudentsApp
{
    public partial class StudentsForm : Form
    {
        readonly static string apiURL = @"https://students.innopack.app/api";
        //readonly static string apiURL = @"http://localhost:5135/api";
        List<Student> students = new();
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool isAgeValid = int.TryParse(CreateStudentAge.Text, out int studentAge);
            students = Student.GetStudents(apiURL + "/students");

            Student student = new Student();
            student.Id = students.Count + 1;
            student.Name = CreateStudentName.Text;
            student.Age = isAgeValid ? studentAge : 18;
            student.Mobile = CreateStudentMobile.Text;

            students.Add(student);

            HttpClient client = new HttpClient();
            string studentSerialized = JsonSerializer.Serialize(student);
            HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");

            HttpResponseMessage? httpResponseMessage = client.PostAsync(apiURL + "/students", content).GetAwaiter().GetResult();
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show($"Student {student.Name} was saved successfully", "Success");
            }

            Result.Text = $"Student {student.Name} was added successfully, Total students count = {students.Count}";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            CreateStudentName.Text = string.Empty;
            CreateStudentAge.Text = string.Empty;
            CreateStudentMobile.Text = string.Empty;
            Result.Text = string.Empty;
            Error.Text = string.Empty;
        }

        private void ReadAllStudents_Click(object sender, EventArgs e)
        {
            students = Student.GetStudents(apiURL + "/students");
            MessageBox.Show($"Student count = {students?.Count}", "Information");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            bool isAgeValid = int.TryParse(UpdateStudentAge.Text, out int studentAge);
            students = Student.GetStudents(apiURL + "/students");
            Student student = new Student();
            student.Id = students.Count + 1;
            student.Name = UpdateStudentName.Text;
            student.Age = isAgeValid ? studentAge : 18;
            student.Mobile = UpdateStudentMobile.Text;

            HttpClient client = new HttpClient();
            string studentSerialized = JsonSerializer.Serialize(student);
            HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage? response = client.PutAsync(apiURL + "/students", content).GetAwaiter().GetResult();
            if (response != null && response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Student {student.Name} was update successfully", "Success");
            }
            else
            {
                Error.Text = "Something wrong happened";
                return;
            }
            Result.Text = $"Student {student.Name} was updated successfully, Total students count = {students.Count}";
        }

        private void UpdateClear_Click(object sender, EventArgs e)
        {
            UpdateStudentName.Text = string.Empty;
            UpdateStudentAge.Text = string.Empty;
            UpdateStudentMobile.Text = string.Empty;
            Result.Text = string.Empty;
            Error.Text = string.Empty;
        }

        private void UpdateReadAllStudents_Click(object sender, EventArgs e)
        {
            ReadAllStudents_Click(sender, e);
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            return;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            bool isAgeValid = int.TryParse(DeleteStudentAge.Text, out int studentAge);
            students = Student.GetStudents(apiURL + "/students");
            Student student = new Student();
            student.Id = students.Count + 1;
            student.Name = DeleteStudentName.Text;
            student.Age = isAgeValid ? studentAge : 18;
            student.Mobile = DeleteStudentMobile.Text;

            HttpClient client = new HttpClient();
            string studentSerialized = JsonSerializer.Serialize(student);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiURL + "/students");
            HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");
            request.Content = content;

            HttpResponseMessage? response = client.SendAsync(request).GetAwaiter().GetResult();


            if (response != null && response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Student {student.Name} was deleted successfully", "Success");
            }
            else
            {
                Error.Text = "Something wrong happened";
                return;
            }
            Result.Text = $"Student {student.Name} was deleted successfully, Total students count = {students.Count - 1}";
        }

        private void DeleteClear_Click(object sender, EventArgs e)
        {
            DeleteStudentName.Text = string.Empty;
            DeleteStudentAge.Text = string.Empty;
            DeleteStudentMobile.Text = string.Empty;
            Result.Text = string.Empty;
            Error.Text = string.Empty;
        }

        private void DeleteReadAllStudents_Click(object sender, EventArgs e)
        {
            ReadAllStudents_Click(sender, e);
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void GetID_Click(object sender, EventArgs e)
        {
            bool isIdValid = int.TryParse(StudentID.Text, out int studentID);
            if (isIdValid is false)
            {
                Error.Text = $"ID: {StudentID.Text} is not valid";
                return;
            }
            students = Student.GetStudents(apiURL + "/students");

            HttpClient client = new HttpClient();
            HttpResponseMessage? response = client.GetAsync(apiURL + $"/students/{studentID}").GetAwaiter().GetResult();
            if (response != null && response.IsSuccessStatusCode)
            {
                Result.Text = $"Student Retrived";
                string? content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Student? student = JsonSerializer.Deserialize<Student>(content);
                
                if (student != null)
                {
                    GetStudentName.Text = student.Name;
                    GetStudentAge.Text = student.Age.ToString();
                    GetStudentMobile.Text = student.Mobile;
                }
            }
            else
            {
                Error.Text = "Something wrong happened";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            StudentID.Text = string.Empty;
            GetStudentName.Text = string.Empty;
            GetStudentAge.Text = string.Empty;
            GetStudentMobile.Text = string.Empty;

            Result.Text = string.Empty;
            Error.Text = string.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReadAllStudents_Click(sender, e);
        }
    }

}
