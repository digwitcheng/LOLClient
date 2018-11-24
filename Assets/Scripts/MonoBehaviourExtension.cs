using LOLSocketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public static class MonoBehaviourExtension
{
    /// <summary>
    /// 扩展发送消息方法
    /// </summary>
    /// <param name="mono">扩展的类</param>
    /// <param name="model">消息模型</param>
    /// <returns></returns>
    public static async Task SendAsync(this MonoBehaviour mono, MessageModel model)
    {
        await NetIO.Instance.SendAsync(model); 
    }
    /// <summary>
    /// 扩展发送消息方法
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="type">一级协议, 用于区分所属模块</param>
    /// <param name="area">二级, 用于区分主模块下的分模块</param>
    /// <param name="command">三级协议, 用于区分当前处理逻辑功能</param>
    /// <param name="message">消息体, 当前需要处理的主体数据</param>
    /// <returns></returns>
    public static async Task SendAsync(this MonoBehaviour mono, byte type, int area, int command, object message)
    {
        await SendAsync(mono, new MessageModel(type, area, command, message));
    }
}

