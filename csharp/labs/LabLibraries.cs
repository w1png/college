namespace Labs {
  class LabLibraries {
    public static void SortAsc(ref int[] arr) {
      for (int i = 0; i < arr.Length; i++) {
        for (int j = i + 1; j < arr.Length; j++) {
          if (arr[i] > arr[j]) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
          }
        }
      }
    }

    public static int Factorial() {
      Console.Write("Введите число: ");
      int n = int.TryParse(Console.ReadLine(), out n) ? n : 0;
      if (n < 0) {
        throw new Exception("Число должно быть положительным");
      }
      int result = 1;
      for (int i = 1; i <= n; i++) {
        result *= i;
      }
      return result;
    }

    public static int EvenOddSum(int[] arr) {
      int evenSum = 0;
      int oddSum = 0;
      foreach (int i in arr) {
        if (i % 2 == 0) {
          evenSum += i;
        } else {
          oddSum += i;
        }
      }

      if (evenSum > oddSum) {
        return arr[0] + arr[arr.Length - 1];
      }
      return arr[0] - arr[arr.Length - 1];
    }
    
    public static void Run() {
      int[] arr = new int[10];
      for (int i = 0; i < arr.Length; i++) {
        arr[i] = i + 1;
      }

      Console.WriteLine("1. Сортировка массива по возрастанию");
      SortAsc(ref arr);
      foreach (int i in arr) {
        Console.Write(i + " ");
      }
      Console.WriteLine("\n----");

      Console.WriteLine("2. Факториал числа");
      Console.WriteLine(Factorial());
      Console.WriteLine("----");

      Console.WriteLine("3. Сумма четных и нечетных элементов массива");
      Console.WriteLine(EvenOddSum(arr));
    }
  }
}
