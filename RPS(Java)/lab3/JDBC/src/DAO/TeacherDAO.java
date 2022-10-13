package DAO;

import Models.Teacher;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class TeacherDAO extends DAO {

    public void create(Teacher teacher) throws SQLException {
        Connection conn = super.getConn();

        try (Statement stmt = conn.createStatement()) {
            int changeCount = stmt.executeUpdate("insert into teacher (name, surname, birthday) values (" + teacher.toInsert() + ")");
            System.out.println("Количество созданных строк: " + changeCount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public <T> void update(String paramName, T value, long id) throws SQLException {
        Connection conn = super.getConn();
        try (Statement stmt = conn.createStatement()) {
            int changeCount = stmt.executeUpdate("update teacher set " + paramName + "=" + value + " where id=" + id);
            System.out.println("Количество измененных строк: " + changeCount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void delete(long id) throws SQLException {
        Connection conn = super.getConn();
        try (Statement stmt = conn.createStatement()) {
            int changeCount = stmt.executeUpdate("delete from teacher where id=" + id);
            System.out.println("Количество удаленных строк: " + changeCount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public Teacher getById(long id) throws SQLException {
        Connection conn = super.getConn();

        try (Statement stmt = conn.createStatement()) {
            ResultSet rs = stmt.executeQuery("select * from teacher where id=" + id);
            rs.next();
            Teacher teacher = new Teacher(
                    rs.getLong("id"),
                    rs.getString("name"),
                    rs.getString("surname"),
                    rs.getDate("birthday"));
            return teacher;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public List<Teacher> getAll() throws SQLException {
        Connection conn = super.getConn();

        ArrayList<Teacher> teachers = new ArrayList<>();

        try (Statement stmt = conn.createStatement()) {
            ResultSet rs = stmt.executeQuery("select * from teacher");
            while(rs.next()) {
                Teacher teacher = new Teacher(
                        rs.getLong("id"),
                        rs.getString("name"),
                        rs.getString("surname"),
                        rs.getDate("birthday"));
                teachers.add(teacher);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return teachers;
    }

}
