

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using xCubeApplication.ClientDAL;
using xCubeApplication.Interfaces;
using xCubeApplication.Models;

namespace xCubeApplication.Services
{
    public class UserRepositoryService : IUserRepositoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;

        public UserRepositoryService()
        {
            _connectionString = ConfigurationManager.AppSettings["dbConnection"].ToString();
        }

        public bool GetUserDetails(string name)
        {
            bool IsExistingUser = false;
            List<UserDetails> result = new List<UserDetails>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "SELECT ID, Name, Age, ContactNumber, DOB, ProfileImagePath FROM UserDetails WHERE Name = @Name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDetails user = new UserDetails
                            {
                                ID = reader["ID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Age = reader["Age"].ToString(),
                                ContactNumber = reader["ContactNumber"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd"),
                                ProfileImagePath = reader["ProfileImagePath"].ToString()
                            };

                            result.Add(user);
                        }
                    }
                }
                if(result.Count > 0)
                {
                    IsExistingUser = true;
                }
            }

            return IsExistingUser;
        }

        public List<UserDetails> GetAllUserDetails()
        {
            List<UserDetails> result = new List<UserDetails>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = "SELECT ID, Name, Age, ContactNumber, DOB, ProfileImagePath FROM UserDetails";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDetails user = new UserDetails
                            {
                                ID = reader["ID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Age = reader["Age"].ToString(),
                                ContactNumber = reader["ContactNumber"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd"),
                                ProfileImagePath = reader["ProfileImagePath"].ToString()
                            };

                            result.Add(user);
                        }
                    }
                }
            }

            return result;
        }

        public bool AddUser(UserDetails user)
        {
            bool result = false;
            string _connectionString = ConfigurationManager.AppSettings["dbConnection"].ToString();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"INSERT INTO UserDetails (Name, Age, ContactNumber, DOB, ProfileImagePath) 
                       VALUES (@Name, @Age, @ContactNumber, @DateOfBirth, @ProfileImagePath)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth); 
                    cmd.Parameters.AddWithValue("@ProfileImagePath", user.ProfileImagePath);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }

            return result;
        }

        public bool UpdateUser(UserDetails user)
        {
            bool result = false;
            string _connectionString = ConfigurationManager.AppSettings["dbConnection"].ToString();
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string sql = @"UPDATE UserDetails 
                               SET Name = @Name, Age = @Age, ContactNumber = @ContactNumber, 
                                   DOB = @DateOfBirth, ProfileImagePath = @ProfileImagePath 
                               WHERE Name = @Name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(user.DateOfBirth)); 
                    cmd.Parameters.AddWithValue("@ProfileImagePath", user.ProfileImagePath);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        public UserRepositoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserDetails> GetUserByNameAsync(string Name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == Name);
        }

        public async Task<IEnumerable<UserDetails>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserDetails> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(UserDetails user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDetails user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
