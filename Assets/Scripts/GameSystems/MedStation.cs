using System.Collections;
using UnityEngine;


public class MedStation : InterectiveEnergy
{
    [SerializeField] private Transform spawnPoint;

    public GameObject gelPrefab;
    public int MaxCountGel = 10;
    public int CurCountGel = 10;

    public override string GetMessage(ToolController toolController)
    {
        if(CurCountGel <= 0)
        {
            return "Медецинский гель закончился";
        }

        return base.GetMessage(toolController);
    }

    protected override void Command(ToolController toolController = null)
    {
        if(Energy)
        {
            if (CurCountGel > 0)
            {
                CurCountGel--;
                Instantiate(gelPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                defaultMessageChanged?.Invoke();
            }
        }
    }
}
