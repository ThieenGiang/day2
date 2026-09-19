using System;
using System.Collections.Generic;
using System.Linq;

public class StudentDAO
{
    // Giả lập cơ sở dữ liệu bằng List
    private readonly List<Student> _database;

    public StudentDAO()
    {
        _database = new List<Student>();
    }

    public void Add(Student student)
    {
        // Kiểm tra tính hợp lệ trước khi thêm (tránh trùng khóa chính)
        if (GetById(student.Id) != null)
        {
            throw new ArgumentException($"Sinh viên với ID {student.Id} đã tồn tại.");
        }

        _database.Add(student);
    }

    public void Edit(Student student)
    {
        var existingStudent = GetById(student.Id);

        if (existingStudent == null)
        {
            throw new KeyNotFoundException($"Không tìm thấy sinh viên với ID {student.Id} để cập nhật.");
        }

        // Cập nhật các trường dữ liệu
        existingStudent.Name = student.Name;
        existingStudent.Age = student.Age;
        existingStudent.GPA = student.GPA;
    }

    public void Delete(string id)
    {
        var studentToRemove = GetById(id);

        if (studentToRemove != null)
        {
            _database.Remove(studentToRemove);
        }
        else
        {
            throw new KeyNotFoundException($"Không tìm thấy sinh viên với ID {id} để xóa.");
        }
    }

    public List<Student> GetAll()
    {
        // Trả về một bản sao để bảo vệ tính toàn vẹn của danh sách gốc
        return _database.ToList();
    }

    public Student GetById(string id)
    {
        // Sử dụng FirstOrDefault để trả về null nếu không tìm thấy
        return _database.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetByName(string name)
    {
        // Tìm kiếm tương đối (Contains) và không phân biệt chữ hoa/thường
        return _database
            .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}