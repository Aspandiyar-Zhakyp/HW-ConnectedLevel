using HW_ADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ADO.NET.Data
{
    public class GuestDataAccess : DbDataAccess<Guest>
    {
        public override ICollection<Guest> Select(string select)
        {
            var selectSqlScript = select;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var guest = new List<Guest>();

            // до тех пор есть, что читать - читай
            while (dataReader.Read())
            {
                guest.Add(new Guest
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                });
            }

            dataReader.Close();
            command.Dispose();

            return guest;
        }
    }
}
