using System.Collections.Generic;
using UnityEngine;

public class GasPleace : InteractiveObject
{
    public OxygenTank tank;
    [SerializeField] private HealthSystem healthSystem = HealthSystem.Instant;
    // Use this for initialization
    void Start()
    {
        toolForUse = ToolType.None;
    }

    protected override void Command(ToolController toolController = null)
    {
        if (toolForUse == ToolType.OxygenTank)
        {
            tank.gameObject.SetActive(true);

            tank.OxygenValue = toolController.oxygenValueInCurrentTank;
            var neededGas = (healthSystem.maxGas - healthSystem.CurrentStateValue);
            if (tank.OxygenValue >= neededGas)
            {
                healthSystem.CurrentStateValue = healthSystem.maxGas;
                tank.OxygenValue -= neededGas;
            }
            else
            {
                healthSystem.CurrentStateValue += tank.OxygenValue;
                tank.OxygenValue = 0;
            }
            toolController.SpendTool();
            toolForUse = ToolType.None;
        }
        else if (toolForUse == ToolType.None)
        {
            tank.gameObject.SetActive(false);
            toolController.oxygenValueInCurrentTank = tank.OxygenValue;
            
            toolForUse = ToolType.OxygenTank;
            toolController.ChangeTool(toolForUse);
        }
        base.Command();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
