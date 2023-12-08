-- Index on the primary key
CREATE INDEX idx_student_id ON Student (student_id);

-- Index on the foreign key
CREATE INDEX idx_student_department_id ON Student (department_id);

-- Index on the primary key
CREATE INDEX idx_lecture_id ON Lecture (lecture_id);

-- Index on the foreign keys
CREATE INDEX idx_department_lecture_department_id ON DepartmentLecture (department_id);
CREATE INDEX idx_department_lecture_lecture_id ON DepartmentLecture (lecture_id);

-- Index on the primary key
CREATE INDEX idx_department_id ON Department (department_id);

