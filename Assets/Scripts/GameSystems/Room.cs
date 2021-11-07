using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, IHaveEnergy
{
    public List<Door> Doors = new List<Door>();

    public bool InfiniteSpace
    {
        get
        {
            return infiniteSpace;
        }
        set
        {
            if (value)
            {
                foreach (var d in Doors)
                    d.Open = false;
                oxygen = false;
            }
            else
            {
                Energy = false;
            }


            InfiniteSpace = value;
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
            AutoOxygen = value;
            energy = value;
        }
    }
    public bool AutoOxygen
    {
        get
        {
            return autoOxygen;
        }
        set
        {
            if (!oxygen)
            {
                oxygen = true;
            }

            
            autoOxygen = value;
        }
    }

    public int Capasity { get => capasity; set => capasity = value; }

    [Range(1, 10), SerializeField] public float volume = 5;
    [Range(1, 10), SerializeField] private int capasity = 1;

    [Header("Не трогать")]
    [SerializeField] public bool autoOxygen = true;
    [SerializeField] private bool oxygen = true;

    [SerializeField] private bool energy = true;
    [SerializeField] private bool infiniteSpace = false;



    private EnergyRelay energyRelay = HealthSystem.Instant;

    // Use this for initialization
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {

    }
}
