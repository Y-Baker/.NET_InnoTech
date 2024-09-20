namespace DoctorDomain;

public partial class Doctors : ComponentBase
{
    Doctor? _doctor = new();
    List<Doctor>? doctors = new();
    bool isLoading = false;
    Doctor? _doctorToDelete;
    Modal? modal = new Modal();

    [Inject] public IDoctorsUnitOfWork? _doctors { get; set; }
    [Inject] public IDoctorService? _service { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Track.TrackMethod();
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        doctors = await _service.GetDoctors();

        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        Track.TrackMethod();

        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_doctor is null)
        {
            Console.WriteLine($"{nameof(_doctor)} Not Found");
            return;
        }

        isLoading = true;
        StateHasChanged();

        try
        {
            string doctorSerialized = _doctor is null ? string.Empty : JsonSerializer.Serialize(_doctor);
            Doctor? validDoctor = JsonSerializer.Deserialize<Doctor>(doctorSerialized);
            ArgumentNullException.ThrowIfNull(validDoctor, nameof(validDoctor));

            Doctor? newDoctor = doctors?.FirstOrDefault(e => e.Id == validDoctor.Id);

            ArgumentNullException.ThrowIfNull(_doctors, nameof(_doctors));
            if (newDoctor is null)
            {
                validDoctor.Id = Guid.NewGuid();
                await _doctors.Create(validDoctor);
            }
            else
            {
                await _doctors.Update(validDoctor);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_doctor)} Not Saved");
            throw;
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            doctors = await _service.GetDoctors();
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditDoctor(Doctor toBeEditedDoctor)
    {
        Track.TrackMethod();

        string? doctorSerialized = JsonSerializer.Serialize(toBeEditedDoctor);
        if (doctorSerialized is not null)
            _doctor = JsonSerializer.Deserialize<Doctor>(doctorSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Doctor doctor)
    {
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _doctorToDelete = doctor;
        await _service.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_doctorToDelete != null)
        {
            await DeleteDoctor(_doctorToDelete);
        }
    }
    public async Task DeleteDoctor(Doctor doctor)
    {
        Track.TrackMethod();
        isLoading = true;
        ArgumentNullException.ThrowIfNull(doctor, nameof(doctor));
        ArgumentNullException.ThrowIfNull(_doctors, nameof(_doctors));

        try
        {
            await _doctors.Delete(doctor);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Doctor Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            doctors = await _service.GetDoctors();
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _doctor = new();
    }
}