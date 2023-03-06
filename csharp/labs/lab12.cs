namespace Labs {
  class Lab12 {
    public static void Run() {
      string text = "Tesla is a cryptocurrency.";
      Console.WriteLine(text);
      text = text.Replace("Tesla", "Bitcoin");
      Console.WriteLine(text + "\n");

      text = "«Видеокарта – компонент архитектуры современного ПК, отвечает за преобразование графической информации в видеосигнал для монитора. Видеокарта представляет собой плату расширения, которая устанавливается в специальный слот (PCI-Express) материнской платы/».";
      string[] words = text.Split(' ');
      Console.Write(words[23] + " ");
      Console.Write(words[24] + " ");
      Console.WriteLine(words[25] + "\n");

      text = "MoiSeev, ToMatin, RogAchev, lvaNov";
      words = text.Split(", ");
      for (int i = 0; i < words.Length; i++) {
        words[i] = words[i].ToLower();
        Console.WriteLine(words[i]);
      }
      Console.WriteLine("\n");

      string s1 = "C# Лучший язык программирования";
      string s2 = "но С++ тоже крутой язык программирования";
      Console.WriteLine(s1 + " " + s2);
    }
  }
}
