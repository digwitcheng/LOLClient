using Assets.Scripts;
using LOLSocketModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {

    [SerializeField]
    private GameObject mask;
    [SerializeField]
    private Create createPanel;

	async void Start () {
        if (GameData.User == null)
        {
            mask.SetActive(true);
            //为什么不直接带账号信息跳转，而要根据连接来获取账号信息？
            //如果跳转时连接断开了，重写连接上是不是账号信息就获取不到了？
           await this.SendAsync(TypeProtocol.USER, 0, CommandProtocol.INFO_CREQ, null);
        }
	}

    public void OpenCreate()
    {
        createPanel.Open();
        mask.SetActive(false);
    }
    public void CloseCreate()
    {
        createPanel.Close();
        mask.SetActive(false);
    }

}
