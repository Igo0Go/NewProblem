using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_CC : MonoBehaviour
{
    public GameObject buttonPrefs;
    public List<Button> buttons = new List<Button>();
    public Action<int, UI_Button_CC> StateChanged;
    public int IndexUsedEn { get => indexUsedEn; set => indexUsedEn = value; }
    public int IndexCurrEn { get => indexCurrEn; set => indexCurrEn = value; }
    [SerializeField]
    private int qty;
    private int indexCurrEn = -1;
    private int indexUsedEn = -1;
    public void Init(int qtyButtons, bool interactive = true)
    {
        for (int i = 0; i < qtyButtons; i++)
        {
            var but = Instantiate(buttonPrefs, this.transform).GetComponent<Button>();
            but.onClick.AddListener(() => OnButton_Click(but));
            but.interactable = interactive;
            buttons.Add(but);
        }
    }

    public void SetUsedEn(int usedEn)
    {
        IndexUsedEn = usedEn - 1;
        Colored();
    }

    public void OnButton_Click(Button button)
    {
        var currEn = buttons.IndexOf(button);

        if (currEn == IndexCurrEn)
        {
            IndexCurrEn--;
        }
        else
        {
            IndexCurrEn = currEn;
        }
        StateChanged?.Invoke(IndexCurrEn + 1, this);

    }

    public void Colored()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i <= IndexUsedEn)
                buttons[i].image.color = Color.red;
            else if (i <= IndexCurrEn)
                buttons[i].image.color = Color.green;
            else
                buttons[i].image.color = Color.white;
        }
    }



    [ContextMenu("Init")]
    private void Init2()
    {
        Init(qty);
    }
}
