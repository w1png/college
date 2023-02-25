using System.Data.SQLite;


namespace Accounts {

  struct Account {
    public int user_id;
    public string username;
    public string password;
    public string email;
    public string created_at;
    public string last_login;
  }

  public class SecurityService {
    // db stuff
    private const string database_filename = "database.db";
    private const string ACCOUNTS_TABLE = @"CREATE TABLE IF NOT EXISTS accounts (
      user_id INTEGER PRIMARY KEY,
      username TEXT UNIQUE NOT NULL,
      password TEXT NOT NULL,
      email TEXT UNIQUE NOT NULL,
      created_at TEXT NOT NULL,
      last_login TEXT NOT NULL
    )";
    private static SQLiteConnection connection = new SQLiteConnection($"Data Source={database_filename};Version=3;");
    private static SQLiteCommand command = new SQLiteCommand(connection);

    private static void InitDatabase() {
      connection.Open();
      command.CommandText = ACCOUNTS_TABLE;
      command.ExecuteNonQuery();
      connection.Close();
    }

    // securityservice is a singleton
    
    private static SecurityService instance;

    public static SecurityService Instance {
      get {
        if (instance == null) {
          instance = new SecurityService();
          InitDatabase();
        }
        return instance;
      }
    }


  }

  

  class Program {
    static void Main(string[] args) {

    }
  }
}
