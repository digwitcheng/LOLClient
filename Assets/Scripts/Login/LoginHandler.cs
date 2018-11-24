using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOLSocketModel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class LoginHandler: IReceiveMessage<MessageModel>
    {
        Action<object> action;
        public  void Receive(MessageModel model,Action<object>action)
        {
            this.action = action;
            Result result = (Result)model.Message;            
            switch (model.Command)
            {
                case CommandProtocol.LOGIN_SRES:
                    Login(result);
                    break;
                case CommandProtocol.REG_SRES:
                    Register(result);
                    break;
            }
        }

        private void Register(Result result)
        {
            switch (result)
            {
                case Result.RegSuccess:                    
                        WarrningManager.errors.Add(new WarrningModel(result + "",()=> { action("RegPanelClose"); }));
                    break;
                case Result.RegAccountExist:
                case Result.RegNameIllegal:
                case Result.RegPasswordIllegal:
                    WarrningManager.errors.Add(new WarrningModel(result + "", () => { action("ClearRegPassword"); }));
                    break;
                default:
                    throw new ArgumentException("Register result");
            }
        }

        private void Login(Result result)
        {
            action("ActiveLoginBtn");
            switch (result)
            {
                case Result.LoginSuccess:
                    SceneManager.LoadScene(1);
                    break;
                case Result.LoginRepeat:
                case Result.LoginNameOrPasswordError:
                case Result.LoginAccountNotExist:
                    WarrningManager.errors.Add(new WarrningModel(result + "", ()=> { action("ActiveLoginBtn"); }));
                    break;
                default:
                    throw  new ArgumentException("Login result");
            }
        }



    }
}
