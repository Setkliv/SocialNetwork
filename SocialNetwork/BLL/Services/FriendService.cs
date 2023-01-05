using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Friend>();

            friendRepository.FindByFriendId(friendId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var friendUserEntity = userRepository.FindById(m.friend_id);

                friend.Add(new Friend(m.id, m.content, senderUserEntity.email, friendUserEntity.email));
            });

            return friends;
        }

        public IEnumerable<Friend> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Friend>();

            friendRepository.FindByUserId(userId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var friendUserEntity = userRepository.FindById(m.friend_id);

                friend.Add(new Friend(m.id, m.content, senderUserEntity.email, friendUserEntity.email));
            });

            return friends;
        }

        public void SendFriend(AddFriendData friendSendingData)
        {
            if (String.IsNullOrEmpty(friendSendingData.UserId))
                throw new ArgumentNullException();


            var findUserEntity = this.userRepository.FindByEmail(friendSendingData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = addFriendData.UserId,
                friend_id = addFriendData.FriendId,
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
