using UnityEngine;

public class InterectiveEnergy : InteractiveObject, IHaveEnergy
{

    private EnergyRelay energyRelay = CabinSystem.Instant;
    [Range(1, 10)] public int CurrentEnergy = 1;
    [SerializeField] private bool energy = true;
    [SerializeField] private int capasity = 1;
    public bool Energy { get => energy; set { energy = value; ReadyToUse = value; } }
    public int Capasity { get => capasity; set => capasity = value; }

    public override string GetMessage(ToolController toolController)
    {
        if(Energy)
        {
            return base.GetMessage(toolController);
        }
        else
        {
            return "Нет энергии";
        }
    }
}
