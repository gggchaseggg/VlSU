<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page isELIgnored="false" %>
<html>
<head>
    <title>Форма</title>
</head>
<body>
    <c:choose>
        <c:when test="${id != null}">
            <h1>Обновить студента</h1>
        </c:when>
        <c:otherwise>
            <h1>Создать студента</h1>
        </c:otherwise>
    </c:choose>
    <form:form method="post" action="${id != null ? 'updateStudent' : 'createStudent'}" modelAttribute="student">
        <table>
            <c:if test="${id != null}">
                <tr>
                    <td><form:label path="id">ID</form:label></td>
                    <td><form:input path="id" readonly="true" /></td>
                    <td> <form:errors path="id" cssStyle="color: red"/> </td>
                </tr>
            </c:if>
            <tr>
                <td><form:label path="name">Имя</form:label></td>
                <td><form:input path="name"/></td>
                <td> <form:errors path="name" cssStyle="color: red"/> </td>
            </tr>
            <tr>
                <td><form:label path="surname">Фамилия</form:label></td>
                <td><form:input path="surname"/></td>
                <td> <form:errors path="surname" cssStyle="color: red"/> </td>
            </tr>
            <tr>
                <td><form:label path="averageScore">Средний балл</form:label></td>
                <td><form:input path="averageScore"/></td>
                <td> <form:errors path="averageScore" cssStyle="color: red"/> </td>
            </tr>
            <tr>
                <td><form:label path="courseId">ID курса</form:label></td>
                <td><form:input path="courseId"/></td>
                <td> <form:errors path="courseId" cssStyle="color: red"/> </td>
            </tr>
            <tr>
                <td><input type="submit" value="Подтвердить"></td>
                <td><input type="reset" value="Очистить"></td>
            </tr>
        </table>
    </form:form>

    <p><a href="/lab5/students">Список студентов</a></p>
</body>
</html>
