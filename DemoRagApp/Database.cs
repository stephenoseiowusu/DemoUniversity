using System;

public class Database
{
    private static SqlConnection conn;
	public Database()
	{

	}
    private static String GetConnectionString()
    {
        return "Data Source=throwawaydb.cacbbedpgsnb.us-east-1.rds.amazonaws.com,1433;Initial Catalog=bears;Persist Security Info=True;User ID=master;Password=lolmaster";
    }
    /// <summary>
    /// returns 0 if success 
    /// returns 1 if failue 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static int login(String username, String password,int which)
    {
      String query = which  == 1 ? "Select username from students where username = @username and password = @password" : "select username from admin where username = @username and password = @password";
      Initialize();
      SqlCommand command = new SqlCommand(query);
      //command.Parameters.Add(new S)
      conn.close();
    }
    public static void Initialize()
    {
        try
        {
            conn = new SqlConnection();
            conn.ConnectionString = GetConnectionString();
            conn.open();
        }
        catch()
        {

        }
    }
}
