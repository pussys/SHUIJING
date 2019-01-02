using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class trueOrFalse : TTUIPage
{

    private Text mytext;
    private Button yesBtn;
    private Button closeBtn;
    private Button noBtn;
    string str = "";
    public static bool yesno = false;


    public trueOrFalse() : base(UIType.PopUp, UIMode.HideOther, UICollider.Normal)
    {
        uiPath = "isKaiken";
    }
    public override void Awake(GameObject go)
    {
        mytext = transform.Find("Text").GetComponent<Text>();
        yesBtn = transform.Find("KnowBtn").GetComponent<Button>();
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();
        noBtn = transform.Find("noButn").GetComponent<Button>();
        str = data.ToString();
        mytext.text = data.ToString();
        yesBtn.onClick.AddListener(OnyesClick);
        closeBtn.onClick.AddListener(OnnoClick);
        noBtn.onClick.AddListener(OnnoClick);
    }

    private void OnyesClick()
    {
        yesno = true;
        #region
        //List<Button> groundlist = new List<Button>();

        //GameObject buttonFather = GameObject.Find("ButtonFather");
        //for (int j = 0; j < buttonFather.transform.childCount; j++)
        //{
        //    groundlist.Add(buttonFather.transform.GetChild(j).GetComponent<Button>());
        //}
        //int i = int.Parse(name);
        //GameObject GO = GameObject.Find(name);
        //if (GameObject.Find(name).tag == "nokaiken")
        //{
        //    if (GO.tag == "nokaiken" && yesno == true)
        //    {
        //        //并且钱够 需要数据库

        //        GO.GetComponent<Image>().color = UnityEngine.Color.white;
        //        if (i <= 9)
        //        {
        //            groundlist[i].GetComponent<Image>().sprite = Resources.Load("common", typeof(Sprite)) as Sprite;
        //        }
        //        if (i >= 10 && i <= 15)
        //        {
        //            groundlist[i].GetComponent<Image>().sprite = Resources.Load("gold", typeof(Sprite)) as Sprite;
        //        }
        //        GO.tag = "yeskaiken";
        //        yesno = false;
        //    }
        //}
        #endregion
        GameObject.Destroy(this.gameObject);
    }
    private void OnnoClick()
    {
        GameObject.Destroy(this.gameObject);
    }
}
