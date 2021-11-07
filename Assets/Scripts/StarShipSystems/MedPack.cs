using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPack : InteractiveObject
{
    [SerializeField, Range(1,100)] private int healValue;

    protected override void Command(ToolController toolController = null)
    {
        toolController.GetComponent<HealthPlayer>().GetHeal(healValue);
        Destroy(gameObject);
    }
}
