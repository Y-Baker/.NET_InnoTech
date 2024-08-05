namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : BaseController<Teacher>
{
    public TeachersController(StudentsAffairsDbContext studentsAffairsDbContext)
        : base(studentsAffairsDbContext)
    {
    }
}
