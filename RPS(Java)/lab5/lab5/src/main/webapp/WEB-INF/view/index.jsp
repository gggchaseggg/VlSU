<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix = "fmt" uri = "http://java.sun.com/jsp/jstl/fmt" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page isELIgnored="false" %>
<html>
<head>
    <title>Студенты</title>
</head>
<body>
    <h1>Список студентов:</h1>
    <c:set var = "now" value = "${date}" />
    <fmt:formatDate type = "both" dateStyle = "long" timeStyle = "long" value = "${now}" />
    <table border="1">
        <thead>
            <tr style="background-color: rgba(245, 239, 230, 0.5)">
                <td>ID</td>
                <td>Имя</td>
                <td>Фамилия</td>
                <td>Средний балл</td>
                <td>Курс</td>
                <td style="color:green">Ссылка</td>
                <td style="color:red">Удаление</td>
                <td style="color:yellow">Обновление</td>
            </tr>
        </thead>
        <tbody>
            <c:forEach items="${studentList}" var="student">
                <c:url value = "/students/create" var="updateSTD">
                    <c:param name="id" value="${student.id}"/>
                </c:url>
                <tr style="background-color:${student.averageScore > 4.5 ? "rgba(179, 255, 174,0.5)" : "rgba(255, 125, 125,0.5)"}">
                    <td><c:out value="${student.id}"/></td>
                    <td><c:out value="${student.name}"/></td>
                    <td><c:out value="${student.surname}"/></td>
                    <td><c:out value="${student.averageScore}"/></td>

                    <td><fmt:formatNumber type = 'number' pattern = '# курс' value = '${student.courseId}'/></td>
                    <td><a href="<c:url value = "/students/${student.id}"/>">Перейти</a></td>
                    <td><a href="<c:url value = "/students/delete/${student.id}"/>">Удалить</a></td>
                    <td><a href="${updateSTD}">Обновить</a></td>
                </tr>
            </c:forEach>
        </tbody>
        <tfoot>
            <tr style="background-color: rgba(120, 149, 178, 0.5)">
                <td></td>
                <td></td>
                <td></td>
                <td>${averageScore}</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </tfoot>
    </table>
    <p><a href="/lab5/students/create">Создать студента</a></p>
</body>
</html>
