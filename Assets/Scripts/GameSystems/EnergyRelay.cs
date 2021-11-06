using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

[Serializable]
public class EnergyRelay
{

    public int CurrentEnergy = 0;
    public int UsedEnergy = 0;
    public int MaxEnergy => Acceptors.Select(a => a.Capasity).Sum();

    public List<IHaveEnergy> Acceptors;
}

public interface IHaveEnergy
{
    bool Energy { get; set; }
    int Capasity { get; set; }
}
