using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class GameEntry : MonoBehaviour {
    public static AudioSource BGmusic;


	void Start () {
        TTUIPage.ShowPage<Login>();
        BGmusic = GetComponent<AudioSource>();
	}
    

    void Update () {
        NetMgr.Update();
    }
}
