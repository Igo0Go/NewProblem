using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CabinSystemScript : MonoBehaviour
{
    public CabinSystem cabinSystem = CabinSystem.Instant;
}

[Serializable]
public class CabinSystem : EnergyRelay
{
    #region singletone

    public static CabinSystem Instant
    {
        get
        {
            if (instant == null)
                instant = new CabinSystem();
            return instant;
        }
        private set
        {
            instant = value;
        }
    }
    private static CabinSystem instant;

    private CabinSystem() { }
    #endregion

    public new List<InterectiveEnergy> Acceptors = new List<InterectiveEnergy>();
}

