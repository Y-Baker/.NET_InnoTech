namespace StudentAffairs;

public class StudentsRepository : UserRepository<Student>, IStudentsRepository
{
    public StudentsRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<Student?> GetByGPA(float value)
    {
        Student? studentFromDb = await _dbSet.FirstOrDefaultAsync(e => e.GPA == value);

        return studentFromDb;
    }
}