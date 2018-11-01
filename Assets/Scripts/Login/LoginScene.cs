using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Concurrent;
using LOLSocketModel;
using System.Threading.Tasks;
using LOLSocketModel.Dtos;

public class LoginScene : MonoBehaviour
{
    #region  登录面板部分
    [SerializeField]
    private InputField accuontInput;
    [SerializeField]
    private InputField passwordInput;
    [SerializeField]
    private Button loginBtn;
    #endregion

    #region 注册面板部分
    [SerializeField]
    private GameObject regPanel;

    [SerializeField]
    private InputField regAccountInput;

    [SerializeField]
    private InputField regpwInput;

    [SerializeField]
    private InputField regpwReInput;
    #endregion


    public async  void LoginOnClick()
    {
        if (accuontInput.text.Length <= 0 || passwordInput.text.Length <= 0)
        {
            Debug.Log("请输入账号和密码");
        }
        else
        {
            //loginBtn.enabled = false;
            loginBtn.interactable = false;

            AccountInfoDto infoDto = new AccountInfoDto();
            infoDto.Account = accuontInput.text;
            infoDto.Password = passwordInput.text;
            await this.SendAsync(new MessageModel(TypeProtocol.LOGIN,0,CommandProtocol.LOGIN_CREQ,infoDto));           
        }
    }
    public void ActiveLoginBtn()
    {
        passwordInput.text = string.Empty;
        loginBtn.interactable = true;
    }

    public void RegClick()
    {
        regPanel.SetActive(true);
    }
    public void RegPanelClose()
    {
        ClearRegPassword();
        ClearRegAccount();
        regPanel.SetActive(false);
    }
    public void ClearRegAccount()
    {
        regAccountInput.text = string.Empty;
    }
    public void ClearRegPassword()
    {
        regpwInput.text = string.Empty;
        regpwReInput.text = string.Empty;
    }

    public async void RegOkClick()
    {
        if (regAccountInput.text.Length == 0 || regAccountInput.text.Length > 6)
        {
            Debug.Log("账号不合法");
            ClearRegAccount();
            ClearRegPassword();
            return;
        }
        if (regpwInput.text.Length == 0 || regpwInput.text.Length > 6)
        {
            Debug.Log("密码不合法");
            ClearRegPassword();
            return;
        }
        if (!regpwInput.text.Equals(regpwReInput.text))
        {
            Debug.Log("两次输入密码不一致");
            ClearRegPassword();
            return;
        }
        //验证通过 申请注册 并关闭注册面板
        AccountInfoDto dto = new AccountInfoDto();
        dto.Account = regAccountInput.text;
        dto.Password = regpwInput.text;
        await this.SendAsync(TypeProtocol.LOGIN, 0, CommandProtocol.REG_CREQ, dto);
        
    }
}
