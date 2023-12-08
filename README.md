# StudentAPI

StudentAPI is a simple C# ASP.NET Core API for managing university-related entities such as students, lectures, departments, and their associations. It uses Dapper for data access and PostgreSQL as the database.

## Features

- Retrieve a list of students, lectures, departments, and department-lecture associations.
- Display students and lectures by department.
- Display lectures by student based on department associations.
- Create a department and add students and lectures to it.
- Add students to an existing department.
- Transfer a student from one department to another.
- Create a new lecture and add it to a department.

## Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/StudentAPI.git
2.  Set up your PostgreSQL database and connection string in the `appsettings.json` file.
    
3.  Build and run the application:
    
    `cd StudentAPI dotnet build dotnet run`
    
    The API will be available at `https://localhost:5001` (or another port if specified).
    
4.  Use tools like [Swagger](https://swagger.io/) or [Postman](https://www.postman.com/) to interact with the API.
    

Endpoints
---------

*   `GET /University/GetStudents`: Retrieve all students.
*   `GET /University/GetLectures`: Retrieve all lectures.
*   `GET /University/GetDepartment`: Retrieve all departments.
*   `GET /University/GetDepartmentLecture`: Retrieve all department-lecture associations.
*   `GET /University/GetStudentsByDepartment/{departmentId}`: Retrieve students by department ID.
*   `GET /University/GetLecturesByDepartment/{departmentId}`: Retrieve lectures by department ID.
*   `GET /University/GetLecturesByStudent/{studentId}`: Retrieve lectures by student ID.
*   `GET /University/GetDepartmentById/{departmentId}`: Retrieve department by ID.
*   `POST /University/CreateDepartmentWithStudentsAndLectures`: Create a department and add students and lectures to it.
*   `POST /University/{departmentId}/addStudents`: Add students to an existing department.
*   `POST /University/{studentId}/transfer/{newDepartmentId}`: Transfer a student from one department to another.
*   `POST /University/{departmentId}/createLecture`: Create a lecture and add it to a department.

Contributing
------------

Feel free to contribute to this project by submitting issues or pull requests. Follow the [Contribution Guidelines](CONTRIBUTING.md) for more information.

License
-------

This project is licensed under the [MIT License](LICENSE).
