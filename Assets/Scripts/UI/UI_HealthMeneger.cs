using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthMeneger : MonoBehaviour
{
    public UI_Button_CC Power;

    private HealthSystem healthSystem = HealthSystem.Instant;
    public Text text;

    public List<ButtonRoom> buttonRooms = new List<ButtonRoom>();
    private void Start()
    {

        Power.Init(healthSystem.GetMaxEnergy(), false);

        UpdateText();
        foreach (var br in buttonRooms)
        {
            br.button.image.color = (br.room.InfiniteSpace ? Color.red : (br.room.Energy ? Color.green : Color.white));
            br.button.onClick.AddListener(() => ORoomButton_Click(br.room, br.button));
        }
    }

    public void ORoomButton_Click(Room room, Button button)
    {
        var freeEn = healthSystem.CurrentEnergy - healthSystem.UsedEnergy;
        if (freeEn > 0 && !room.Energy && room.InfiniteSpace)
        {
            room.Energy = true;
            button.image.color = Color.green;
        }
        else if (room.Energy)
        {
            room.Energy = false;
            button.image.color = Color.white;
        }
        Power.SetUsedEn(healthSystem.UsedEnergy);
    }

    public void UpdateText()
    {
        text.text = healthSystem.CurrentStateValue.ToString();
    }

}
[Serializable]
public class ButtonRoom
{
    public Button button;
    public Room room;
}
