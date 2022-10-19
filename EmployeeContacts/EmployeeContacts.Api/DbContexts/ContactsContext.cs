using EmployeeContacts.Api.Models;
using System.Data.SqlClient;

namespace EmployeeContacts.Api.DbContexts
{
    public class ContactsContext
    {
        public List<Contact> Contacts { get; set; }
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        public ContactsContext()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = _config.GetConnectionString("ContactBMT");

            GetContacts();
        }

        
        public IEnumerable<Contact> GetContacts()
        {
            Contacts = new List<Contact>();

            string query = "SELECT * FROM Contact";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Contacts.Add(new Contact
                            {
                                ContactID = Convert.ToInt64(sdr["ContactID"]),
                                FirstName = Convert.ToString(sdr["FirstName"]),
                                LastName = Convert.ToString(sdr["LastName"]),
                                CompanyName = Convert.ToString(sdr["CompanyName"]),
                                MobileNumber = Convert.ToString(sdr["MobileNumber"]),
                                EmailAddress = Convert.ToString(sdr["EmailAddress"])
                            });
                        }
                    }
                    con.Close();
                }
            }

            return Contacts;
        }

        public long AddContact(Contact request)
        {
            int success;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Contact VALUES " +
                    "(@ContactID, @FirstName, @LastName,@CompanyName,@MobileNumber, @EmailAddress)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ContactID", request.ContactID);
                    cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", request.LastName);
                    cmd.Parameters.AddWithValue("@CompanyName", request.CompanyName);
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", request.EmailAddress);
                    con.Open();
                    success = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return success > 0 ? request.ContactID : 0;
        }

        public long UpdateContact(Contact request)
        {
            int success;
            string query = "UPDATE Contact SET FirstName = @FirstName, LastName = @LastName," +
                    "CompanyName=@CompanyName," +
                    "MobileNumber=@MobileNumber,EmailAddress=@EmailAddress Where ContactID =@ContactID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", request.LastName);
                    cmd.Parameters.AddWithValue("@CompanyName", request.CompanyName);
                    cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    cmd.Parameters.AddWithValue("@EmailAddress", request.EmailAddress);
                    cmd.Parameters.AddWithValue("@ContactID", request.ContactID);
                    con.Open();
                    success = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return success > 0 ? request.ContactID : 0;
        }
    }
}
