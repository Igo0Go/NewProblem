using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class UI_CabinManager : MonoBehaviour
{
    public UI_Button_CC Power;
    public UI_Button_CC PowerMedPack;
    public UI_Button_CC PowerAcraSuit;

    private CabinSystem cabinSystem = CabinSystem.Instant;

    private void Start()
    {

        Power.Init(cabinSystem.GetMaxEnergy(),false);
        PowerMedPack.Init(cabinSystem.acceptors[0].Capasity);
        PowerAcraSuit.Init(cabinSystem.acceptors[1].Capasity);

        Power.SetUsedEn(cabinSystem.UsedEnergy);

        PowerMedPack.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, cabinSystem.acceptors[0], b));
        PowerAcraSuit.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, cabinSystem.acceptors[1], b));

    }



    public void StateChanged(int state, InterectiveEnergy interectiveEnergy, UI_Button_CC button)
    {
        var freeEn = cabinSystem.CurrentEnergy - cabinSystem.UsedEnergy;
        var changeEn = state - interectiveEnergy.CurrentEnergy;
        if (changeEn > freeEn)
        {
            interectiveEnergy.CurrentEnergy += freeEn;
        }
        else
        {
            interectiveEnergy.CurrentEnergy = state;
        }

        button.IndexCurrEn = interectiveEnergy.CurrentEnergy - 1;

        button.Colored();
        Power.SetUsedEn(cabinSystem.UsedEnergy);
    }

}
