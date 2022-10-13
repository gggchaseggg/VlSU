package Models;

public class Student {
    private long id;
    private String name;
    private String surname;
    private float averageScore;
    private long courseId;

    public Student(long id, String name, String surname, float averageScore, long courseId) {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.averageScore = averageScore;
        this.courseId = courseId;
    }

    public Student(String name, String surname, float averageScore, long courseId) {
        this.name = name;
        this.surname = surname;
        this.averageScore = averageScore;
        this.courseId = courseId;
    }
    public Student(String name, String surname, long courseId) {
        this.name = name;
        this.surname = surname;
        this.courseId = courseId;
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
}
