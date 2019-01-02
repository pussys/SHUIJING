using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class Login : TTUIPage {
    private Button Loginbt;
    private Button Regbt;
    private InputField userInput;
    private InputField pwInput;
    bool isUserName = false;
    bool isPassword = false;


    public Login() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
    {
        uiPath = "Login";
    }

    public override void Awake(GameObject go)
    {
        Loginbt = transform.Find("LoginButton").GetComponent<Button>();
        Regbt = transform.Find("RegButton").GetComponent<Button>();
        userInput = transform.Find("UsernameInputField").GetComponent<InputField>();
        pwInput = transform.Find("UsernameInputField").GetComponent<InputField>();

        Loginbt.onClick.AddListener(OnLoginClick);
        Regbt.onClick.AddListener(OnRegClick);
    }
    private void OnLoginClick()
    {
        //遍历用户名输入框里的每一个字符
        foreach (byte user in userInput.text)
        {
            if ((int)user >= 48 && (int)user <= 57 || (int)user >= 65 && (int)user <= 90 || (int)user >= 97 && (int)user <= 122 || (int)user == 95)
            {
                isUserName = true;
            }
            else
            {
                isUserName = false;
            }
        }
        //遍历密码输入框里的每一个字符
        foreach (var password in pwInput.text)
        {
            if ((int)password >= 48 && (int)password <= 57 || (int)password >= 65 && (int)password <= 90 || (int)password >= 97 && (int)password <= 122)
            {
                isPassword = true;
            }
            else
            {
                isPassword = false;
            }
        }

        //判断用户名或者密码是否为空
        if (userInput.text == "" && pwInput.text == "")
        {
            //Debug.Log("用户名和密码不能为空");
            ShowPage<Tip>("用户名和密码不能为空");
            return;
        }
        if (userInput.text.Length < 4 || userInput.text.Length > 20)
        {
            //Debug.Log("用户名必须是4-20个字符");
            ShowPage<Tip>("用户名必须是4-20个字符");
            return;
        }
        //判断用户名是否格式正确
        if (isUserName == false|| isPassword == false)
        {
            //Debug.Log("用户只能由数字、字母或下划线组成");
            ShowPage<Tip>("用户名或密码不对");
            return;
        }
        //如果用户名和密码都对了,连接服务器
        //连接服务器
        if (NetMgr.srvConn.status != Connection.Status.Connected)
        {
            string host = "192.168.2.61";
            int port = 1234;
            NetMgr.srvConn.proto = new ProtocolBytes();
            if (!NetMgr.srvConn.Connect(host, port))
                ShowPage<Tip>("连接服务器失败!");
            //PanelMgr.instance.OpenPanel<TipPanel>("", "连接服务器失败!");
        }
        //发送
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Login");
        protocol.AddString(userInput.text);
        protocol.AddString(pwInput.text);
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol, OnLoginBack);

    }

    public void OnLoginBack(ProtocolBase protocol)
    {
        ProtocolBytes proto = (ProtocolBytes)protocol;
        int start = 0;
        string protoName = proto.GetString(start, ref start);
        int ret = proto.GetInt(start, ref start);
        if (ret == 0)
        {
            //PanelMgr.instance.OpenPanel<TipPanel>("", "登录成功!");
            ShowPage<Tip>("登录成功!");
            //开始游戏
            Debug.Log("登录成功");
            ShowPage<MainPanel>();
        }
        else
        {
            //PanelMgr.instance.OpenPanel<TipPanel>("", "登录失败，请检查用户名密码!");
            ShowPage<Tip>("登录失败，请检查用户名密码!");
        }
    }
    private void OnRegClick()
    {
        ShowPage<Reg>();
        GameObject.Destroy(gameObject);
    }

}
