using System.Collections;
using UnityEngine;

public class UI_CC_MainPanel : MonoBehaviour
{
    //public GameObject ReactMenedger;
    //public GameObject DoorsMenedger;
    //public GameObject LightMenedger;
    //public GameObject HealthMenedger;
    //public GameObject EngineMenedger;
    //public GameObject CabinMenedger;


    public void SetActivePanel(GameObject selectActivePanel)
    {
        this.gameObject.SetActive(false);
        selectActivePanel.SetActive(true);
    }
}
