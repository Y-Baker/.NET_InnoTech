using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentWpf;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    readonly static string apiURL = @"https://students.innopack.app/api";
    //readonly static string apiURL = @"http://localhost:5135/api";
    List<Student> students = new();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        bool isAgeValid = int.TryParse(StudentAge.Text, out int studentAge);
        students = Student.GetStudents(apiURL + "/students");

        Student student = new Student();
        student.Id = students.Count + 1;
        student.Name = StudentName.Text;
        student.Age = isAgeValid ? studentAge : 18;
        student.Mobile = StudentMobile.Text;

        students.Add(student);

        HttpClient client = new HttpClient();
        string studentSerialized = JsonSerializer.Serialize(student);
        HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");

        HttpResponseMessage? httpResponseMessage = client.PostAsync(apiURL + "/students", content).GetAwaiter().GetResult();
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            MessageBox.Show($"Student {student.Name} was saved successfully", "Success");
        }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        StudentName.Text = string.Empty;
        StudentAge.Text = string.Empty;
        StudentMobile.Text = string.Empty;
        StudentID.Text = string.Empty;
    }
    private void StudentName_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void StudentName_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void ReadAllStudents_Click(object sender, RoutedEventArgs e)
    {
        students = Student.GetStudents(apiURL + "/students");
        MessageBox.Show($"Student count = {students?.Count}", "Information");
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        bool isAgeValid = int.TryParse(StudentAge.Text, out int studentAge);
        students = Student.GetStudents(apiURL + "/students");
        Student student = new Student();
        student.Id = students.Count + 1;
        student.Name = StudentName.Text;
        student.Age = isAgeValid ? studentAge : 18;
        student.Mobile = StudentMobile.Text;

        HttpClient client = new HttpClient();
        string studentSerialized = JsonSerializer.Serialize(student);
        HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");
        HttpResponseMessage? response = client.PutAsync(apiURL + "/students", content).GetAwaiter().GetResult();
        if (response != null && response.IsSuccessStatusCode)
        {
            MessageBox.Show($"Student {student.Name} was update successfully", "Success");
        }
        else
        {
            MessageBox.Show("Something wrong happened", "Error");
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        bool isAgeValid = int.TryParse(StudentAge.Text, out int studentAge);
        students = Student.GetStudents(apiURL + "/students");
        Student student = new Student();
        student.Id = students.Count + 1;
        student.Name = StudentName.Text;
        student.Age = isAgeValid ? studentAge : 18;
        student.Mobile = StudentMobile.Text;

        HttpClient client = new HttpClient();
        string studentSerialized = JsonSerializer.Serialize(student);
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiURL + "/students");
        HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");
        request.Content = content;

        HttpResponseMessage? response = client.SendAsync(request).GetAwaiter().GetResult();


        if (response != null && response.IsSuccessStatusCode)
        {
            MessageBox.Show($"Student {student.Name} was deleted successfully", "Success");
        }
        else
        {
            MessageBox.Show("Something wrong happened", "Error");
        }
    }

    private void GetID_Click(object sender, RoutedEventArgs e)
    {
        bool isIdValid = int.TryParse(StudentID.Text, out int studentID);
        if (isIdValid is false)
        {
            MessageBox.Show($"ID: {StudentID.Text} is not valid");
            return;
        }
        students = Student.GetStudents(apiURL + "/students");

        HttpClient client = new HttpClient();
        HttpResponseMessage? response = client.GetAsync(apiURL + $"/students/{studentID}").GetAwaiter().GetResult();
        if (response != null && response.IsSuccessStatusCode)
        {
            try
            {
                string? content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (string.IsNullOrEmpty(content))
                {
                    throw new Exception($"No Student With ID:{studentID}");
                }
                Student? student = JsonSerializer.Deserialize<Student>(content);

                if (student != null)
                {
                    StudentName.Text = student.Name;
                    StudentAge.Text = student.Age.ToString();
                    StudentMobile.Text = student.Mobile;
                }
                MessageBox.Show($"Student Retrived", "Success");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }
        else
        {
            MessageBox.Show("Something wrong happened", "Error");
        }
    }
}
