namespace Labs {
  public class Student {
    public string? firstName;
    public string? lastName;
    public int age;
    public string? group;

    public static Student GetStudent() {
      Student student = new Student();
      Console.Write("Имя: ");
      student.firstName = Console.ReadLine();
      Console.Write("Фамилия: ");
      student.lastName = Console.ReadLine();
      Console.Write("Возраст: ");
      student.age = int.TryParse(Console.ReadLine(), out int age) ? age : 0;
      Console.Write("Группа: ");
      student.group = Console.ReadLine();
      return student;
    }

    public static void Print(Student s) {
      Console.WriteLine("Имя: " + s.firstName);
      Console.WriteLine("Фамилия: " + s.lastName);
      Console.WriteLine("Возраст: " + s.age);
      Console.WriteLine("Группа: " + s.group);
    }
  }

  class Lab7 {
    static void PrintAdults(Student[] students) {
      foreach (var student in students.Where(s => s.age >= 18)) {
        Student.Print(student);
        Console.WriteLine();
      }
    }

    public static void Run() {
      Student[] arr = new Student[3];
      for (int i = 0; i < arr.Length; i++) {
        arr[i] = Student.GetStudent();
        Console.WriteLine();
      }
      Console.WriteLine("-------");

      PrintAdults(arr);
    }
  }
}
