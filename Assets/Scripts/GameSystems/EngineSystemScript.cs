using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EngineSystemScript : MonoBehaviour
{
    public EngineSystem engineSystem = EngineSystem.Instant;
}
[Serializable]
public class EngineSystem : EnergyRelay
{
    public float DistancePerSec = 0.00625f;
    public float DistanceGoal = 10f;
    [SerializeField] private float currentDistance = 0f;
    public float CurrentDistance
    {
        get => currentDistance;
        set
        {
            if (value >= DistanceGoal)
                Goal?.Invoke();
            currentDistance = value;
        }
    }
    public event Action Goal;
    #region singletone

    public static EngineSystem Instant
    {
        get
        {
            if (instant == null)
                instant = new EngineSystem();
            return instant;
        }
        private set
        {
            instant = value;
        }
    }


    private static EngineSystem instant;

    private EngineSystem() { }
    #endregion
    public List<Engine> acceptors = new List<Engine>();

    public override int GetMaxEnergy() => acceptors.Select(c => c.Capasity).Sum();
}

