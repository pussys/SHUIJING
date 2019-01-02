using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;



/// <summary>
/// 设置面板
/// </summary>
public class SetPanel : TTUIPage {
    private  Slider music;
    private Button savebtn;
    private Button closebtn;


    public SetPanel() : base(UIType.PopUp, UIMode.NeedBack, UICollider.WithBg)
    {
        uiPath = "Set";
    }

    public override void Awake(GameObject go)
    {
        base.Awake(go);

        music = transform.Find("BackMusic").GetComponent<Slider>();
        savebtn = transform.Find("SaveButton").GetComponent<Button>();
        closebtn = transform.Find("ShutButton").GetComponent<Button>();

        closebtn.onClick.AddListener(OnClose);
        savebtn.onClick.AddListener(OnSet);

    }


    public void OnClose()
    {

        Hide();
    }

    public void OnSet()
    {
        GameEntry.BGmusic.volume = music.value;
        ShowPage<Tip>("保存成功！");
    }
}
