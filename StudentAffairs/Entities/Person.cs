namespace StudentAffairs;

public class Person : BaseEntity
{

    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public int Age { get; set; }

    public Person() { }
    public Person(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}
