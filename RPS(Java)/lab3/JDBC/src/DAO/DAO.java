package DAO;

import Conn.MySQLConn;

import java.sql.Connection;
import java.sql.SQLException;

public class DAO {
    protected Connection getConn() throws SQLException {
        return new MySQLConn(
                "root",
                "pass",
                "mysql",
                "localhost",
                "3306",
                "jdbc").createConnection();
    }
}
