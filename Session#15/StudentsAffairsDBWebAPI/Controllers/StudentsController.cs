//EntityFramework8 ORM object relational mapper =>
//DDL(Create table, Alter view, drop table),
//DML(Insert,Select,Update,Delete),
//DCL(Grant Update on table students to wael,revoke)

using System.Diagnostics;

namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController<Student>
{
    public StudentsController(StudentsAffairsDbContext studentsAffairsDbContext)
        : base(studentsAffairsDbContext)
    {
    }
}