using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControls
{
    //public class CompletedCheck
    //{
    //    public bool LoadResult(int studId, int exId)
    //    {
    //        bool completed;

    //        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DiplomUsers;Integrated Security=True";
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();
    //            SqlCommand command = new SqlCommand();
    //            command.CommandText = "SELECT * FROM Results WHERE [ID_Stud] = '" + studId + "' AND [ID_Ex] = '" + exId + "';";
    //            command.Connection = connection;
    //            SqlDataReader reader = command.ExecuteReader();

    //            if (reader.HasRows) // если запрос нашёл записи
    //            {
    //                completed = true;
    //            }
    //            else
    //            {
    //                completed = false;
    //            }

    //            reader.Close();

    //        }
    //        return completed;
    //    }
    //}
}
