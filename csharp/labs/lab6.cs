namespace Labs {
  public static class Extensions {
    public static void PrintColor(this Color color) {
      string colorName;
      switch (color) {
        case Color.Red: colorName = "Красный"; break;
        case Color.Orange: colorName = "Оранжевый"; break;
        case Color.Yellow: colorName = "Желтый"; break;
        case Color.Green: colorName = "Зеленый"; break;
        case Color.Cyan: colorName = "Голубой"; break;
        case Color.Blue: colorName = "Синий"; break;
        default: colorName = "Неизвестный"; break;
      }
      Console.Write(colorName);
    }
  }
  public enum Color { Red, Orange, Yellow, Green, Cyan, Blue };

  class Lab6 {
    static void PrintColor(Color[] arr) {
      foreach (var color in arr) {
        color.PrintColor();
        Console.Write(" ");
      }
      Console.WriteLine();
    }

    public static void Run() {
      Color[] colors = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Cyan };
      colors[0].PrintColor();
      Console.WriteLine("\n-------");

      PrintColor(colors);
      Console.WriteLine("-------");

      Console.Write("Y/N: ");
      ConsoleKeyInfo key = Console.ReadKey();
      Console.WriteLine();

      int startIndex = 0;
      if (key.Key == ConsoleKey.N) {
        startIndex = 1;
      }

      for (int i = startIndex; i < Enum.GetNames(typeof(Color)).Length; i += 2) {
        ((Color)i).PrintColor();
        Console.Write(" ");
      }
      Console.WriteLine();
    }
  }
}
