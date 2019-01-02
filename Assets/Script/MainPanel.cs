using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;
using System.Threading;
/// <summary>
/// 主界面
/// </summary>
public class MainPanel : TTUIPage {

    private Button storeBtn;
    private Button openBtn;//开垦按钮
    private Button plantBtn;//种植按钮
    private Button MofapingBtn;//魔法瓶按钮
    private Button collectBtn;//收获按钮
    private Button setBtn;//设置按钮
    private Button closeBtn;//关闭按钮
    private Button msgBtn;//个人信息按钮

    private static Text diamondNumberText;//水晶数量
    private static Text MofafenNumberText;//魔法粉数量
    private Text usernameText;//用户名

    public List<Button> buttonlist = new List<Button>();
    public List<Ground> groundlist = new List<Ground>();
    private GameObject buttonFather;
    public static int groundnumber = 100;
    public static int maigcNum = 10000;
    public static int DiamondNum = 12000;

    private  int Paneldevelopment =0;
    private  int PanelUndevelopment = 0;



    bool isDeve = false;
    bool isPlant = false;
    bool isMaigc = false;
    bool isHarvest = false;


    public MainPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "Main Interface";
    }

    public override void Awake(GameObject go)
    {

        storeBtn = transform.Find("WarehouseButton").GetComponent<Button>();
        openBtn = transform.Find("ReclamationButton").GetComponent<Button>();
        plantBtn = transform.Find("EnhancedButton").GetComponent<Button>();
        MofapingBtn = transform.Find("MagicBotButton").GetComponent<Button>();
        collectBtn = transform.Find("CollectButton").GetComponent<Button>();
        setBtn = transform.Find("SetButton").GetComponent<Button>();
        closeBtn = transform.Find("Exit").GetComponent<Button>();
        msgBtn = transform.Find("HeadPhoto").GetComponent<Button>();

        diamondNumberText = GameObject.Find("daimondText").GetComponent<Text>();
        MofafenNumberText = GameObject.Find("maigcText").GetComponent<Text>();
        //usernameText = transform.Find("nameText").GetComponent<Text>();

        storeBtn.onClick.AddListener(storeOnClick);
        openBtn.onClick.AddListener(openOnClick);
        plantBtn.onClick.AddListener(plantOnClick);
        MofapingBtn.onClick.AddListener(MofapingOnClick);
        collectBtn.onClick.AddListener(collectOnClick);
        setBtn.onClick.AddListener(setOnClick);
        //closeBtn.onClick.AddListener(closeOnClick);
        msgBtn.onClick.AddListener(msgOnClick);
        GroundCtr();
        for (int i = 0; i < 16; i++)
        {
            if (i == 0 || i == 1 || i == 5)
            {
                groundlist.Add(new Ground(Status.common, 0, Devestatus.development));
            }
            else
            {
                groundlist.Add(new Ground(Status.common, 0, Devestatus.underdevelopment));
            }
        }
        diamondNumberText.text = DiamondNum.ToString();
        MofafenNumberText.text = maigcNum.ToString();
    }

    public static void GetCKText(string a,string b)
    {
        diamondNumberText.text = a;
        MofafenNumberText.text = b;
    }

    /// <summary>
    /// 仓库
    /// </summary>
    private  void storeOnClick()
    {       
        ShowPage<StorePanel>();
        StorePanel.GetText(diamondNumberText.text, MofafenNumberText.text);
    }
    /// <summary>
    /// 开垦
    /// </summary>
    private void openOnClick()
    {
        if (isDeve == false)
        {
            for (int i = 0; i < groundlist.Count; i++)
            {

                if (groundlist[i].deve == Devestatus.underdevelopment)
                {
                    buttonlist[i].image.color = UnityEngine.Color.red;
                }
                else
                {
                    buttonlist[i].image.color = UnityEngine.Color.white;
                }
                groundlist[i].status = Status.developmenting;
                if (i == groundlist.Count - 1)
                {
                    isDeve = true;
                }
            }
        }
        #region
        else
            {
            for (int i = 0; i < groundlist.Count; i++)
            {
                buttonlist[i].image.color = UnityEngine.Color.white;
                groundlist[i].status = Status.common;
                isDeve = false;
            }
                
        }
        #endregion
    }
    /// <summary>
    /// 种植
    /// </summary>
    private void plantOnClick()
    {
        #region
        if (isPlant == false)
        {
            for (int i = 0; i < groundlist.Count; i++)
            {

                if (groundlist[i].deve == Devestatus.development)
                {
                    buttonlist[i].image.color = UnityEngine.Color.red;
                }
                else
                {
                    buttonlist[i].image.color = UnityEngine.Color.white;
                }
                groundlist[i].status = Status.plant;
                isPlant = true;
            } 
        }
        else
        {
            for (int i = 0; i < groundlist.Count; i++)
            {
                buttonlist[i].image.color = UnityEngine.Color.white;
                groundlist[i].status = Status.common;
                isPlant = false;
            }

        }
        #endregion
    }
    /// <summary>
    /// 魔法瓶
    /// </summary>
    private void MofapingOnClick()
    {
        if (isMaigc == false)
        {
            for (int i = 0; i < groundlist.Count; i++)
            {

                if (groundlist[i].deve == Devestatus.development)
                {
                    buttonlist[i].image.color = UnityEngine.Color.red;
                }
                else
                {
                    buttonlist[i].image.color = UnityEngine.Color.white;
                }
                groundlist[i].status = Status.maigc;
                isMaigc = true;
            }
        } 
        else
            {
            for (int i = 0; i < groundlist.Count; i++)
            {
                buttonlist[i].image.color = UnityEngine.Color.white;
                groundlist[i].status = Status.common;
                isMaigc = false;
            }
        }
    }
    /// <summary>
    /// 收获
    /// </summary>
    private void collectOnClick()
    {
        if (isHarvest == false)
        {
            for (int i = 0; i < groundlist.Count; i++)
            {

                if (groundlist[i].num > 1000)
                {
                    buttonlist[i].image.color = UnityEngine.Color.yellow;
                }
                groundlist[i].status = Status.harvest;
                isHarvest = true;
            }
        }
        else
            {
            for (int i = 0; i < groundlist.Count; i++)
            {
                buttonlist[i].image.color = UnityEngine.Color.white;
                groundlist[i].status = Status.common;
                isHarvest = false;
            }
        }
    }
    /// <summary>
    /// 设置
    /// </summary>
    private void setOnClick()
    {
        ShowPage<SetPanel>();
    }
    /// <summary>
    /// 个人信息
    /// </summary>
    private void msgOnClick()

    {
        UnPanelText();
        ShowPage<PersonPanel>();
        PanelText();
    }
    #region
    public void GroundCtr()
    {
        buttonFather = GameObject.Find("ButtonFather");
        for (int i = 0; i < buttonFather.transform.childCount; i++)
        {
            buttonlist.Add(buttonFather.transform.GetChild(i).GetComponent<Button>());
        }
        foreach (var bt in buttonlist)
        {
            bt.onClick.AddListener(delegate () { GroundStatusManage(int.Parse(bt.name)); });
        }
    }
   
    #endregion


    public void GroundStatusManage(int n)
    {
        switch (groundlist[n].status)
        {
            case Status.common:
                for (int i = 0; i < 16; i++)
                {
                    if (i == n)
                    {
                        buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                    }
                    else
                    {
                        buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                    }
                }
                break;


            case Status.developmenting:
                if (groundlist[n].deve == Devestatus.development)
                {
                    ShowPage<Tip>("该地块已经开垦过了");
                    return;
                }
                if (n <= 9)
                {
                    if (DiamondNum <= 300)
                    {
                        ShowPage<Tip>("您的水晶数量不足,无法开垦该地块");
                        return;
                    }
                    buttonlist[n].GetComponent<Image>().sprite = Resources.Load("common", typeof(Sprite)) as Sprite;
                    DiamondNum -= 300;
                }
                if (n >= 10 && n < 15)
                {
                    if (DiamondNum <= 3000)
                    {
                        ShowPage<Tip>("您的水晶数量不足,无法开垦该地块");
                        return;
                    }
                    buttonlist[n].GetComponent<Image>().sprite = Resources.Load("gold", typeof(Sprite)) as Sprite;
                    DiamondNum -= 3000;
                }
                if (n==15)
                {
                    if (DiamondNum <= 50000)
                    {
                        ShowPage<Tip>("您的水晶数量不足,无法开垦该地块");
                        return;
                    }
                    DiamondNum -= 50000;
                }
                groundlist[n].deve = Devestatus.development;
                buttonlist[n].GetComponent<Image>().color = UnityEngine.Color.white;
                for (int i = 0; i < 16; i++)
                {
                    if (i == n)
                    {
                        buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                    }
                    else
                    {
                        buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                    }
                }
                diamondNumberText.text = DiamondNum.ToString();
                MofafenNumberText.text = maigcNum.ToString();
                break;


            case Status.plant:
                if (groundlist[n].deve == Devestatus.development || groundlist[n].deve == Devestatus.yeszhongzhi)
                {
                    if (DiamondNum > 0)
                    {
                        buttonlist[n].transform.GetChild(0).gameObject.SetActive(true);
                        if (n >= 10 && n <= 14)
                        {
                            groundlist[n].num += 100;
                            DiamondNum -= 100;
                            if (groundlist[n].num < 30000)
                            {
                                groundlist[n].num += 100;
                                for (int i = 0; i < 16; i++)
                                {
                                    if (i == n)
                                    {
                                        buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                                    }
                                    else
                                    {
                                        buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                                    }
                                }
                                if (groundlist[n].num % 1000 == 0)
                                {
                                    buttonlist[n].transform.GetChild(0).localScale += new Vector3(0.1f, 0.1f, 0.1f);
                                }
                            }
                        }
                        if (n == 15)
                        {
                            groundlist[n].num += 100;
                            DiamondNum -= 100;
                            if (groundlist[n].num < 300000)
                            {
                                groundlist[n].num += 100;
                                for (int i = 0; i < 16; i++)
                                {
                                    if (i == n)
                                    {
                                        buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                                    }
                                    else
                                    {
                                        buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                                    }
                                }
                                if (groundlist[n].num % 1000 == 0)
                                {
                                    buttonlist[n].transform.GetChild(0).localScale += new Vector3(0.1f, 0.1f, 0.1f);
                                }
                            }
                        }
                        else
                        {
                            if (groundlist[n].num < 3000)
                            {
                                groundlist[n].num += 100;
                                DiamondNum -= 100;
                                for (int i = 0; i < 16; i++)
                                {
                                    if (i == n)
                                    {
                                        buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                                    }
                                    else
                                    {
                                        buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                                    }
                                }
                                if (groundlist[n].num % 1000 == 0)
                                {
                                    buttonlist[n].transform.GetChild(0).localScale += new Vector3(0.1f, 0.1f, 0.1f);
                                }
                            }
                        }

                        groundlist[n].deve = Devestatus.yeszhongzhi;
                    }
                    else
                    {
                        ShowPage<Tip>("您的水晶数不足");
                    }
                }
                else
                {
                    ShowPage<Tip>("您当前的地块还未开垦");
                }
                diamondNumberText.text = DiamondNum.ToString();
                MofafenNumberText.text = maigcNum.ToString();
                break;


            case Status.maigc:
                if (groundlist[n].deve == Devestatus.yeszhongzhi)
                {
                    if (maigcNum>0)
                    {
                        maigcNum -= 100;

                        if (n <= 9)
                        {
                            if (groundlist[n].num < 3000)
                            {
                                groundlist[n].num += 100;
                            }
                        }
                        if (n >= 10 && n <= 14)
                        {
                            if (groundlist[n].num < 30000)
                            {
                                groundlist[n].num += 200;
                            }
                        }
                        if (n == 15)
                        {
                            if (groundlist[n].num < 300000)
                            {
                                groundlist[n].num += 400;

                            }
                        }
                        for (int i = 0; i < 16; i++)
                        {
                            if (i == n)
                            {
                                buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                            }
                            else
                            {
                                buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                            }
                        }
                    }
                    else
                    {
                        ShowPage<Tip>("您的魔法粉数量不足");
                    }
                }
                else
                {
                    ShowPage<Tip>("您当前的地块还未种植");
                }
                diamondNumberText.text = DiamondNum.ToString();
                MofafenNumberText.text = maigcNum.ToString();
                break;


            case Status.harvest:
                if (groundlist[n].num > 1000)
                {
                    if (groundlist[n].num/1000 == 1)
                    {
                        DiamondNum += groundlist[n].num % 1000;
                        groundlist[n].num -= groundlist[n].num % 1000;
                    }
                    else
                    {
                        groundlist[n].num -= 1000;
                        DiamondNum += 1000;
                        buttonlist[n].transform.GetChild(0).localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    }

                }
                else
                {
                    ShowPage<Tip>("当前地块的水晶数量不足");
                }
                for (int i = 0; i < 16; i++)
                {
                    if (i == n)
                    {
                        buttonlist[n].transform.GetChild(1).GetComponent<Text>().text = "当前水晶数：" + groundlist[n].num.ToString();
                    }
                    else
                    {
                        buttonlist[i].transform.GetChild(1).GetComponent<Text>().text = "";
                    }
                }
                diamondNumberText.text = DiamondNum.ToString();
                MofafenNumberText.text = maigcNum.ToString();
                break;


            default:
                break;
        }

    }

    public int UnPanelText()
    {
        for (int i = 0; i < groundlist.Count; i++)
        {
            if (groundlist[i].deve == Devestatus.underdevelopment)
            {
                PanelUndevelopment++;
            }
        }
        Paneldevelopment = 16 - PanelUndevelopment;
        return PanelUndevelopment;
    }

    public void PanelText()
    {
        PersonPanel.PersonText(Paneldevelopment, PanelUndevelopment);
    }


}
