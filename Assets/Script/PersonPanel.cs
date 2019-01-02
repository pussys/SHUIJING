using System;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;
using UnityEngine.UI;


public class PersonPanel : TTUIPage
{
    private Text nameText;
    private Text phoneText;
    private Text e_mailText;

    private static Text Paneldevelopment1;
    private static Text PanelUndevelopment1;

    public PersonPanel() : base(UIType.PopUp,UIMode.NeedBack,UICollider.Normal)
    {
        uiPath = "IndPanel";
    }

    public override void Awake(GameObject go)
    {
        //nameText = transform.Find("").GetComponent<Text>();
        //phoneText = transform.Find("").GetComponent<Text>();
        //e_mailText = transform.Find("").GetComponent<Text>();

        //transform.Find("UnusedText").GetChild(0).GetComponent<Text>().text = 
        Paneldevelopment1 = transform.Find("UnusedText").GetChild(0).GetComponent<Text>();       
        PanelUndevelopment1 = transform.Find("OrdinaryText").GetChild(0).GetComponent<Text>();
        transform.Find("PortraitButton").GetComponent<Button>().onClick.AddListener(OnHeadClick);
        GameObject.Find("PortraitButton").GetComponent<Image>().sprite = GameObject.Find("HeadPhoto").GetComponent<Image>().sprite;
        transform.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnExitClick);

   
        
    }

    private void OnHeadClick()
    {
        ShowPage<HeadPhoto>();
        GameObject.Destroy(this.gameObject);
    }
    private void OnExitClick()
    {
        GameObject.Destroy(this.gameObject);
    }

    public static void PersonText(int a,int b)
    {
        Paneldevelopment1.text = a.ToString();
        PanelUndevelopment1.text = b.ToString();
    }
}
