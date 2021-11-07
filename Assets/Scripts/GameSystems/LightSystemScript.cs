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
    public List<RoomLight> acceptors = new List<RoomLight>();

    public override int GetMaxEnergy() => acceptors.Select(c => c.Capasity).Sum();
    public override int UsedEnergy { get => acceptors.Where(c => c.Energy).Select(c => c).Count(); }
}
