package grachev.DAO;

import grachev.Beans.Teacher;

import java.sql.SQLException;
import java.util.List;

public interface ITeacherDAO {

    public void create(Teacher teacher) throws SQLException;

    public <T> void update(String paramName, T value, long id) throws SQLException;

    public void delete(long id) throws SQLException;

    public Teacher getById(long id) throws SQLException;

    public List<Teacher> getAll() throws SQLException;
}
