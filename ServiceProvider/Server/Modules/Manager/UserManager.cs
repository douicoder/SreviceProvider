using System;
using System.Linq;
using System.Security.Cryptography;
using Class.User.UserModel;
using Modules.User.UserInteface;
using MailKit.Net.Smtp;
using MimeKit;
using Class.User.CategoryModel;
using ServiceProvider.Shared.User;

namespace Modules.User.UserManager
{
    public class UserManager : IUserManager
    {
      
        // Hardcoded salt value
        private const string Salt = "iIjG8DGesRt4aM9KUYh+AQ==";
        DatabaseContext database = new();
        public UserManager(DatabaseContext _db)
        {
            database = _db;
        }

        public bool Registration(UserModel model)
        {
            try
            {
                // Check if the email or phone number already exists
                var isEmailOrPhoneExist = database.UsersModelDB.Any(x => x.EmailID.ToLower() == model.EmailID.ToLower() || x.PhoneNumber == model.PhoneNumber);
                if (isEmailOrPhoneExist)
                {
                    return false;
                }

                // Compute the hash of the password with the hardcoded salt
                string passwordHash = ComputeHash(model.Password, Salt);

                // Update the UserModel properties with hashed password and salt
                model.Password = passwordHash;

                // Add the user to the database and save changes
                database.UsersModelDB.Add(model);
                database.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }

        public bool ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                // Find the user by email
                var user = database.UsersModelDB.FirstOrDefault(x => x.EmailID.ToLower() == changePasswordModel.Email.ToLower());

                if (user == null)
                {
                    return false; // User not found
                }

                // Verify if the current password matches
                if (!VerifyPassword(changePasswordModel.CurrentPassword, user.Password, Salt))
                {
                    return false; // Current password doesn't match
                }

                // Compute the hash of the new password with the hardcoded salt
                string newPasswordHash = ComputeHash(changePasswordModel.NewPassword, Salt);

                // Update the user's password
                user.Password = newPasswordHash;

                // Save changes to the database
                database.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }

        public List<CategoryModel> GetAllCategories()
        {
            try
            {
              
                return database.CategoriesDB.ToList();
            }
            catch (Exception ex)
            {
                return new List<CategoryModel>();
            }
        }

        public bool Login(string email, string password)
        {
            try
            {
                // Find the user by email
                var user = database.UsersModelDB.FirstOrDefault(x => x.EmailID.ToLower() == email.ToLower());

                // If user not found or password does not match, return false
                if (user == null || !VerifyPassword(password, user.Password, Salt))
                {
                    return false;
                }

                // User found and password matches
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }


        public UserModel GetUser(string email)
        {
            try
            {
                // Retrieve the service provider profile based on the userId
                var serviceProviderProfile = database.UsersModelDB.FirstOrDefault(sp => sp.EmailID == email);

                return serviceProviderProfile;
            }
            catch (Exception ex)
            {
                // Handle exception (you might want to log this exception)
                return null; // Return null in case of an exception
            }
        }








        // Method to compute hash
        private string ComputeHash(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Derive a new salted hash for the password
            using (var rfc2898 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hash = rfc2898.GetBytes(20); // 20 bytes for SHA-1
                return Convert.ToBase64String(hash);
            }
        }

        // Method to verify if password is correct
        private bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            // Compute the hash of the provided password with the stored salt
            string computedHash = ComputeHash(password, salt);
            // Compare with the stored hashed password
            return hashedPassword == computedHash;
        }

        public async Task<int> GenrateCode(string email)
        {
            Random rnd = new Random();
            int randomNumberInRange = rnd.Next(1001, 9998);


            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Service Provider", "usermanagment.doui@outlook.com"));
            emailMessage.To.Add(new MailboxAddress("User", email.ToLower()));
            emailMessage.Subject = "Verification Code For Service Provider!!!! ";
            emailMessage.Body = new TextPart("plain")
            {
                Text = $"Your code for service Provider is {randomNumberInRange}"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp-mail.outlook.com", 587, false);
                    await client.AuthenticateAsync("usermanagment.doui@outlook.com", "9#fhT$2zPw8@N");
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);

         
                    return randomNumberInRange;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

        }
    }
}
