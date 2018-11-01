using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOLSocketModel;


namespace Assets.Scripts
{
    class LoginMessageHandler :AbsMessageHandler
    {
        public override void Receive(MessageModel model)
        {
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
                        WarrningManager.errors.Add(new WarrningModel(result + "",()=> { SendMessage("RegPanelClose"); }));
                    break;
                case Result.RegAccountExist:
                case Result.RegNameIllegal:
                case Result.RegPasswordIllegal:
                    WarrningManager.errors.Add(new WarrningModel(result + "", () => { SendMessage("ClearRegPassword"); }));
                    break;
                default:
                    throw new ArgumentException("Register result");
            }
        }

        private void Login(Result result)
        {
            switch (result)
            {
                case Result.LoginSuccess:
                    SendMessage("ActiveLoginBtn");
                    break;
                case Result.LoginRepeat:
                case Result.LoginNameOrPasswordError:
                case Result.LoginAccountNotExist:
                    WarrningManager.errors.Add(new WarrningModel(result + "", ()=> { SendMessage("ActiveLoginBtn"); }));
                    break;
                default:
                    throw  new ArgumentException("Login result");
            }
        }



    }
}
