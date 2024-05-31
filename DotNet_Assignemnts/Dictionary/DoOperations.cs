namespace DotNet_Assignemnts.Dictionary;

public  class DoOperations
{
    static Operations obj = new Operations();
    static Dictionary<int, Student> Students = obj.Students;
    public static void AddProduct()
    {
        Student student = new Student();
        Console.WriteLine("Enter  Student Details");

        Console.Write("Student Name:");
        student.Name = Console.ReadLine();

        Console.Write("Student Standard:");
        student.Standard = Console.ReadLine();

        Console.Write("Student Section:");
        student.Section = Convert.ToChar(Console.ReadLine());

        Console.Write("Student Contact Number:");
        student.ContactNumber = Convert.ToInt32(Console.ReadLine());

        obj.AddStudent(student);
        Console.WriteLine("Dettails are Added ");
        Console.WriteLine();
    }

    public static void DeleteProduct()
    {
        Console.WriteLine("Enter The Id Of the Student");
        int id = Convert.ToInt32(Console.ReadLine());
        obj.RemoveStudentUsingKey(id);
    }

    public static void UpdateProduct()
    {
        Console.WriteLine("Enter Student Id To Update");
        int Id = Convert.ToInt32(Console.ReadLine());

        Student student = new Student();
        Console.WriteLine("Enter  Student Details");

        Console.Write("Student Name:");
        student.Name = Console.ReadLine();

        Console.Write("Student Standard:");
        student.Standard = Console.ReadLine();

        Console.Write("Student Section:");
        student.Section = Convert.ToChar(Console.ReadLine());

        Console.Write("Student Contact Number:");
        student.ContactNumber = Convert.ToInt32(Console.ReadLine());

        obj.UpdateStudent(Id, student);
        Console.WriteLine("Dettails are Added ");
        Console.WriteLine();
    }

    public static void DisplayProduct()
    {
        Console.Write("Enter Id of the Student:");
        int id = Convert.ToInt32(Console.ReadLine());
        foreach (int key in Students.Keys)
        {
            if (key == id)
            {
                Console.WriteLine("ID = {0}", key);
                Console.WriteLine("Name = {0}", Students[key].Name);
                Console.WriteLine("Standard = {0}", Students[key].Standard);
                Console.WriteLine("Section = {0}", Students[key].Section);
                Console.WriteLine("Product Number = {0}", Students[key].ContactNumber);
                Console.WriteLine();
            }
        }
    }

    public static void DisplayProducts()
    {
        Console.WriteLine(obj.DisplayStudents());
    }
}
