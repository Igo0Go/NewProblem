using UnityEngine;

public class InterectiveEnergy : InteractiveObject, IHaveEnergy
{

    private EnergyRelay energyRelay = CabinSystem.Instant;
    [SerializeField] private bool energy = true;
    [SerializeField] private int capasity = 1;
    public bool Energy { get => energy; set { energy = value; ReadyToUse = value; } }
    public int Capasity { get => capasity; set => capasity = value; }

}
