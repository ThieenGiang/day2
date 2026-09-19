using System;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    // Khởi tạo không tham số
    public Student() { }

    // Khởi tạo có tham số
    public Student(string id, string name, int age, double gpa)
    {
        Id = id;
        Name = name;
        Age = age;
        GPA = gpa;
    }
}