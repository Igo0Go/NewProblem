using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TwoStateInteractiveObject, IHaveEnergy
{
    [Header("Only two rooms")]
    public List<Room> Rooms = new List<Room>();
    public bool Open
    {
        get
        {
            return open;
        }
        set
        {
            open = value;
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

            if (!value)
            {
                if(Open)
                {
                    ActivateModulesWithChangeState();
                }
                Open = false;
            }

            energy = value;
        }
    }

    public int Capasity { get => capasity; set => capasity = value; }

    [Header("Не трогать")]
    [SerializeField] private bool open = false;
    [SerializeField] private bool energy = true;
    [SerializeField] private int capasity = 1;

    private EnergyRelay energyRelay = HealthSystem.Instant;
    public Room GetOtherRoom(Room room)
    {
        if (Rooms[0] == room)
            return Rooms[1];
        else
            return Rooms[0];
    }

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
        {
            Open = !Open;
            base.Command();
        }
    }
}