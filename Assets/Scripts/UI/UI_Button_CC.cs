﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_CC : MonoBehaviour
{
    public GameObject buttonPrefs;
    public List<Button> buttons = new List<Button>();

    public void Init(int qtyButtons)
    {
        for (int i = 0; i < qtyButtons; i++)
        {
            var but = Instantiate(buttonPrefs, this.transform).GetComponent<Button>();
            buttons.Add(but);
        }
    }


    public int OnButton_Click()
    {

    }

    [SerializeField] 
    private int qty;
    [ContextMenu("Init")]
    private void Init2()
    {
        Init(qty);
    }
}
