namespace StudentAffairs;

public class Track
{
    public static void TrackMethod([CallerMemberName] string methodName = "")
    {
        Console.WriteLine($"{methodName} invoked.");
    }
}
