using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class RoomLight : TwoStateInteractiveObject, IHaveEnergy
{
    public bool OnOff
    {
        get
        {
            return onOff;
        }
        set
        {
            ActivateModulesWithChangeState();
            onOff = value;
        }
    }

    public bool Energy
    {
        get
        {
            return energy;
        }
        set
        {
            OnOff = value;
            energy = value;
        }
    }

    public int Capasity { get => capasity; set => capasity = value; }

    [Header("Не трогать")]
    [SerializeField] private bool onOff = false;
    [SerializeField] private bool energy = true;
    [SerializeField] private int capasity = 1;

    private EnergyRelay energyRelay = LightSystem.Instant;

    public override string GetMessage(ToolController toolController)
    {
        if (Energy)
        {
            return base.GetMessage(toolController);
        }
        else
        {
            return "Нет энергии";
        }
    }

    protected override void Command(ToolController toolController = null)
    {
        if (Energy)
            OnOff = !OnOff;
        defaultMessageChanged?.Invoke();
    }
}
