## Task 1
* [src](./CPU-Report/)
* [output example](./CPU-Report/CPU-Report/logs/cpu-report.txt)

#### Command for nssm
```bash
nssm install cpu-report
```
this take you to the GUI to complete the installation by adding path to the exe file and another configration like start-up type

![image](https://github.com/user-attachments/assets/a335bfc5-3e96-4ee6-87dd-eb0554e92a25)

---

## Task 2
* [src](./CPU-Report/)
* [src](./ObjectOrianted/Teacher.cs)
* [output example](./CPU-Report/CPU-Report/logs/teachers.json)

#### How I make append new teachers to the end without need to read all the teacher and rewrite all of them
```cs
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
```
I remove the last ']' which is the last char in the file and append the new list of teacher after removing the first ']'

---

## Task 3
* [src](./ObjectOrianted/)

#### How to use the dll without need to all project
- step 1
  - right click on Dependencies and chosse Add Project Reference
  - ![image](https://github.com/user-attachments/assets/afc65fe9-7756-451f-b6d2-aed79a80053f)

- step 2
  - click Browse and choose your dll file
  - ![image](https://github.com/user-attachments/assets/ae4f62f7-36ec-4033-8d82-724079f38ed8)

- step 3
  - Click Ok

---

## Task 4 
* [src](./StudentsAffairsWebAPI/Controllers/TeachersController.cs)

#### same like Task 2
```cs
    public void Post(Teacher teacher)
    {
        string? content = System.Text.Json.JsonSerializer.Serialize(teacher);
        if (System.IO.File.Exists(filePath) == false || System.IO.File.ReadAllBytes(filePath).Length == 0)
        {
            content = '[' + content + "]";
            System.IO.File.WriteAllText(filePath, content);
        }
        else
        {
            content += ']';
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                fs.Seek(-1, SeekOrigin.End);
                fs.WriteByte((byte)',');
                fs.Write(Encoding.UTF8.GetBytes(content));
            }
        }
    }
```
If the file is empty i add the two [] to the teacher to make it list
and if i add teacher to the end i just remove the last ] from the file and add the teacher with ] at end

---

## Task 5

* [src](./StudentsAffairsWebAPI/Controllers/TeachersController.cs)

#### Put Method

* the url with key as parameter: https://localhost:7153/api/teachers/?key=17
* a teacher in body of the request like 
```json
{
  "id": 7,
  "name": "Teacher17",
  "age": 37
}
```

#### Delete Method

* the url with key as parameter: https://localhost:7153/api/teachers/?key=17

Delete all teacher with id equal to key

<br />

## Authors :black_nib:
* [__Repo__](https://github.com/Y-Baker/Course_Hub)
* __Yousef Bakier__ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
 &nbsp;&nbsp;[<img height="" src="https://img.shields.io/static/v1?label=&message=GitHub&color=181717&logo=GitHub&logoColor=f2f2f2&labelColor=2F333A" alt="Github">](https://github.com/Y-Baker)
