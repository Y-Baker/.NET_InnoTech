namespace EntityDefinition;
public class Course : BaseEntity
{
    public int? CreaditHours { get; set; }

    public Guid InstructorId { get; set; }

    public Guid? PreRequest { get; set; }

    public int NumberOfStudents { get; set; }
}
