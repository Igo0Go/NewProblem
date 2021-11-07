using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ReactorSystemScript : MonoBehaviour
{
    [SerializeField]
    public ReactorSystem reactorSystem = ReactorSystem.Instant;
    private void Start()
    {
        reactorSystem.CurrentMaxEnergy = reactorSystem.MaxEnergy;
    }
}

[Serializable]
public class ReactorSystem : EnergyRelay
{
    #region singletone

    public static ReactorSystem Instant
    {
        get
        {
            if (instant == null)
                instant = new ReactorSystem();
            return instant;
        }
        set
        {
            instant = value;
        }
    }


    private static ReactorSystem instant;

    private ReactorSystem() 
    {
        Acceptors.Add(HealthSystem.Instant);
        Acceptors.Add(DoorSystem.Instant);
        Acceptors.Add(LightSystem.Instant);
        Acceptors.Add(CabinSystem.Instant);
        Acceptors.Add(EngineSystem.Instant);
    }
    #endregion

    public new List<EnergyRelay> Acceptors = new List<EnergyRelay>();

    public int CurrentMaxEnergy;

    public float CurOverheat
    {
        get => curOverheat; 
        set
        {
            OverheatChanged?.Invoke(value);
            curOverheat = value;
        }
    }
    public Action<float> OverheatChanged;
    private float curOverheat = 0f;
    public float maxOverheat = 100f;

}