using Cowboy.Sockets;
using LOLSocketModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Login
{
    class SimpleSaeaClientMessageDispatcher : ITcpSocketSaeaClientMessageDispatcher
    {
        private ConcurrentQueue<MessageModel> messageQueue;

        public SimpleSaeaClientMessageDispatcher(ConcurrentQueue<MessageModel> messageQueue)
        {
            this.messageQueue = messageQueue;
        }

        // Assets/CSharp 6.0 Support/AsyncTools/AsyncTools.cs(34,44): error CS1519: Unexpected symbol `=>' in class, struct, or interface member declaration

        public async Task OnServerConnected(TcpSocketSaeaClient client)
        {
             string msg="connected to server:" + client.RemoteEndPoint;
            Debug.Log(msg);
             await Task.CompletedTask;
        }

        public async Task OnServerDataReceived(TcpSocketSaeaClient client, byte[] data, int offset, int count)
        {

            MessageModel sm = SerializationUtil.Decode(data, offset, count);
            messageQueue.Enqueue(sm);
            await Task.CompletedTask;
        }

        public async Task OnServerDisconnected(TcpSocketSaeaClient client)
        {
            string msg="closed:" + client.RemoteEndPoint;
            Debug.Log(msg+"");
            await Task.CompletedTask;
        }
    }
}
