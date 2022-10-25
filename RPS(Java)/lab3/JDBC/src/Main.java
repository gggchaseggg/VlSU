import DAO.IStudentDAO;
import DAO.ITeacherDAO;
import DAO.JDBCStudentDAO;
import DAO.JDBCTeacherDAO;
import Models.Student;
import Models.Teacher;

import java.sql.*;
import java.util.List;


import org.springframework.context.support.*;
import org.springframework.beans.factory.*;
import org.springframework.core.io.DefaultResourceLoader;
import org.springframework.core.env.EnvironmentCapable;

public class Main {

    public static void main(String[] args) throws SQLException {

        ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext("daos.xml");


        IStudentDAO studentDAO = context.getBean("studentDAO", IStudentDAO.class);
        ITeacherDAO teacherDAO = context.getBean("teacherDAO", ITeacherDAO.class);



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

        List<Teacher> teachers = teacherDAO.getAll();
        for (Teacher item: teachers) {
            item.print();
        }
    }
}
