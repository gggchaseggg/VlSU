package grachev.Beans;

import java.util.Date;

public class Teacher {
    private long id;
    private String name;
    private String surname;
    private Date birthday;

    public Teacher(long id, String name, String surname, Date birthday) {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.birthday = birthday;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return this.surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public Date getBirthday() {
        return this.birthday;
    }

    public void setBirthday(Date birthday) {
        this.birthday = birthday;
    }

    public void print() {
        System.out.println(
                this.id + " " +
                        this.name + " " +
                        this.surname + " " +
                        this.birthday);
    }

    public String toInsert() {
        return "'" +
                this.name + "','" +
                this.surname + "','" +
                this.birthday.getYear() + "-" +
                this.birthday.getMonth() + "-" +
                this.birthday.getDay();
    }
}
