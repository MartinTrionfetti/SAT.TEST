using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        #region Constructor
        public UserRepository()
        {

        }
        #endregion

        #region Public methods
        public async Task<bool> IsUserDuplicated(User user)
        {
            var reader = ReadUsersFromFile();

            try
            {
                while (reader.Peek() >= 0)
                {
                    var readUser = LineToUser(reader.ReadLineAsync().Result);

                    if (readUser.Email == user.Email || readUser.Phone == user.Phone)
                    {
                        return await Task.FromResult(true);
                    }
                    else if (readUser.Name == user.Name)
                    {
                        if (readUser.Address == user.Address)
                        {
                            return await Task.FromResult(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read user file.", ex);
            }
            finally{
                reader.Close();
            }
            return false;
        }

        public async Task<List<User>> GetAll()
        {
            var reader = ReadUsersFromFile();
            try
            {
                var users = new List<User>();

                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = LineToUser(line);
                    users.Add(user);
                }

                return await Task.FromResult(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to obtain user list from file.", ex);
            }
            finally
            {
                reader.Close();
            }
        }

        public async Task<bool> Add(User user)
        {
            string line = user.Name + "," + user.Email + "," + user.Phone + "," + user.Address + "," + user.UserType + "," + user.Money;
            File.AppendAllText(Directory.GetCurrentDirectory() + "/files/users.txt", Environment.NewLine + line);
            return await Task.FromResult(true);
        }

        #endregion

        #region Private methods
        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
        private User LineToUser(string line)
        {
            var user = new User
            {
                Name = line.Split(',')[0].ToString(),
                Email = line.Split(',')[1].ToString(),
                Phone = line.Split(',')[2].ToString(),
                Address = line.Split(',')[3].ToString(),
                UserType = line.Split(',')[4].ToString(),
                Money = decimal.Parse(line.Split(',')[5].ToString()),
            };

            return user;
        }
        #endregion 
    }
}