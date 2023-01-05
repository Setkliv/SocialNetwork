using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        AddFriendView addFriendView;
        public AddFriendView(AddFriendView addFriendView, UserService userService)
        {
            this.addFriendView = addFriendView;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var addFriendData = new AddFriendData();

            Console.Write("Введите почтовый адрес своего друга: ");
            AddFriendData.FriendEmail = Console.ReadLine();

            AddFriendData.UserId = user.Id;

            try
            {
                FriendService.SendFriend(AddFriendData);

                SuccessMessage.Show("Запрос отправлен успешно!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }

        }
    }
}
