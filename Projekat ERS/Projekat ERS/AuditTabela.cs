using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace Projekat_ERS
{
    // ova klasa je pokusaj preko SQL
    class AuditTabela
    {

        public static void Audit()
        {
            string connectionString = "Data Source=ERS;User Id=pr1422021;Password=ftn;";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to Oracle database!");

                    // Perform database operations here

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}

