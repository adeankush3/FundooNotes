using DataBaseLayer.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IUserBL
    {
        public void AddUser(UserModel user);
        public string LoginUser(string email, string password);

        public bool ForgotPassword(string email); 

        public bool ChangePassword(string Email, ChangePasswardModel changePassward); 
    }
}