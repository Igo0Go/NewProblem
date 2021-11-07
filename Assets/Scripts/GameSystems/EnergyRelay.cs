using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

[Serializable]
public abstract class EnergyRelay : IHaveEnergy, IHaveMaxEnergy
{
    public bool Energy { get => CurrentEnergy > 0; set { } }
    public int Capasity { get => GetMaxEnergy(); set { } }

    public virtual int CurrentEnergy { get => currentEnergy; set => currentEnergy = value; }
    public virtual int UsedEnergy { get => usedEnergy; set => usedEnergy = value; }
    [SerializeField] private int currentEnergy;
    [SerializeField] private int usedEnergy;

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