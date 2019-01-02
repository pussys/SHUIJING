using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public InputField inputTest;
    public Button testBtn;
    public bool isusername = false;
	// Use this for initialization
	void Start () {
        inputTest = GameObject.Find("InputField").GetComponent<InputField>();
        testBtn = GameObject.Find("testBt").GetComponent<Button>();
        testBtn.onClick.AddListener(btTest);
	}

    private void btTest()
    {
        foreach (byte item in inputTest.text)
        {
            if ((int)item >= 48 && (int)item <= 57 || (int)item >= 65 && (int)item <= 90 || (int)item >= 97 && (int)item <= 122 || (int)item == 95)
            {
                isusername = true;
            }
            else
            {
                isusername = false;
            }
        }
        if (isusername == true)
        {
            Debug.Log("对了");
        }
        else
        {
            Debug.Log("错了");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
