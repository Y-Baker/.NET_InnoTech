namespace StudentAffairs;

public interface IDoctorService
{
    Task<List<Doctor>> GetDoctors();
    Task ShowModal(Modal modal);
}
public class DoctorService : IDoctorService
{
    private readonly IDoctorsUnitOfWork doctors;

    public DoctorService(IDoctorsUnitOfWork _doctors)
    {
        doctors = _doctors;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return (List<Doctor>)await doctors.ReadAll();
    }

    public async Task ShowModal(Modal modal)
    {
        ArgumentNullException.ThrowIfNull(modal);
        await modal.ShowModal();
    }
}
