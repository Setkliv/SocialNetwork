using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public string User { get; }
        public string UserEmail { get; }
        public string FriendEmail { get; }

        public Friend(int id, string user, string userEmail, string friendEmail)
        {
            this.Id = id;
            this.User = user;
            this.UserEmail = userEmail;
            this.FriendEmail = friendEmail;
        }

    }
}