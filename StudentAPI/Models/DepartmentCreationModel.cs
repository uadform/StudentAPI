namespace StudentAPI.Models
{
    public class DepartmentCreationModel
    {
        public string DepartmentName { get; set; }
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }
    }
}
