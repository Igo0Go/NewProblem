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
        reactorSystem.CurrentMaxEnergy = reactorSystem.GetMaxEnergy();
    }
}

[Serializable]
public class ReactorSystem
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
        acceptors.Add(EngineSystem.Instant);
        acceptors.Add(HealthSystem.Instant);
        acceptors.Add(DoorSystem.Instant);
        acceptors.Add(LightSystem.Instant);
        acceptors.Add(CabinSystem.Instant);
    }
    #endregion

    public bool Energy { get => CurrentEnergy > 0; set { } }
    public int Capasity { get => GetMaxEnergy(); set { } }

    public int CurrentEnergy = 0;
    public int UsedEnergy = 0;

    public int GetMaxEnergy()
    {
        var sum = 0;
        int count = Acceptors.Count();
        for (int i = 0; i < count; i++)
        {
            var ac = Acceptors[i];
            sum += ac.Capasity;
        }
        return sum;
    }

    public List<EnergyRelay> Acceptors { get => acceptors; set => acceptors = value; }
    public List<EnergyRelay> acceptors = new List<EnergyRelay>();


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