using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SubscriptionApp.API.Models;

namespace SubscriptionApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            //First check if this user exists in our DB
            if(user == null)
                return null;
            
            //Then check if the password being sent for login matches the stored password hash
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             //Needs using as the the class for cryptography implements IDisposable
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {               
                //Computed hash will be the same as the password hash as we are using the stored
                //password salt from the user to regenerate the hash
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //check the computed hash against the password hash
                for(int i=0; i<computedHash.Length;i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
           byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //Add the user to the data context
            await _context.Users.AddAsync(user);

            //Save the user to the database
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //Needs using as the the class for cryptography implements IDisposable
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //randomly generated key
                passwordSalt = hmac.Key;
                //Convert password as a byte array by encoding the password with the salt returned from key
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            
            return false;
        }
    }
}