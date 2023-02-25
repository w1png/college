namespace Lab1 {
  class Program {
    static int[] replaceNums(int[] arr, int num, int replaceWith) {
      for (int i = 0; i < arr.Length; i++) {
        if (arr[i] == num) {
          arr[i] = replaceWith;
        }
      }
      return arr;
    }

    static int[] replaceNegative(int[] arr, int num) {
      for (int i = 0; i < arr.Length; i++) {
        if (arr[i] == num) {
          arr[i] = -num;
        }
      }
      return arr;
    }

    static int max4(int n1, int n2, int n3, int n4) {
      int max = n1;
      if (n2 > max) {
        max = n2;
      }
      if (n3 > max) {
        max = n3;
      }
      if (n4 > max) {
        max = n4;
      }
      return max;
    }

    static int min5(int n1, int n2, int n3, int n4, int n5) {
      int min = n1;
      if (n2 < min) {
        min = n2;
      }
      if (n3 < min) {
        min = n3;
      }
      if (n4 < min) {
        min = n4;
      }
      if (n5 < min) {
        min = n5;
      }
      return min;
    }

    static int fibonnaci(int n) {
      int count = 2;
      int n1 = 1;
      int n2 = 1;

      while (count <= n) {
        int temp = n1;
        n1 = n2;
        n2 = temp + n2;
        count++;
      }

      return n1;
    }

    static void Main(string[] args) {
      // 1
      int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      int num = 2;
      int replaceWith = 33;
      int[] newArr = replaceNums(arr, num, replaceWith);
      foreach (int i in newArr) {
        Console.WriteLine(i);
      }
      Console.WriteLine("------");


      // 2
      int[] arr2 = { 1, 2, 3, 4, 5, 6, 22, 8, 9 };
      int num2 = 22;
      int[] newArr2 = replaceNegative(arr2, num2);
      foreach (int i in newArr2) {
        Console.WriteLine(i);
      }
      Console.WriteLine("------");


      // 3
      int n1 = 1;
      int n2 = 2;
      int n3 = 3;
      int n4 = 4;
      int maxNum = max4(n1, n2, n3, n4);
      Console.WriteLine(maxNum);
      Console.WriteLine("------");


      // 4
      int n5 = 5;
      int maxNum2 = min5(n1, n2, n3, n4, n5);
      Console.WriteLine(maxNum2);
      Console.WriteLine("------");


      // 5
      int n = 5;
      int fibNum = fibonnaci(n);
      Console.WriteLine(fibNum);
      Console.WriteLine("------");
    }
  }
}
