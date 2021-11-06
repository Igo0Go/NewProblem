using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
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
                foreach (var d in Doors)
                    d.Open = true;
            else
            {
                AutoOxygen = value;
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
            if (!InfiniteSpace)
                AutoOxygen = value;

            energy = value;
        }
    }

    [SerializeField] public bool AutoOxygen = true;

    [SerializeField] private bool energy = true;
    [SerializeField] private bool infiniteSpace = false;

    [Range(1, 10), SerializeField] public float volume = 5;

    // Use this for initialization
    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {

    }
}
