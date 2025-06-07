
         using System;
         using System.Collections.Generic;
         using System.Linq; 
         using System.Text;
         using System.Data.SqlClient;
         using System.Threading.Tasks;
         namespace DataAccess_BanksysDB
         {
            public class clsPersons
             {
      
        public static int AddNewPersons(string FirstName, string LastName, string Email)
      
        {
          int PersonID= -1;
          SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
          string query = @"INSERT INTO Persons
         (FirstName, LastName, Email)
   VALUES
         (@FirstName, @LastName, @Email)
        select SCOPE_IDENTITY();";
          SqlCommand command= new SqlCommand(query, connection);
          command.Parameters.AddWithValue("FirstName",FirstName);
command.Parameters.AddWithValue("LastName",LastName);
command.Parameters.AddWithValue("Email",Email);
          try
          {
              connection.Open();
              object result = command.ExecuteScalar();
              if (result != null && int.TryParse(result.ToString(), out int InsertedID))
              {
                  PersonID= InsertedID;
              }
          }
          catch (Exception ex)
          {
              Console.WriteLine("Error " + ex.ToString());
          }
          finally { connection.Close(); }
          return PersonID;


      }       
        public static bool UpdatePersons(int PersonID, string FirstName, string LastName, string Email)
       {
           int result = 0;
           SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionstring);
           string query = @"UPDATE Persons
  SET FirstName = @FirstName, LastName = @LastName, Email = @Email
WHERE PersonID=@PersonID";
           SqlCommand command=new SqlCommand(query, connection);
           command.Parameters.AddWithValue("FirstName",FirstName);
command.Parameters.AddWithValue("LastName",LastName);
command.Parameters.AddWithValue("Email",Email);
           try
           {
               connection.Open();
               result = command.ExecuteNonQuery();
           }
           catch (Exception ex) { Console.WriteLine("Error " + ex.ToString()); }
           finally { connection.Close(); }
           return result > 0;
       }

}