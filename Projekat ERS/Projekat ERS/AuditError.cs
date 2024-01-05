using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace Projekat_ERS
{
    class AuditError
    {
        public static void LogErrorToOracleAudit(string errorMessage)
        {
            string connectionString = "Data Source=ERS;User Id=pr1422021;Password=ftn;";
            string tableName = "AuditLog"; // Replace with your Audit table name

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                string sql = $"INSERT INTO {tableName} (AuditLogId, TableName, Action, DateTimeStamp, UserName, OldValue, NewValue) " +
                             $"VALUES (audit_log_seq.NEXTVAL, 'ErrorLog', 'ERROR', SYSTIMESTAMP, USER, '{errorMessage}', '{errorMessage}')";

                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Error logged to Audit table. Rows affected: {rowsAffected}");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error logging to Audit table: {ex.Message}");
                }
            }
    }
}
}
