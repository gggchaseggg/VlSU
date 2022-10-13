package Conn;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public class MySQLConn {

    private String username;
    private String password;
    private String dbms;
    private String serverName;
    private String portNumber;
    private String dbName;

    public MySQLConn(String username, String password, String dbms, String serverName, String portNumber, String dbName) {
        try {
            Class.forName("com.mysql.cj.jdbc.Driver").newInstance();
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException e) {
            System.err.println("Драйвер MySQL не найден");
        }
        this.username = username;
        this.password = password;
        this.dbms = dbms;
        this.serverName = serverName;
        this.portNumber = portNumber;
        this.dbName = dbName;
    }

    public Connection createConnection() throws SQLException {
        Properties connectionProps = new Properties();
        connectionProps.put("user", this.username);
        connectionProps.put("password", this.password);

        return DriverManager.getConnection("jdbc:" + this.dbms + "://" + this.serverName + ":" + this.portNumber +
                "/" + this.dbName, connectionProps);
    }


}
