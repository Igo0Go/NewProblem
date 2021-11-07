using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class RoomLight : TwoStateInteractiveObject, IHaveEnergy
{
    public List<Light> Lights = new List<Light>();
    public bool OnOff
    {
        get
        {
            return onOff;
        }
        set
        {
            foreach(var l in Lights)
            {
                l.enabled = value;
            }
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
            if (value)
            {
                energyRelay.UsedEnergy--;
            }
            else
            {
                energyRelay.UsedEnergy++;
            }

            if (value)
                OnOff = false;

            energy = value;
        }
    }

    public int Capasity { get => capasity; set => capasity = value; }

    [Header("Не трогать")]
    [SerializeField] private bool onOff = false;
    [SerializeField] private bool energy = true;
    [SerializeField] private int capasity = 1;

    private EnergyRelay energyRelay = LightSystem.Instant;

    protected override void Command(ToolController toolController = null)
    {
        base.Command();

        if (Energy)
            OnOff = !OnOff;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
