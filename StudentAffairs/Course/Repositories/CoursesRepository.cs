namespace StudentAffairs;

public class CoursesRepository : Repository<Course>, ICoursesRepository
{
    public CoursesRepository(StudentsAffairsDbContext context) : base(context) { }

}
