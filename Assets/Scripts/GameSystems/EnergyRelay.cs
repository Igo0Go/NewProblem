using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

[Serializable]
public abstract class EnergyRelay : IHaveEnergy, IHaveMaxEnergy
{
    public bool Energy { get => CurrentEnergy > 0; set { } }
    public int Capasity { get => GetMaxEnergy(); set {  } }

    public int CurrentEnergy = 0;
    public int UsedEnergy = 0;

    public abstract int GetMaxEnergy();
}

public interface IHaveEnergy
{
    bool Energy { get; set; }
    int Capasity { get; set; }
}
public interface IHaveMaxEnergy
{
    abstract int GetMaxEnergy();
}