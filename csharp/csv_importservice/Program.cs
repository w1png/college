using Microsoft.Data.Sqlite;

namespace ImportServiceNamespace {
  public struct Product {
    public int product_id;
    public string code;
    public string product_name;
    public float price;
    public DateTime creation_date;
  }

  public class Database {
    private static string PRODUCTS_TABLE = @"CREATE TABLE IF NOT EXISTS products (
      product_id INTEGER PRIMARY KEY,
      code TEXT NOT NULL UNIQUE,
      product_name TEXT NOT NULL UNIQUE,
      price REAL NOT NULL,
      created_at TEXT NOT NULL
    )";
    

    private static void Init() {
      using (var connection = new SqliteConnection("Data Source=products.db")) {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = PRODUCTS_TABLE;
        command.ExecuteNonQuery();
      }
    }

    public Database() {
      Init();
    }

    public async Task<bool> DoesProductExist(Product product) {
      using (var connection = new SqliteConnection("Data Source=products.db")) {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM products WHERE code = @code";
        command.Parameters.AddWithValue("@code", product.code);
        var result = await command.ExecuteScalarAsync();
        return (long)result > 0;
      }
    }

    public async Task CreateProduct(Product product) {
      using (var connection = new SqliteConnection("Data Source=products.db")) {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO products (code, product_name, price, created_at) VALUES (@code, @product_name, @price, @created_at)";
        command.Parameters.AddWithValue("@code", product.code);
        command.Parameters.AddWithValue("@product_name", product.product_name);
        command.Parameters.AddWithValue("@price", product.price);
        command.Parameters.AddWithValue("@created_at", product.creation_date.ToString("yyyy-MM-dd HH:mm:ss"));
        await command.ExecuteNonQueryAsync();
      }
    }

    public async Task UpdateProduct(Product product) {
      using (var connection = new SqliteConnection("Data Source=products.db")) {
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "UPDATE products SET product_name = @product_name, price = @price WHERE code = @code";
        command.Parameters.AddWithValue("@code", product.code);
        command.Parameters.AddWithValue("@product_name", product.product_name);
        command.Parameters.AddWithValue("@price", product.price);
        await command.ExecuteNonQueryAsync();
      }
    }
  }

  public class ImportService {
    private string[] dirPaths;
    private string fileExt;
    private Database db = new Database();

    public ImportService(string[] dirPaths, string fileExt) {
      this.dirPaths = dirPaths;
      this.fileExt = fileExt;
    }

    public async void Run() {
      List<Task> tasks = new List<Task>();

      foreach (var dirPath in dirPaths) {
        await ImportTask(dirPath, fileExt);
      }
    }

    private async Task ImportTask(string dirPath, string fileExt) {
      int start_time = Environment.TickCount;
      var files = Directory.GetFiles(dirPath).Where(f => f.EndsWith(fileExt));

      foreach (string file in Directory.GetFiles(dirPath).Where(f => f.EndsWith(fileExt))) {
        List<Task> tasks = new List<Task>();
        
        using (StreamReader reader = new StreamReader(file)) {
          string line;

          while ((line = reader.ReadLine()) != null) {
            string[] productData = line.Split(',');
            Product product = new Product {
              code = productData[0],
              product_name = productData[1],
              price = int.Parse(productData[2]),
              creation_date = DateTime.Now
            };

            if (await db.DoesProductExist(product)) {
              Console.WriteLine("Updating product");
              tasks.Add(db.UpdateProduct(product));
              continue;
            }
            tasks.Add(db.CreateProduct(product));
          }
        }
        await Task.WhenAll(tasks);
        Console.WriteLine("Imported file {0} in {1} ms", file, Environment.TickCount - start_time);
      }
    }
  }

  public class Program {
    public static void CreateDebugData(string[] dirPaths, string[] fileExts) {
      
      foreach(var dirPath in dirPaths) {
        Directory.CreateDirectory(dirPath);
        foreach(var fileExt in fileExts) {
          using (StreamWriter writer = new StreamWriter(dirPath + "/a" + fileExt)) {
            writer.WriteLine("apple,Яблоко,100");
            writer.WriteLine("orange,Апельсин,200");
            writer.WriteLine("banana,Банан,300");
            writer.WriteLine("pineapple,Ананас,400");
            writer.WriteLine("apple,Яблоко,10");
          }
        }
        
      }

    }

    public static void Main(string[] args) {
      string[] dirPaths = new string[] { "alley1", "alley2", "alley3" };
      string[] fileExts = new string[] { ".fruit", ".vegetables", ".meat" };

      if (!Directory.Exists("fruit")) {
        CreateDebugData(dirPaths, fileExts);
      }

      ImportService importService = new ImportService(dirPaths, ".meat");
      importService.Run();
    }
  }
}
