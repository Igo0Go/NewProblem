using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[RequireComponent(typeof(Collider))]
public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private ToolTipe toolForUse;
    [SerializeField] protected string defaultMessage;

    public bool ReadyToUse = false;

    public Action defaultMessageChanged;

    public void Use(ToolController toolController)
    {
        if((toolForUse == ToolTipe.None || toolController.currentTool == toolForUse) && ReadyToUse)
        {
            Command();
            if(toolForUse != ToolTipe.Drone)
            {
                toolController.SpendTool();
            }
        }
    }

    public string GetMessage(ToolController toolController)
    {
        if (toolForUse == ToolTipe.None || toolController.currentTool == toolForUse)
        {
            return "ЛКМ - " + defaultMessage;
        }
        else
        {
            return "Вы не можете " + defaultMessage + ". Нужен инструмент: " + ToolItem.GetToolName(toolForUse);
        }
    }

    protected virtual void Command()
    {
        Debug.Log("Команда выполнена!");
    }
}
