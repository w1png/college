namespace Tasks {
  class Program {
    static void Main(string[] args) {
      int[] arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      int n = 4;
      Console.WriteLine("Task1:");
      Task1.Run(arr, n);
      Console.WriteLine("-----\n");

  
      Fruit[] fruits = new Fruit[10] {
        new Fruit("Apple", true),
        new Fruit("Orange", true),
        new Fruit("Banana", false),
        new Fruit("Pineapple", false),
        new Fruit("Lemon", true),
        new Fruit("Grapefruit", true),
        new Fruit("Grape", false),
        new Fruit("Strawberry", false),
        new Fruit("Watermelon", false),
        new Fruit("Peach", false)
      };

      Console.WriteLine("Task3:");
      Task2.Run(fruits);
      Console.WriteLine("-----\n");

      Console.WriteLine("Task4:");
      Task3.Run(fruits);
      Console.WriteLine("-----\n");
    }
  }
}
