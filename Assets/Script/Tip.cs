using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class Tip : TTUIPage {

    private Text mytext;
    private Button knowBtn;
    private Button closeBtn;
    string str = "";



    public Tip() : base(UIType.PopUp, UIMode.HideOther, UICollider.Normal)
    {
        uiPath = "Tip";
    }
    public override void Awake(GameObject go)
    {
        mytext = transform.Find("Text").GetComponent<Text>();
        knowBtn = transform.Find("KnowBtn").GetComponent<Button>();
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();
        str = data.ToString();
        mytext.text = data.ToString();
        knowBtn.onClick.AddListener(OnKnowClick);
        closeBtn.onClick.AddListener(OnKnowClick);
    }

    private void OnKnowClick()
    {
        GameObject.Destroy(this.gameObject);
    }
}
