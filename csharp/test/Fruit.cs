namespace Juicer {
  public class JuiceException : Exception {
    public JuiceException(string message) : base(message) { }
  }

  interface Juicer {
    void makeJuice(Fruit[] fruits);
  }

  class MyJuicer : Juicer {
    public void makeJuice(Fruit[] fruitArr) {
      if (fruitArr == null || fruitArr.Length == 0) {
        throw new JuiceException("No fruit to juice");
      }

      uint citrusTotal = 0;
      uint applesTotal = 0;

      foreach (Fruit fruit in fruitArr) {
        Console.WriteLine(fruit.toString());
        if (fruit is Citrus) {
          citrusTotal++;
        } else if (fruit is Apple) {
          applesTotal++;
        }
      }

      Console.WriteLine("Total: " + fruitArr.Length);
      Console.WriteLine("Total Citrus: " + citrusTotal);
    }
  }

  interface Fruit {
    string getName();
    string getColor();
    bool isCitrus();
    string toString();
  }

  abstract class Citrus : Fruit {
    public virtual string getName() {
      return "Citrus";
    }
    public virtual string getColor() {
      return "Orange";
    }
    public virtual bool isCitrus() {
      return true;
    }
    public virtual string toString() {
      return $"{getName()} is {getColor()} and is a Citrus";
    }
  }

  abstract class NotCitrus : Fruit {
    public virtual string getName() {
      return "Not Citrus";
    }
    public virtual string getColor() {
      return "Green";
    }
    public virtual bool isCitrus() {
      return false;
    }
    public virtual string toString() {
      return $"{getName()} is {getColor()} and is not a Citrus";
    }
  }

  class Lemon : Citrus {
    public override string getName() {
      return "Lemon";
    }
    public override string getColor() {
      return "Yellow";
    }
  }

  class Orange : Citrus {
    public override string getName() {
      return "Orange";
    }
    public override string getColor() {
      return "Orange";
    }
  }

  class Banana : NotCitrus {
    public override string getName() {
      return "Banana";
    }
    public override string getColor() {
      return "Yellow";
    }
  }

  class Apple : NotCitrus {
    public override string getName() {
      return "Apple";
    }
    public override string getColor() {
      return "Red";
    }
  }

  class Program {
    static void OldMain(string[] args) {
      Fruit[] fruitArr = new Fruit[] {
        new Lemon(),
        new Orange(),
        new Banana(),
        new Apple()
      };

      Juicer juicer = new MyJuicer();
      juicer.makeJuice(fruitArr);
    }
  }

}
