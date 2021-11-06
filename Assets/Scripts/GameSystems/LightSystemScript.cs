using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LightSystemScript : MonoBehaviour
{
    public LightSystem lightSystem = LightSystem.Instant;
}
[Serializable]
public class LightSystem : EnergyRelay
{
    #region singletone

    public static LightSystem Instant
    {
        get
        {
            if (instant == null)
                instant = new LightSystem();
            return instant;
        }
        private set
        {
            instant = value;
        }
    }
    private static LightSystem instant;

    private LightSystem() { }
    #endregion

    public new List<RoomLight> Acceptors = new List<RoomLight>();
}
