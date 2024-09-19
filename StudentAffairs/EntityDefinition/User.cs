namespace StudentAffairs;

public abstract class User : BaseEntity
{

    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public int Age { get; set; }

    public User() { }
    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}
