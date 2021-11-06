using System.Collections;
using UnityEngine;

public class Engine : MonoBehaviour, IHaveEnergy
{
    public float DistancePerSec = 0.00625f;

    private EngineSystem energyRelay = EngineSystem.Instant;

    [Range(1, 10)] public int CurrentEnergy = 1;

    [SerializeField] private bool energy = true;
    [SerializeField] private int capasity = 8;
    public bool Energy { get => energy; set { energy = value; } }
    public int Capasity { get => capasity; set => capasity = value; }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Energy)
        {
            energyRelay.CurrentDistance += CurrentEnergy * DistancePerSec * Time.fixedDeltaTime;
        }
    }
}
