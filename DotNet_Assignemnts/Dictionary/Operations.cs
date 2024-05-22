using System.Text;
namespace DotNet_Assignemnts.Dictionary;

public  class Operations
{
    private static int InitialId = 101;
    public Dictionary<int, Student> Students = new Dictionary<int, Student>()
{
    { InitialId,new Student{Name = "Bala",Standard = "Fifth",Section = 'C',ContactNumber = 987987} }
};
    public void AddStudent(Student student)
    {
        Students.Add(++InitialId, student);
    }
    public void RemoveStudentUsingKey(int key)
    {
        Students.Remove(key);
    }
    public void UpdateStudent(int Id, Student student)
    {
        Students[Id] = student;
    }
    public string DisplayStudents()
    {
        StringBuilder sb = new StringBuilder();
        foreach (int key in Students.Keys)
        {
            sb.AppendFormat("Id = {0}{1}", key, Environment.NewLine);
            sb.AppendFormat("Student Name = {0}{1}", Students[key].Name, Environment.NewLine);
            sb.AppendFormat("Student Standard = {0}{1}", Students[key].Standard, Environment.NewLine);
            sb.AppendFormat("Student Section = {0}{1}", Students[key].Section, Environment.NewLine);
            sb.AppendFormat("Student ContactNumber = {0}{1}", Students[key].ContactNumber, Environment.NewLine);

        }
        return sb.ToString();
    }
}
