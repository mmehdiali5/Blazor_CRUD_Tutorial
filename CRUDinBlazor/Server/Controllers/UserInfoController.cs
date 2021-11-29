using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDinBlazor.Shared;
using System.Data.SqlClient;

namespace CRUDinBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UserInfo> usersList = new List<UserInfo>();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("Select * from UserInfo", con);
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                UserInfo user = new UserInfo();
                user.id = data.GetInt32(0);
                user.username = data.GetString(1);
                user.age = data.GetInt32(2);
                usersList.Add(user);
            }

            return Ok(usersList);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("Delete from userInfo where username=@u", con);
            SqlParameter u = new SqlParameter("u", username);
            cmd.Parameters.Add(u);
            con.Open();
            return Ok(cmd.ExecuteNonQuery());
        }

        [HttpPost]

        public async Task<IActionResult>Add(UserInfo user)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("INSERT INTO userInfo (username,age)VALUES(@u, @a)", con);
            SqlParameter u = new SqlParameter("u", user.username);
            SqlParameter age = new SqlParameter("a", user.age);
            cmd.Parameters.Add(u);
            cmd.Parameters.Add(age);
            con.Open();
            return Ok(cmd.ExecuteNonQuery());
        }

        [HttpPut]

        public async Task<IActionResult>Update(UserInfo user)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=usersInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("UPDATE userInfo SET username=@u,age=@a where id=@i", con);
            SqlParameter u = new SqlParameter("u", user.username);
            SqlParameter age = new SqlParameter("a", user.age);
            SqlParameter id = new SqlParameter("i", user.id);

            cmd.Parameters.Add(u);
            cmd.Parameters.Add(age);
            cmd.Parameters.Add(id);

            con.Open();
            return Ok(cmd.ExecuteNonQuery());
        }
    }
}
