using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class UI_DoorManager : MonoBehaviour
{
    public UI_Button_CC Power;

    public Toggle toggleOpen;
    private DoorSystem doorSystem = DoorSystem.Instant;

    public List<ButtonDoor> buttonRooms = new List<ButtonDoor>();
    private void Start()
    {

        Power.Init(doorSystem.GetMaxEnergy(), false);

        foreach (var br in buttonRooms)
        {
            br.button.image.color = (br.door.IsBreak ? Color.red : (br.door.Energy ? (br.door.Open ? Color.green : Color.blue) : Color.black));
            br.button.onClick.AddListener(() => OnButton_Click(br.door, br.button));
        }
    }

    public void OnButton_Click(Door door, Button button)
    {
        if (!door.IsBreak)
            if (toggleOpen.isOn)
            {
                if (!door.Open)
                {
                    door.Open = true;
                    button.image.color = Color.green;
                }
                else
                {
                    door.Open = false;
                    button.image.color = Color.blue;
                }
            }
            else
            {
                var freeEn = doorSystem.CurrentEnergy - doorSystem.UsedEnergy;
                if (freeEn > 0 && !door.Energy)
                {
                    door.Energy = true;
                    button.image.color = Color.green;
                }
                else if (door.Energy)
                {
                    door.Energy = false;
                    button.image.color = Color.black;
                }
                Power.SetUsedEn(doorSystem.UsedEnergy);
            }


    }
}

[Serializable]
public class ButtonDoor
{
    public Button button;
    public Door door;
}

