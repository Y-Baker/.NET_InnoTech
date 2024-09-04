namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : BaseController<Doctor>
{
    public DoctorsController(StudentsAffairsDbContext studentsAffairsDbContext)
        : base(studentsAffairsDbContext)
    {
    }
}
