using System;
using System.Timers;
using System.IO;
using System.Diagnostics;
using System.Threading;
using StudentsAffairs;
using System.Text;

class Program
{
    static int minuteCount = 0;
    static int cpuReportCycle = 1 * 60 * 1000;
    static int teacherCreateCount = 10;
    static int teacherCreateCycle = 10;
    readonly static string directory = @"../../../../logs/";
    readonly static string reportPath = directory + "cpu-report.txt";
    readonly static string teachersPath = directory + "teachers.json";
    static PerformanceCounter CPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    static PerformanceCounter RAM = new PerformanceCounter("Memory", "Available MBytes");

    static void Main()
    {
        if (Directory.Exists(reportPath) is false)
        {
            Directory.CreateDirectory(directory);
        }
        if (File.Exists(reportPath) == false)
        {
            using (StreamWriter sw = File.CreateText(reportPath))
            {
                sw.WriteLine($"Report Started at {DateTime.Now}");
                sw.WriteLine();
            }
        }
        CPU.NextValue();
        RAM.NextValue();
        System.Timers.Timer timer = new System.Timers.Timer(cpuReportCycle);

        timer.Elapsed += OnTimedEvent;

        // Start the timer
        timer.Start();

        Console.WriteLine("Timer started. Press [Enter] to exit the program at any time...");
        Console.ReadLine();
    }

    static void OnTimedEvent(Object? source, ElapsedEventArgs e)
    {
        if (minuteCount % teacherCreateCycle == 0)
        {
            IEnumerable<Teacher> teachers = new List<Teacher>();
            int start = (minuteCount / teacherCreateCycle) * teacherCreateCount + 1;
            teachers = Teacher.ReadTeachers(start, teacherCreateCount);
            string? content = System.Text.Json.JsonSerializer.Serialize(teachers);
            if (File.Exists(teachersPath) == false || File.ReadAllBytes(teachersPath).Length == 0 )
            {
                File.WriteAllText(teachersPath, content);
            }
            else
            {
                content = content.Substring(1);
                using (FileStream fs = new FileStream(teachersPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.Seek(-1, SeekOrigin.End);
                    char toAdd = ',';
                    fs.WriteByte((byte)toAdd);
                    fs.Write(Encoding.UTF8.GetBytes(content));
                }
            }
        }

        minuteCount++;

        float cpuUsage = CPU.NextValue();
        float availableMemory = RAM.NextValue();
        int numberProcess = Process.GetProcesses().Length;
        using (StreamWriter sw = File.AppendText(reportPath))
        {
            sw.WriteLine($"Report {minuteCount}\t\t Time: {DateTime.Now}");
            sw.WriteLine($"\t\tMachine Name: {Environment.MachineName}");
            sw.WriteLine($"\t\tOperating System: {Environment.OSVersion}");
            sw.WriteLine($"\t\tNumber of Processors: {Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")}");
            sw.WriteLine($"\t\tCPU-Usage: {cpuUsage}%");
            sw.WriteLine($"\t\tAvailable Memory: {availableMemory} MB");
            sw.WriteLine($"\t\tNumber of Running Processes: {numberProcess} process");
            sw.WriteLine();
        }

    }
}
