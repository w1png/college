using System;
using System.Threading.Tasks;
using System.IO;

namespace Tasks {
  class Task1 {
    public static void EvenStream(int[] arr) {
      byte[] barr = new byte[arr.Length * sizeof(int)];
      Buffer.BlockCopy(arr, 0, barr, 0, barr.Length);

      using (MemoryStream ms = new MemoryStream(barr)) {
        using (BinaryReader br = new BinaryReader(ms)) {
          while (ms.Position < ms.Length) {
            int i = br.ReadInt32();
            if (i % 2 == 0) {
              Console.WriteLine(i);
            }
          }
        }
      }
    }

    public static void EvenParallel(int[] arr) {
      Parallel.ForEach(arr, i => {
        if (i % 2 == 0) {
          Console.WriteLine(i);
        }
      });
    }


    public static void EvenAndLargerStream(int[] arr, int n) {
      byte[] barr = new byte[arr.Length * sizeof(int)];
      Buffer.BlockCopy(arr, 0, barr, 0, barr.Length);

      using (MemoryStream ms = new MemoryStream(barr)) {
        using (BinaryReader br = new BinaryReader(ms)) {
          while (ms.Position < ms.Length) {
            int i = br.ReadInt32();
            if (i % 2 == 0 && i > n) {
              Console.WriteLine(i);
            }
          }
        }
      }
    }

    public static void EvenAndLargerParallel(int[] arr, int n) {
      Parallel.ForEach(arr, i => {
        if (i % 2 == 0 && i > n) {
          Console.WriteLine(i);
        }
      });
    }

    public static void Run(int[] arr, int n) {
      Console.WriteLine("Stream:");
      Task[] tasks = new Task[10];
      for (int i = 0; i < 10; i++) {
        tasks[i] = Task.Run(() => EvenAndLargerStream(arr, n));
      }
      Task.WaitAll(tasks);

      Console.WriteLine("----\nParallel:");
      for (int i = 0; i < 10; i++) {
        tasks[i] = Task.Run(() => EvenParallel(arr));
      }
      Task.WaitAll(tasks);
    }
  }
}
