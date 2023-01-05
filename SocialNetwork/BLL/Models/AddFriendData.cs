using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class AddFriendData
    {
        public int SenderId { get; set; }
        public string UserId { get; set; }
        public string FriendEmail { get; set; }
    }
}
