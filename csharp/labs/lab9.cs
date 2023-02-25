namespace Labs {
  class Lab9 {
    static int ArrCalc(int[] arr) {
      int sum = 0;
      ConsoleKey key = Console.ReadKey().Key;
      Console.WriteLine();
      if (key == ConsoleKey.D3) {
        return arr.Max();
      }

      foreach (int i in arr) {
        sum += i;
      }
      if (key == ConsoleKey.D1) {
        return sum;
      } 
      if (key == ConsoleKey.D2) {
        return sum / arr.Length;
      }

      throw new Exception("Неверный ввод");
    }

    public static void Run() {
      int[] arr = new int[10];
      for (int i = 0; i < arr.Length; i++) {
        arr[i] = i + 1;
      }

      Console.WriteLine("1. Сумма элементов массива");
      Console.WriteLine("2. Среднее арифметическое элементов массива");
      Console.WriteLine("3. Максимальный элемент массива");
      while(true) {
        Console.Write("Введите номер операции: ");
        int result = ArrCalc(arr);
        Console.WriteLine(result);
      }
    }
  }
}
