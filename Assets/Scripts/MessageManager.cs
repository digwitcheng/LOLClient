using Assets.Scripts;
using LOLSocketModel;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    IReceiveMessage<MessageModel> loginReceive;
    private ConcurrentQueue<MessageModel> messageQueue;
    void Start()
    {
        messageQueue = new ConcurrentQueue<MessageModel>();
        NetIO.Instance.Start(messageQueue);
        loginReceive = GetComponent<LoginMessageHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        while (!messageQueue.IsEmpty)
        {
            LOLSocketModel.MessageModel model;
            messageQueue.TryDequeue(out model);
            loginReceive.Receive(model);
          //  StartCoroutine("HandlerWithCorutine", model);
        }
    }


}
