## Task Session 5
- First you need to install a software to create a partition for google drive like RaiDrive
- After installation open it and click Add chose google drive and choose your configuration 
- sign in to your Account and give the permission to write and read 
- wla now you can acssess your drive from windows explorer

![image](https://github.com/user-attachments/assets/af25f9ef-6701-469a-b551-86fa8b2d2c8f)
![image](https://github.com/user-attachments/assets/147a1fa9-c4fa-460e-bb86-c734b779308f)
![image](https://github.com/user-attachments/assets/21035d39-e012-4799-a9f8-c5f7289794d4)

<br />

## Task 1
* [resource] (https://stackoverflow.com/questions/3571137/how-to-keep-memory-of-process-protected)

#### there is an application (process) use some ram in stack and heap. Is there any another application (process) can access them? And How .net and c# help me protect my processes?

* each application typically runs in its own process with its own memory space, which includes both the stack and heap So each Process cannot directly access the memory of another process

* Based on what i read, .net alot of features to protect our process as it automatic take care of buffer overflows, memory leaks, and invalid memory access and alot of advanced feature like CAS and IPC (Inter-Process Communication)

* Example from me: as backend and frontend doesn't the same process so each one can't accsess the Stack&Heap of the other.
* Based on this note: that is a reason of Why we need API.

---

## Task 2
* [src](./StudentsAffairsWebAPI/Controllers/StudentsController.cs)


#### Delete All Students that have id = value in one step
```cs
    List<Student> toBeDeletedStudents = new();

    foreach (Student student in students)
    {
        if (student.Id == idParsed)
        {
            toBeDeletedStudents.Add(student);
        }
    }
    if (toBeDeletedStudents.Count > 0)
    {
        foreach (Student student in toBeDeletedStudents)
        {
            students.Remove(student);
        }
    }
    else
    {
        return NotFound(idParsed);
    }

    string? fileContent = JsonSerializer.Serialize(students);
    System.IO.File.WriteAllText(filePath, fileContent);

    return Ok(toBeDeletedStudents);
```
I make a new List of Students that contain the students that their ids = value

---

## Task 3
### Wondows Form
* [sln](./StudentsApp/)
* [src](./StudentsApp/Form1.cs)

![image](https://github.com/user-attachments/assets/2c6cdd63-2934-437d-8fe8-235fba5ab478)

- Tab 1: For Create New Student
- Tab 2: Update an Exists Student
- Tab 3: Delete and Exists Student
- Tab 4: Get Student Based By his ID

### WPF
* [sln](./WpfApp/)
* [src](./WpfApp/MainWindow.xaml.cs)

![image](https://github.com/user-attachments/assets/9cfd2239-f8c3-4056-9a5b-1f127382a451)


<br />

## Authors :black_nib:
* [__Repo__](https://github.com/Y-Baker/Course_Hub)
* __Yousef Bakier__ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
 &nbsp;&nbsp;[<img height="" src="https://img.shields.io/static/v1?label=&message=GitHub&color=181717&logo=GitHub&logoColor=f2f2f2&labelColor=2F333A" alt="Github">](https://github.com/Y-Baker)
