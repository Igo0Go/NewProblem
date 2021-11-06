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
    public int CurrentStateValue
    {
        get
        {
            return currentStateValue;
        }
        set
        {
            if (currentStateValue <= maxGas)
                NeedGas?.Invoke();

            currentStateValue = value;
        }
    }
    [SerializeField] private int currentStateValue = 100;
    public int maxGas = 100;
    public event Action NeedGas;
}


