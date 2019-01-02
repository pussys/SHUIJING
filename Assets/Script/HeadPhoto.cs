using System;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine;
using UnityEngine.UI;

public class HeadPhoto : TTUIPage {
    private List<Button> headBtList = new List<Button>();


    public HeadPhoto() : base(UIType.PopUp, UIMode.NeedBack, UICollider.WithBg)
    {
        uiPath = "TXPanel";
    }
    public override void Awake(GameObject go)
    {
        GameObject headFather = transform.Find("List").gameObject;
        for (int i = 0; i < headFather.transform.childCount; i++)
        {
            headBtList.Add(headFather.transform.GetChild(i).GetComponent<Button>());
        }
        foreach (var button in headBtList)
        {
            button.onClick.AddListener(delegate () { OnClick(button.name); });
        }
        transform.Find("Close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
    }

    private void OnCloseClick()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void OnClick(string name)
    {
        GameObject.Find("HeadPhoto").GetComponent<Image>().sprite = Resources.Load(name,typeof(Sprite))as Sprite;
        GameObject.Destroy(this.gameObject);
    }
}
