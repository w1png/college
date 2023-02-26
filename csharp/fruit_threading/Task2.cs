namespace Tasks {
  class Fruit {
    public string? Name { get; set; }
    public bool isCitrus { get; set; }

    public Fruit(string name, bool isCitrus) {
      this.Name = name;
      this.isCitrus = isCitrus;
    }
  }

  class Task2 {
    public static void PrintCitrus(Fruit[] fruits) {
      Parallel.ForEach(fruits, fruit => {
        if (fruit.isCitrus) {
          Console.WriteLine(fruit.Name);
        }
      });
    }

    public static List<Fruit> GetCitrus(Fruit[] fruits) {
      List<Fruit> citrus = new List<Fruit>();

      Parallel.ForEach(fruits, (fruit) => {
        if (fruit.isCitrus) {
          lock (citrus) {
            citrus.Add(fruit);
          }
        }
      });

      return citrus;
    }

    public static void Run(Fruit[] fruits) {
      PrintCitrus(fruits);
      List<Fruit> citrus = GetCitrus(fruits);
      foreach (Fruit fruit in citrus) {
        Console.WriteLine(fruit.Name);
      }
    }
  }
}
