using System.Collections;
using UnityEngine;


public class MedStation : InterectiveEnergy
{
    public GameObject gelPrefab;
    public int MaxCountGel = 10;
    public int CurCountGel = 10;

    protected override void Command()
    {
        base.Command();
        CurCountGel--;
        Debug.Log("дать игроку гель");
    }
}
