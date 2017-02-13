using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace CIS
{
    class User : IAuthenticate
    {
        string email;
        string name;
        bool isAdmin;

        string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
            }
        }

        public bool Login(string Email, string Password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();

                string Hash, Salt;

                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT dbo.GetSalt(\'" + Email + "\')", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (!reader.IsDBNull(0))
                        Salt = reader.GetString(0);
                    else return false;
                    reader.Close();
                    
                    cmd = new SqlCommand("SELECT dbo.GetHash(\'" + Email + "\')", myConnection);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (!reader.IsDBNull(0))
                        Hash = reader.GetString(0);
                    else return false;
                        
                    reader.Close();
                }

                Password += Salt;
                string InputHash;

                using (MD5 md5Hash = MD5.Create())
                {
                    InputHash = GetMd5Hash(md5Hash, Password);
                }

                if (InputHash == Hash)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Register(string Name, string Email, string Password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();

                string Hash, Salt;

                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT dbo.GetSalt(\'" + Email + "\')", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (!reader.IsDBNull(0))
                        return false;
                    reader.Close();

                    Salt = RandomString(32);

                    Password += Salt;

                    using (MD5 md5Hash = MD5.Create())
                    {
                        Hash = GetMd5Hash(md5Hash, Password);
                    }

                    cmd = new SqlCommand("EXEC InsertAdmin @AdminEmail = \'" + Email + 
                                        "\', @AdminName = \'" + Name + 
                                        "\', @AdminSalt = \'" + Salt +
                                        "\', @AdminHash = \'" + Hash + "\'", myConnection);

                    reader = cmd.ExecuteReader();

                    reader.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
