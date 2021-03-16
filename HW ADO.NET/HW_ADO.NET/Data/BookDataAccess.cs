using HW_ADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ADO.NET.Data
{
    public class BookDataAccess : DbDataAccess<Books>
    {
        public override ICollection<Books> Select(string select)
        {
            var selectSqlScript = select;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var book = new List<Books>();

            // до тех пор есть, что читать - читай
            while (dataReader.Read())
            {
                book.Add(new Books
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                });
            }

            dataReader.Close();
            command.Dispose();

            return book;
        }
    }
}
