using System.Collections.Generic;
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
            but.onClick.AddListener(OnButton_Click)
            buttons.Add(but);
        }
    }


    public int OnButton_Click(Button button)
    {
        return buttons.IndexOf(button) + 1;
    }

    [SerializeField]
    private int qty;
    [ContextMenu("Init")]
    private void Init2()
    {
        Init(qty);
    }
}
