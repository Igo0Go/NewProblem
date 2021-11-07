using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UI_ReactorManager : MonoBehaviour
{
    public UI_Button_CC Power;
    public Slider Overheat;

    public UI_Button_CC EngineSys;
    public UI_Button_CC HealthSys;
    public UI_Button_CC Cabin_Sys;
    public UI_Button_CC Light_Sys;
    public UI_Button_CC Doors_Sys;

    private ReactorSystem reactorSystem = ReactorSystem.Instant;

    private EngineSystem engineSystem = EngineSystem.Instant;
    private HealthSystem healthSystem = HealthSystem.Instant;
    private CabinSystem cabinSystem = CabinSystem.Instant;
    private LightSystem lightSystem = LightSystem.Instant;
    private DoorSystem doorSystem = DoorSystem.Instant;

    private void Start()
    {
        Overheat.maxValue = reactorSystem.maxOverheat;
        reactorSystem.OverheatChanged += OverheatChanged;

        Power.Init(reactorSystem.GetMaxEnergy());
        EngineSys.Init(engineSystem.GetMaxEnergy());
        HealthSys.Init(healthSystem.GetMaxEnergy());
        Cabin_Sys.Init(cabinSystem.GetMaxEnergy());
        Light_Sys.Init(lightSystem.GetMaxEnergy());
        Doors_Sys.Init(doorSystem.GetMaxEnergy());

        Power.StateChanged += ReactorStateChanged;

        EngineSys.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, engineSystem, b));
        HealthSys.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, healthSystem, b));
        Cabin_Sys.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, cabinSystem, b));
        Light_Sys.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, lightSystem, b));
        Doors_Sys.StateChanged += new Action<int, UI_Button_CC>((c, b) => StateChanged(c, doorSystem, b));
    }
    private void OnDestroy()
    {
        reactorSystem.OverheatChanged -= OverheatChanged;
    }
    public void OverheatChanged(float value)
    {
        Overheat.value = value;
    }
    public void ReactorStateChanged(int state, UI_Button_CC button)
    {
        reactorSystem.CurrentEnergy = state;
        if (reactorSystem.UsedEnergy > reactorSystem.CurrentEnergy)
        {
            StateChanged(0, engineSystem, EngineSys);
            StateChanged(0, healthSystem, HealthSys);
            StateChanged(0, cabinSystem, Cabin_Sys);
            StateChanged(0, lightSystem, Light_Sys);
            StateChanged(0, doorSystem, Doors_Sys);
        }
        button.Colored();
    }

    public void StateChanged(int state, EnergyRelay energyRelay, UI_Button_CC button)
    {
        var freeEn = reactorSystem.CurrentEnergy - reactorSystem.UsedEnergy;
        var changeEn = state - energyRelay.CurrentEnergy;
        if (changeEn > freeEn)
        {
            energyRelay.CurrentEnergy += freeEn;
        }
        else
        {
            energyRelay.CurrentEnergy = state;
        }

        button.IndexCurrEn = energyRelay.CurrentEnergy - 1;

        ReCalcReactorUsedEnergy();

        button.Colored();
    }

    public void ReCalcReactorUsedEnergy()
    {
        reactorSystem.UsedEnergy = reactorSystem.Acceptors.Select(c => c.CurrentEnergy).Sum();
        Power.SetUsedEn(reactorSystem.UsedEnergy);
    }
}
