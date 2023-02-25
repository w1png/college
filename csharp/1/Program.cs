namespace ConsoleApplication {
  class Program {

    static void problem1() {
      for (int i = 1; i <= 20; i++) {
        Console.WriteLine(i*3);
      }
    }

    static void problem2() {
      string input = "";
      while (input != "123admin") {
        if (input != "") {
          Console.WriteLine("Пароль неверный");
        }
        Console.Write("Enter password: ");
        input = Console.ReadLine();
      }
      Console.WriteLine("Пароль правильный");
    }

    static void problem3() {
      int[][] matrix1 = new int[4][];
      int[][] matrix2 = new int[4][];

      for (int i = 0; i < 4; i++) {
        matrix1[i] = new int[4];
        matrix2[i] = new int[4];
        for (int j = 0; j < 4; j++) {
          matrix1[i][j] = i*4 + j + 1;
          matrix2[i][j] = 16 - i*4 - j;
        }
      }

      int[][] resultMatrix = new int[4][];
      for (int i = 0; i < 4; i++) {
        resultMatrix[i] = new int[4];
        for (int j = 0; j < 4; j++) {
          resultMatrix[i][j] = matrix1[i][j] + matrix2[i][j];
        }
      }

      for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
          Console.Write("{0, 4}", resultMatrix[i][j]);
        }
        Console.WriteLine();
      }

    }

    static void Main(string[] args) {
      problem3();
    }

  }
}
