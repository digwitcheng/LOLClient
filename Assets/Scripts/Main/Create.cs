using LOLSocketModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour {

    [SerializeField]
    private InputField nameField;
    [SerializeField]
    private Button createBtn;
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void Open()
    {
        createBtn.enabled = true;
        gameObject.SetActive(true);
    }
    public async void Click()
    {
        if (nameField.text.Length > 6 || nameField.text == string.Empty)
        {
            WarrningManager.errors.Add(new WarrningModel("请输入正确的昵称!"));
            return;
        }
        createBtn.enabled = false;
        await this.SendAsync(TypeProtocol.USER, 0, CommandProtocol.CREATE_CREQ, nameField.text);
    }
	
}
