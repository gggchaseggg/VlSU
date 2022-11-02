package grachev.Beans;

import javax.validation.constraints.*;

public class Student {
    private long id;
    @NotEmpty(message = "Поле обязательно")
    private String name;
    @NotEmpty(message = "Поле обязательно")
    private String surname;
    @Min(value = 0, message = "Оценка не может быть отрицательной")
    @Max(value = 5, message = "Оценка не может быть больше 5")
    private float averageScore;
    @Min(value = 0,message = "Курс не может быть отрицательным")
    private long courseId;

    public Student(long id, String name, String surname, float averageScore, long courseId) {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.averageScore = averageScore;
        this.courseId = courseId;
    }

    public Student() {

    }

    public long getId() {return this.id;}

    public void setId(long id) {this.id = id;}

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

    public float getAverageScore() {
        return this.averageScore;
    }

    public void setAverageScore(float averageScore) {
        this.averageScore = averageScore;
    }

    public long getCourseId() {
        return courseId;
    }

    public void setCourseId(long courseId) {
        this.courseId = courseId;
    }

    public void print() {
        System.out.println(
                        this.id + " " +
                        this.name + " " +
                        this.surname + " " +
                        this.averageScore + " " +
                        this.courseId);
    }

    public String toInsert() {
        return "'" + this.name + "','" + this.surname + "'," + this.averageScore + "," + this.courseId;
    }

    public String toString() {
        return this.id + " --- " + this.name + " - " + this.surname + " - " + this.averageScore + " - " + this.courseId;
    }
}
