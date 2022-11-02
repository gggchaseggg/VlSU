package grachev.Controllers;

import grachev.Beans.Student;
import grachev.DAO.IStudentDAO;
import grachev.DAO.JDBCStudentDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

@Controller
public class MainController {

    @Autowired
    IStudentDAO studentDAO;

    @GetMapping("/students")
    public String studentsList(Model model) throws SQLException {
        List<Student> students = studentDAO.getAll();
        model.addAttribute(students);
        model.addAttribute(new java.util.Date());
        double avrg = 0;
        for (Student student: students) {
            avrg += student.getAverageScore();
        }
        model.addAttribute("averageScore", String.format("%.3f",avrg/students.size()));

        return "index";
    }

    @GetMapping("/students/{id}")
    public String studentGetById(@PathVariable String id, Model model) throws SQLException {
        Student student = studentDAO.getById(Long.parseLong(id));
        model.addAttribute(student);

        return "studentInfo";
    }

    @GetMapping("/students/create")
    public String createStudent(@RequestParam(required = false, name="id") Integer id, Model model) throws SQLException {
        model.addAttribute("student", id != null ? studentDAO.getById(id) : new Student());
        model.addAttribute("id",id);
        return "createStudentForm";
    }

    @GetMapping("students/delete/{id}")
    public String deleteStudent(@PathVariable String id, Model model) throws SQLException {
        studentDAO.delete(Long.parseLong(id));
        return "deleteConfirm";
    }

    @PostMapping("students/createStudent")
    public String postStudent(@ModelAttribute("student") @Valid Student student,
                              BindingResult bindingResult) throws SQLException {
        System.out.println(student);
        if (bindingResult.hasErrors()) {
            return "createStudentForm";
        } else {
            studentDAO.create(student);
            return "createConfirm";
        }
    }

    @PostMapping("students/updateStudent")
    public String postUpdateStudent(@ModelAttribute Student student, Model model) throws SQLException {
        studentDAO.update(student.getId(), student);
        return "createConfirm";
    }

}
