CREATE TABLE Department (
    department_id SERIAL PRIMARY KEY,
    department_name VARCHAR(255) NOT NULL
);
CREATE TABLE Lecture (
    lecture_id SERIAL PRIMARY KEY,
    lecture_name VARCHAR(255) NOT NULL
);
CREATE TABLE DepartmentLecture (
    department_id INT REFERENCES Department(department_id),
    lecture_id INT REFERENCES Lecture(lecture_id),
    PRIMARY KEY (department_id, lecture_id)
);
CREATE TABLE Student (
    student_id SERIAL PRIMARY KEY,
    student_name VARCHAR(255) NOT NULL,
    department_id INT REFERENCES Department(department_id)
);
INSERT INTO Department (department_name) VALUES
    ('Mathematics Faculty'),
    ('Informatics Faculty'),
    ('Physics Faculty');
INSERT INTO Lecture (lecture_name) VALUES
    ('Algebra'),
    ('Computer Science Fundamentals'),
    ('Quantum Mechanics'),
    ('Geometry'),
    ('English');
INSERT INTO DepartmentLecture (department_id, lecture_id) VALUES
    (1, 1),  -- Mathematics Faculty, Algebra
    (2, 2),  -- Informatics Faculty, Computer Science Fundamentals
    (3, 3),  -- Physics Faculty, Quantum Mechanics
    (1, 4),  -- Mathematics Faculty, Geometry
    (3, 5),
    (2, 5),
    (1, 5);
INSERT INTO Student (student_name, department_id) VALUES
    ('John Doe', 1),
    ('Alice Johnson', 2),
    ('Bob Smith', 3),
    ('Ron Baton', 1),
    ('Harry Agurk', 3),
    ('Hagrid Car', 3),
    ('Snape Severus', 3);    
