using Assets.Scripts;
using LOLSocketModel;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        while (!NetIO.Instance.MessageQueue.IsEmpty)
        {
            LOLSocketModel.MessageModel model;
            NetIO.Instance.MessageQueue.TryDequeue(out model);
            IReceiveMessage<MessageModel> receive = HandlerFactory.Create(model.Type);
            receive.Receive(model,(s)=> { SendMessage((string)s); });
          //  StartCoroutine("HandlerWithCorutine", model);
        }
    }


}
