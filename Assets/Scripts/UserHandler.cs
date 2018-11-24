using LOLSocketModel;
using LOLSocketModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class UserHandler : IReceiveMessage<MessageModel>
    {
        Action<object> action;
        public void Receive(MessageModel model,Action<object> action)
        {
            this.action = action;
            switch (model.Command)
            {
                case CommandProtocol.CREATE_SREQ:
                    Create(model);
                    break;
                case CommandProtocol.INFO_SREQ:
                    Info(model);
                    break;
                case CommandProtocol.ONLINE_SREQ:
                    Online(model);
                    break;
                default:
                    break;
            }
        }

        private void Online(MessageModel model)
        {
            GameData.User = (UserDto)model.Message;
            WarrningManager.errors.Add(new WarrningModel("online sucess"));
        }

        private async void Info(MessageModel model)
        {
            UserDto dto = (UserDto)model.Message;
            if (dto == null)
            {
                action("OpenCreate");
              // SendMessage("OpenCreate");
            }
            else
            {
                await NetIO.Instance.SendAsync(TypeProtocol.USER, 0, CommandProtocol.ONLINE_CREQ, null);
            }
        }

        private void Create(MessageModel model)
        {
            bool isSuccess = (bool)model.Message;
            if (isSuccess)
            {
                //关闭面板
                action("CloseCreate");

            }
            else
            {
                //刷新面板
                action("OpenCreate");
            }
        }
    }
}
