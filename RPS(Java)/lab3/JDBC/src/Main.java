import DAO.StudentDAO;
import DAO.TeacherDAO;
import Models.Student;
import Conn.MySQLConn;
import Models.Teacher;

import java.sql.*;
import java.util.List;

public class Main {

    public static void main(String[] args) throws SQLException {

        StudentDAO studentDAO = new StudentDAO();
        List<Student> students = studentDAO.getAll();
        for (Student item: students) {
            item.print();
        }

        System.out.println();

        studentDAO.<Double>update("averageScore", 5.0,1);

        System.out.println();

        students = studentDAO.getAll();
        for (Student item: students) {
            item.print();
        }

        System.out.println();

        TeacherDAO teacherDAO = new TeacherDAO();
        List<Teacher> teachers = teacherDAO.getAll();
        for (Teacher item: teachers) {
            item.print();
        }
    }
}
