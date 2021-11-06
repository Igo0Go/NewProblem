using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TwoStateInteractiveObject
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
                Open = false;

            energy = value;
        }
    }

    [SerializeField] private bool open = false;
    [SerializeField] private bool energy = true;
    public Room GetOtherRoom(Room room)
    {
        if (Rooms[0] == room)
            return Rooms[1];
        else
            return Rooms[0];
    }

    protected override void Command()
    {
        base.Command();

        if (Energy)
            Open = !Open;
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
