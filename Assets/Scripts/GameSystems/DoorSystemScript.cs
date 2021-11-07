using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DoorSystemScript : MonoBehaviour
{
    public DoorSystem doorSystem = DoorSystem.Instant;
}

[Serializable]
public class DoorSystem : EnergyRelay
{
    #region singletone

    public static DoorSystem Instant
    {
        get
        {
            if (instant == null)
                instant = new DoorSystem();
            return instant;
        }
        private set
        {
            instant = value;
        }
    }
    private static DoorSystem instant;

    private DoorSystem()    {    }
    #endregion
    public List<Door> acceptors = new List<Door>();

    public override int GetMaxEnergy() => acceptors.Select(c => c.Capasity).Sum();
}
