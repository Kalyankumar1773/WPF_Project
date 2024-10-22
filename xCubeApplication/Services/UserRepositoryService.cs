

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

        public UserRepositoryService()
        {
            
        }

        public UserDetails GetUserDetails(string name)
        {
            UserDetails result = new UserDetails();
            string _connectionString = ConfigurationManager.AppSettings["dbConnection"].ToString();
            // Establish connection to the database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Create SQL query to fetch user details based on name
                string sql = "SELECT ID, Name, Age, ContactNumber, DOB, ProfileImagePath FROM UserDetails WHERE Name = @Name";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Add parameter to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if the query returned any rows
                        while (reader.Read())
                        {
                            // Map the data to UserDetails model
                            UserDetails user = new UserDetails
                            {
                                ID = reader["ID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Age = reader["Age"].ToString(),
                                ContactNumber = reader["ContactNumber"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd"),
                                ProfileImagePath = reader["ProfileImagePath"].ToString()
                            };

                            result = user;
                        }
                    }
                }
            }

            return result;
        }

        public List<UserDetails> GetAllUserDetails()
        {
            List<UserDetails> result = new List<UserDetails>();
            string _connectionString = ConfigurationManager.AppSettings["dbConnection"].ToString();
            // Establish connection to the database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Create SQL query to fetch user details based on name
                string sql = "SELECT ID, Name, Age, ContactNumber, DOB, ProfileImagePath FROM UserDetails";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if the query returned any rows
                        while (reader.Read())
                        {
                            // Map the data to UserDetails model
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

                // Corrected SQL Insert query
                string sql = @"INSERT INTO UserDetails (Name, Age, ContactNumber, DOB, ProfileImagePath) 
                       VALUES (@Name, @Age, @ContactNumber, @DateOfBirth, @ProfileImagePath)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth); // Use the correct property name (DOB) for the date of birth
                    cmd.Parameters.AddWithValue("@ProfileImagePath", user.ProfileImagePath);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any row was affected (inserted)
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
                               WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@ID", user.ID);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(user.DateOfBirth)); // Ensure DateOfBirth is parsed correctly
                    cmd.Parameters.AddWithValue("@ProfileImagePath", user.ProfileImagePath);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the update was successful
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

        // Get all users
        public async Task<IEnumerable<UserDetails>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Get a specific user by ID
        public async Task<UserDetails> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Add a new user
        public async Task AddUserAsync(UserDetails user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Update an existing user
        public async Task UpdateUserAsync(UserDetails user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Delete a user by ID
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
