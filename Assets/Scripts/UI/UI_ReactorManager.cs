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

    private void Awake()
    {
        Overheat.maxValue = reactorSystem.maxOverheat;
        reactorSystem.OverheatChanged += OverheatChanged;

        Power.Init(reactorSystem.MaxEnergy);
        EngineSys.Init(engineSystem.MaxEnergy);
        HealthSys.Init(healthSystem.MaxEnergy);
        Cabin_Sys.Init(cabinSystem.MaxEnergy);
        Light_Sys.Init(lightSystem.MaxEnergy);
        Doors_Sys.Init(doorSystem.MaxEnergy);
    }
    private void OnDestroy()
    {
        reactorSystem.OverheatChanged -= OverheatChanged;
    }
    public void OverheatChanged(float value)
    {
        Overheat.value = value;
    }
}
