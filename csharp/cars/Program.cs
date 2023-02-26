namespace Test {
  enum Color {
    Red,
    Green,
    Blue,
    Yellow,
    Purple,
  }

  class Engine {
    public string Name { get; }
    public double Power { get; }

    public Engine(string name, double power) {
      Name = name;
      Power = power;
    }
  }

  class Car {
    public string Brand { get; }
    public Color Color { get; set; }
    public uint Mass { get; }
    public uint Speed { get; set; }
    public Engine Engine { get; }

    public Car(string brand, Color color, uint mass, uint speed, Engine engine) {
      Brand = brand;
      Color = color;
      Mass = mass;
      Speed = speed;
      Engine = engine;
    }

    public void Print() {
      Console.WriteLine($"Brand: {Brand}");
      Console.WriteLine($"Color: {Color}");
      Console.WriteLine($"Mass: {Mass}");
      Console.WriteLine($"Speed: {Speed}");
      Console.WriteLine($"Engine Power: {Engine.Power}");
    }
  }

  class Program {
    public static Car getFastestCar(Car[] cars) {
      if (cars.Length == 0) {
        throw new Exception("No cars");
      }

      Car fastestCar = cars[0];
      uint maxSpeed = 0;

      foreach (Car car in cars) {
        if (car.Speed > maxSpeed) {
          fastestCar = car;
          maxSpeed = car.Speed;
        }
      }

      return fastestCar;
    }

    static void Main(string[] args) {
      Car[] cars = new Car[3];
      cars[0] = new Car("BMW", Color.Red, 1500, 200, new Engine("V8", 300));
      cars[1] = new Car("Audi", Color.Green, 1400, 250, new Engine("V6", 250));
      cars[2] = new Car("Mercedes", Color.Blue, 1600, 220, new Engine("V8", 300));

      Car fastestCar = getFastestCar(cars);
      fastestCar.Print();
    }
  }
}
