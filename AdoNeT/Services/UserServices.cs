using AdoNeT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNeT.Services
{
    internal class UserServices: IBaseService<Users>
    {
        public int Create(Users data)
        {
            string query = $"INSERT INTO Users VALUES (N'{data.Name}', N'{data.Surname}',N'{data.Username}', N'{data.Password}')";
            return SqlHelpers.SqlHelpers.Exec(query);
        }

        public int Delete(int id)
        {
            string query = $"DELETE Users WHERE Id = {id}";
            return SqlHelpers.SqlHelpers.Exec(query);
        }

        public List<Users> GetAll()
        {
            DataTable dt = SqlHelpers.SqlHelpers.GetDatas("SELECT * FROM Users");
            List<Users> list = new List<Users>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Users
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Surname = (string)row["Surname"],
                    Password = (string)row["Password"],
                    Username = (string)row["UserName"],
                });
            }
            return list;
        }

        public Users GetById(int id)
        {
            throw new NotImplementedException();
        }


        public int Update(int id, Users data)
        {
            string query = $"UPDATE Users SET Username = '{data.Username}', PasswordHash = '{data.Password}' WHERE Id = {id}";

            return SqlHelpers.SqlHelpers.Exec(query);
        }
    }

}
