using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class HealthSystemScript : MonoBehaviour
{
    public HealthSystem healSystem = HealthSystem.Instant;
}

[Serializable]
public class HealthSystem : EnergyRelay
{
    #region singletone

    public static HealthSystem Instant
    {
        get
        {
            if (instant == null)
                instant = new HealthSystem();
            return instant;
        }
        set
        {
            instant = value;
        }
    }
    private static HealthSystem instant;

    private HealthSystem() { }
    #endregion

    public new List<Room> Acceptors = new List<Room>();
    public float CurrentStateValue
    {
        get
        {
            return currentGasValue;
        }
        set
        {
            if (currentGasValue <= 0)
                NeedGas?.Invoke();

            currentGasValue = value;
        }
    }
    [SerializeField] private float currentGasValue = 100;
    public float maxGas = 100;

    public event Action NeedGas;
}


