using Assets.Scripts;
using LOLSocketModel;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    private ConcurrentQueue<MessageModel> messageQueue;
    void Start()
    {
        messageQueue = new ConcurrentQueue<MessageModel>();
        NetIO.Instance.Start(messageQueue);
    }

    // Update is called once per frame
    void Update()
    {
        while (!messageQueue.IsEmpty)
        {
            LOLSocketModel.MessageModel model;
            messageQueue.TryDequeue(out model);
            IReceiveMessage<MessageModel> receive = HandlerFactory.Create(model.Type);
            receive.Receive(model,(s)=> { SendMessage((string)s); });
          //  StartCoroutine("HandlerWithCorutine", model);
        }
    }


}
