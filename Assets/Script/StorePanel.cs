using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class StorePanel : TTUIPage {
    public  static Text  Stext;//水晶的数量
    public static Text text;//魔法粉的数量
    private Button button;//兑换按钮
    private Button closeBtn;//关闭按钮
    private InputField input;//输入要兑换的水晶数



    public StorePanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "Warehouse panel";
    }

    public override void Active()
    {

        base.Active();

        Stext =transform.Find("CryltalText").GetComponent<Text>();
        text=transform.Find("MagicText").GetComponent<Text>();
        button=transform.Find("ExcButton").GetComponent<Button>();
        closeBtn=transform.Find("CloseButton").GetComponent<Button>();
        input=transform.Find("ExcInput").GetComponent<InputField>();

        button.onClick.AddListener(OnDuHuan);
        closeBtn.onClick.AddListener(OnClose);



    }


    public void OnDuHuan()
    {

        int Inputsum = int.Parse(input.text);
        int currMoSum = int.Parse(text.text);
        if (int.Parse(Stext.text)<=0)
        {
            ShowPage<Tip>("没有水晶可兑换");
            return;
        }

        if (Inputsum%1000==0)
        {
            int sum1 = Inputsum / 10;
            text.text = (currMoSum+ sum1).ToString();

            int sum2 = int.Parse(Stext.text);
            if (sum2 - Inputsum >= 0)
            {
                Stext.text = (sum2 - Inputsum).ToString();
            }
            else
            {
                ShowPage<Tip>("水晶数量不够");
            }
            MainPanel.GetCKText(Stext.text,text.text);
        }   
        else
        {
            ShowPage<Tip>("输入的水晶数必须是一百的倍数");
        }
       

    }

    public void OnClose()
    {

        Hide();
    }


    public static void  GetText(string _Stext,string _text)
    {
        Stext.text = _Stext;
        text.text = _text;

    }
}
