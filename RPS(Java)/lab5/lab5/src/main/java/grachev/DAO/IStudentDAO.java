package grachev.DAO;

import grachev.Beans.Student;

import java.sql.SQLException;
import java.util.List;

public interface IStudentDAO {

    public void create(Student student) throws SQLException;

    public void update(long id, Student student) throws SQLException;

    public void delete(long id) throws SQLException;

    public Student getById(long id) throws SQLException;

    public List<Student> getAll() throws SQLException;
}
