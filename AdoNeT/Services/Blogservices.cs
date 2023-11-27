using AdoNeT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdoNeT.Services
{
    internal class Blogservices : IBaseService<Blogs>
    {
        public int Create(Blogs data)
        {
            string query = $"INSERT INTO Blogs VALUES (N'{data.Title}', N'{data.Description}')";
            return SqlHelpers.SqlHelpers.Exec(query);
        }

        public int Delete(int id)
        {
            string query = $"DELETE Blogs WHERE Id = {id}";
            return SqlHelpers.SqlHelpers.Exec(query);
        }

        public List<Blogs> GetAll()
        {
            DataTable dt = SqlHelpers.SqlHelpers.GetDatas("SELECT * FROM Blogs");
            List<Blogs> list = new List<Blogs>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blogs
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"]
                });
            }
            return list;
        }

        public Blogs GetById(int id)
        {
            throw new NotImplementedException();
            
        }


        public int Update(int id, Blogs data)
        {
            throw new NotImplementedException();
        }
    }
}
