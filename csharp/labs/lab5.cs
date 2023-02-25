namespace Labs {
  class Lab5 {
    static void Nom1(out double n, double[] arr) {
      n = 0;
      foreach (double i in arr) {
        if (i > 0) {
          n = i;
          return;
        }
      }
    }

    static void Nom2(ref double n, double[] arr) {
      double sum = 0;
      for (int i = (int)n; i < arr.Length; i++) {
        sum += arr[i];
      }

      n = sum / arr.Length;
    }

    public static void Run() {
      Console.WriteLine("nom1: ");
      double n = 0;
      double[] arr = new double[10];
      Random rand = new Random();
      for (int i = 0; i < arr.Length; i++) {
        arr[i] = rand.Next(-10, 10);
        Console.WriteLine("{0}: {1} ", i, arr[i]);
      }
      Console.WriteLine("-----");
      Nom1(out n, arr);
      Console.WriteLine(n);

      Console.Write("\nnom2: ");
      n = Convert.ToDouble(Console.ReadLine());
      Nom2(ref n, arr);
      Console.WriteLine(n);
    }
  }
}
