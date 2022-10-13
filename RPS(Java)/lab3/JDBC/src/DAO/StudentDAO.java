package DAO;

import Conn.MySQLConn;
import Models.Student;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class StudentDAO extends DAO {

    public void create(Student student) throws SQLException {
        Connection conn = super.getConn();

        try (Statement stmt = conn.createStatement()) {
            int changeCount = stmt.executeUpdate("insert into student (name, surname, averageScore, course) values (" + student.toInsert() + ")");
            System.out.println("Количество созданных строк: " + changeCount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public <T> void update(String paramName, T value, long id) throws SQLException {
        Connection conn = super.getConn();
        try (Statement stmt = conn.createStatement()) {
            int changeCount = stmt.executeUpdate("update student set " + paramName + "=" + value + " where id=" + id);
            System.out.println("Количество измененных строк: " + changeCount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void delete(long id) throws SQLException {
        Connection conn = super.getConn();
        try (Statement stmt = conn.createStatement()) {
            int changeCount = stmt.executeUpdate("delete from student where id=" + id);
            System.out.println("Количество удаленных строк: " + changeCount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public Student getById(long id) throws SQLException {
        Connection conn = super.getConn();

        try (Statement stmt = conn.createStatement()) {
            ResultSet rs = stmt.executeQuery("select * from student where id=" + id);
            rs.next();
            Student student = new Student(
                    rs.getLong("id"),
                    rs.getString("name"),
                    rs.getString("surname"),
                    rs.getFloat("averageScore"),
                    rs.getLong("course"));
            return student;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public List<Student> getAll() throws SQLException {
        Connection conn = super.getConn();

        ArrayList<Student> students = new ArrayList<>();

        try (Statement stmt = conn.createStatement()) {
            ResultSet rs = stmt.executeQuery("select * from student");
            while(rs.next()) {
                Student student = new Student(
                        rs.getLong("id"),
                        rs.getString("name"),
                        rs.getString("surname"),
                        rs.getFloat("averageScore"),
                        rs.getLong("course"));
                students.add(student);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return students;
    }
}
