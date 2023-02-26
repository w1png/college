using System.Linq;

namespace Test {
  class Program {
    static int[] GetDistinct(int[] array) {
      int[] result = new int[array.Length];
      int count = 0;
      for (int i = 0; i < array.Length; i++) {
        if (!result.Contains(array[i])) {
          result[count] = array[i];
          count++;
        }
      }

      return result.Take(count).ToArray();
    }

    static int[] Reverse(int[] array) {
      int[] result = new int[array.Length];

      for (int i = 0; i < array.Length; i++) {
        result[i] = array[array.Length - i - 1];
      }

      return result;
    }

    static void Main(string[] args) {
      int[] numbers = new int[Convert.ToInt32(Console.ReadLine())];
      for(int i = 0; i < numbers.Length; i++) {
        numbers[i] = Convert.ToInt32(Console.ReadLine());
      }

      Console.WriteLine("Distinct:");
      int[] distinct = GetDistinct(numbers);
      foreach (int number in distinct) {
        Console.WriteLine(number);
      }
      Console.WriteLine();

      Console.WriteLine("Reverse:");
      int[] reversed = Reverse(distinct);
      foreach (int number in reversed) {
        Console.WriteLine(number);
      }
      Console.WriteLine();

      int[][] arr = new int[4][];
      for (int i= 0; i < arr.Length; i++) {
        arr[i] = new int[Convert.ToInt32(Console.ReadLine())];
        for (int j = 0; j < arr[i].Length; j++) {
          arr[i][j] = Convert.ToInt32(Console.ReadLine());
        }
      }

      Console.WriteLine("Arr max:");
      Console.WriteLine(arr.SelectMany(x => x).Max());

    }
  }


}
