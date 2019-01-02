using System;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;
using UnityEngine.UI;


public class Reg : TTUIPage {
    private InputField userInput;
    private InputField pwInput;
    private InputField rePasswordInput;
    private Button reg;
    private Button closeBtn;
    bool isUserName;
    bool isPassword;

    public Reg() : base(UIType.PopUp,UIMode.DoNothing,UICollider.Normal)
    {
        uiPath = "Reg";
    }

    public override void Awake(GameObject go)
    {
        userInput = transform.Find("regUserName").GetComponent<InputField>();
        pwInput = transform.Find("regPassword").GetComponent<InputField>();
        rePasswordInput = transform.Find("rePassword").GetComponent<InputField>();
        reg = transform.Find("RegBtn").GetComponent<Button>();
        closeBtn = transform.Find("CloseBtn").GetComponent<Button>();
        Debug.Log(reg.name);
        reg.onClick.AddListener(OnRegClick);
        closeBtn.onClick.AddListener(OnCloseClick);
    }

    private void OnRegClick()
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
        if (userInput.text == "" || pwInput.text == "")
        {
            Debug.Log("用户名和密码不能为空");
            ShowPage<Tip>("用户名和密码不能为空");
            return;
        }
        if (userInput.text.Length < 4 || userInput.text.Length > 20)
        {
            Debug.Log("用户名必须是4-20个字符");
            ShowPage<Tip>("用户名必须是4-20个字符");
            return;
        }
        if (pwInput.text.Length < 4 || pwInput.text.Length > 10)
        {
            Debug.Log("密码用户名必须是4-10个字符");
            ShowPage<Tip>("密码用户名必须是4-10个字符");
            return;
        }
        //判断用户名是否格式正确
        if (isUserName == false)
        {
            Debug.Log("用户只能由数字、字母或下划线组成");
            ShowPage<Tip>("用户只能由数字、字母或下划线组成");
            return;
        }
        if (isPassword == false)
        {
            Debug.Log("密码只能由字母和数字组成");
            ShowPage<Tip>("用户名或密码不正确");
            return;
        }
        if (rePasswordInput.text != pwInput.text)
        {
            Debug.Log("两次输入的密码不一致");
            ShowPage<Tip>("两次输入的密码不一致");
            return;
        }
        //如果用户名和密码都对了,连接服务器,注册账号
        Debug.Log("注册成功");
        //连接服务器
        if (NetMgr.srvConn.status != Connection.Status.Connected)
        {
            string host = "192.168.2.61";
            int port = 1234;
            NetMgr.srvConn.proto = new ProtocolBytes();
            if (!NetMgr.srvConn.Connect(host, port))
                //PanelMgr.instance.OpenPanel<TipPanel>("", "连接服务器失败!");
                ShowPage<Tip>("连接服务器失败!");

        }
        //发送
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Register");
        protocol.AddString(userInput.text);
        protocol.AddString(pwInput.text);
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol, OnRegBack);
    }

    public void OnRegBack(ProtocolBase protocol)
    {
        ProtocolBytes proto = (ProtocolBytes)protocol;
        int start = 0;
        string protoName = proto.GetString(start, ref start);
        int ret = proto.GetInt(start, ref start);
        if (ret == 0)
        {
            //PanelMgr.instance.OpenPanel<TipPanel>("", "注册成功!");
            ShowPage<Tip>("注册成功!");

        }
        else
        {
            //PanelMgr.instance.OpenPanel<TipPanel>("", "注册失败，请更换用户名!");
            ShowPage<Tip>("注册失败，请更换用户名!");

        }
    }
    private void OnCloseClick()
    {
        ShowPage<Login>();
        GameObject.Destroy(gameObject);
    }
}
