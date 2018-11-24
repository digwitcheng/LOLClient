using UnityEngine;
using System.Collections;
using Cowboy.Sockets;
using Assets.Scripts.Login;
using System.Text;
using Assets.Scripts;
using LOLSocketModel;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class NetIO
{
    TcpSocketSaeaClient client;
    private NetIO()
    {
    }
    private static NetIO instance;
    private static readonly object instanceLock = new object();
    public static NetIO Instance
    {
        get
        {
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NetIO();
                    }
                }
            }
            return instance;
        }
    }

    public async  void Start(ConcurrentQueue<LOLSocketModel.MessageModel> messageQueue)
    {
        client = new TcpSocketSaeaClient(AppSetting.IP, AppSetting.PORT, new SimpleSaeaClientMessageDispatcher(messageQueue));
         await client.Connect();
    }

    public async Task SendAsync(MessageModel model)
    {
        if (client == null)
        {
            Debug.LogWarning(" 还未连接服务器！");
            return ;
        }
        await client.SendAsync(SerializationUtil.Encode(model));
    }
    public async Task SendAsync(byte type,int area,int command,object message)
    {
        await SendAsync(new MessageModel(type, area, command, message));
    }
}