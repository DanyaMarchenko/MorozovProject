using System;
using MySql.Data.MySqlClient;

namespace registration
{
    public class Program
    {
        public static void RagisterNewUser(User user, MySqlConnection connection)
        {
            DateTime thisDay = DateTime.Now;
            string dateAndTime = $"{thisDay.Year}-{thisDay.Month}-{thisDay.Day} {thisDay.Hour}:{thisDay.Minute}:{thisDay.Second}";
         
            try
            {
                string query = $"INSERT INTO users (name, surname, createdAt, modifiedAt) VALUES ('{user.name}', '{user.surname}', '{dateAndTime}', '{dateAndTime}')";
            
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    
        public static void Main()
        {
    
            string connStr = "server=localhost;user=root;database=danya;port=3306;password=Danya33430161";
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
                Console.WriteLine("Successfully connected to database.");
            
                Console.Write("Write name: ");
                string name = Console.ReadLine();
                Console.Write("Write surname: ");
                string surname = Console.ReadLine();

                User user = new User(name, surname);
                
                RagisterNewUser(user, connection);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("Done.");
            connection.Close();
        }
    }
}