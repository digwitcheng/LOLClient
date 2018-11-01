using LOLSocketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
     class AbsMessageHandler :MonoBehaviour, IReceiveMessage<MessageModel>
    {
        public virtual void Receive(MessageModel model) { }
    }
}
