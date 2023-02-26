namespace Tasks {
  class FruitValaidator {
    public static bool check1(Fruit fruit) {
      // return fruit.Name?[fruit.Name.Length - 1] == '8';
      return fruit.Name?.Length > 5;
    }

    public static bool check2(Fruit fruit) {
      return fruit.isCitrus;
    }

    public static bool check3(Fruit fruit) {
      return fruit.isCitrus && fruit.Name?.Length > 5;
    }
  }

  class Task3 {
    public static void Run(Fruit[] fruits) {
      fruits.AsParallel().Where(fruit => FruitValaidator.check1(fruit) && FruitValaidator.check2(fruit)).ToList().ForEach(fruit => Console.WriteLine(fruit.Name));

      fruits.AsParallel().Where(fruit => {
          return FruitValaidator.check1(fruit) && FruitValaidator.check2(fruit);
      }).ToList().ForEach(fruit => Console.WriteLine(fruit.Name));
    }
  }
}

