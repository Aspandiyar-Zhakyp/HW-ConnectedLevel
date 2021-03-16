using HW_ADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HW_ADO.NET.Data
{
    public class AuthorDataAccess : DbDataAccess<Author>
    {
        public override ICollection<Author> Select(string select)
        {
            var selectSqlScript = select;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var author = new List<Author>();

            // до тех пор есть, что читать - читай
            while (dataReader.Read())
            {
                author.Add(new Author
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    FullName = dataReader["FullName"].ToString(),
                });
            }

            dataReader.Close();
            command.Dispose();

            return author;
        }
    }
}
