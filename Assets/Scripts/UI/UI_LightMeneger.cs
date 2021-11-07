using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UI_LightMeneger : MonoBehaviour
{
    public UI_Button_CC Power;

    private LightSystem lightSystem = LightSystem.Instant;

    public List<ButtonRoomLight> buttonRooms = new List<ButtonRoomLight>();

    private void Start()
    {

        Power.Init(lightSystem.GetMaxEnergy(), false);

        foreach (var br in buttonRooms)
        {
            br.button.image.color =  (br.roomLight.Energy ? Color.green : Color.white);
            br.button.onClick.AddListener(() => OnButton_Click(br.roomLight, br.button));
        }
    }

    public void OnButton_Click(RoomLight roomLight, Button button)
    {
        var freeEn = lightSystem.CurrentEnergy - lightSystem.UsedEnergy;
        if (freeEn > 0 && !roomLight.Energy)
        {
            roomLight.Energy = true;
            button.image.color = Color.green;
        }
        else if (roomLight.Energy)
        {
            roomLight.Energy = false;
            button.image.color = Color.white;
        }
        Power.SetUsedEn(lightSystem.UsedEnergy);
    }
}
[Serializable]
public class ButtonRoomLight
{
    public Button button;
    public RoomLight roomLight;
}
