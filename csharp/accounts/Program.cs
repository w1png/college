using Microsoft.Data.Sqlite;
using System.Security.Cryptography;
using System.Text;


namespace Accounts {
  public class AuthException : Exception {
    public AuthException(string message) : base(message) {}
  }

  class SecurityService {
    private string HashPassword(string password) {
      var sha256 = SHA256.Create();
      var bytes = Encoding.UTF8.GetBytes(password);
      var hash = sha256.ComputeHash(bytes);

      return Convert.ToBase64String(hash);
    }

    private const string ACCOUNTS_DB = @"CREATE TABLE IF NOT EXISTS accounts (
      user_id INTEGER PRIMARY KEY,
      username TEXT UNIQUE NOT NULL,
      password TEXT NOT NULL,
      email TEXT UNIQUE NOT NULL,
      created_on DATETIME NOT NULL,
      last_login DATETIME
    );";

    private void InitDatabase() {
      using (var connection = new SqliteConnection("Data Source=database.db")) {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = ACCOUNTS_DB;
        command.ExecuteNonQuery();

        command.CommandText = @"INSERT INTO accounts (username, password, email, created_on, last_login)
          VALUES ('admin', @password, 'admin@localhost', @created_on, NULL);";
        command.Parameters.AddWithValue("@password", HashPassword("root"));
        command.Parameters.AddWithValue("@created_on", DateTime.Now);
        command.ExecuteNonQuery();
      }
    }

    private static SecurityService instance;
    public static SecurityService GetInstance {
      get {
        if (instance == null) {
          instance = new SecurityService();
          if (!File.Exists("database.db")) {
            instance.InitDatabase();
          }
        }

        return instance;
      }
    }

    public void Authenticate(string username, string password) {
      using (var connection = new SqliteConnection("Data Source=database.db")) {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM accounts WHERE username = @username AND password = @password;";
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", HashPassword(password));

        using (var reader = command.ExecuteReader()) {
          if (!reader.HasRows) {
            throw new AuthException("Неправильный логин или пароль.");
          }

          reader.Read();
          int userId = reader.GetInt32(0);
          reader.Close();

          command.CommandText = @"UPDATE accounts SET last_login = @last_login WHERE user_id = @user_id;";
          command.Parameters.AddWithValue("@last_login", DateTime.Now);
          command.Parameters.AddWithValue("@user_id", userId);
          command.ExecuteNonQuery();
        }
      }
    }
  }

  class Program {
    static string ReadPassword() {
      var password = new StringBuilder();

      ConsoleKeyInfo keyInfo;
      ConsoleKey key;
      char keyChar;
      while (true) {
        keyInfo = Console.ReadKey(true);
        key = keyInfo.Key;
        keyChar = keyInfo.KeyChar;

        if (key == ConsoleKey.Enter) {
          break;
        }
        if (keyChar == '\u0000') {
          continue;
        }

        if (key == ConsoleKey.Backspace) {
          if (password.Length > 0) {
            password.Remove(password.Length - 1, 1);
            Console.Write("\b \b");
          }
          continue;
        } 

        password.Append(keyChar);
        Console.Write("*");
      } 
      return password.ToString();
    }

    static void Main(string[] args) {
      while (true) {
        Console.Clear();
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = ReadPassword();
        Console.WriteLine();

        if (username == null || password == null) {
          Console.WriteLine("Пароль или логин не могут быть пустыми.");
          continue;
        }

        try {
          SecurityService.GetInstance.Authenticate(username, password);
          Console.WriteLine("Вы успешно авторизовались.");
        } catch (AuthException e) {
          Console.WriteLine(e.Message);
        }
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
      }
    }
  }
}
