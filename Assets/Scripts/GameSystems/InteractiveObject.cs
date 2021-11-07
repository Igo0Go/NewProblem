using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[RequireComponent(typeof(Collider))]
public class InteractiveObject : MonoBehaviour
{
    [SerializeField] protected ToolType toolForUse;
    [SerializeField] protected string defaultMessage;

    public bool ReadyToUse = true;

    public Action defaultMessageChanged;

    public void Use(ToolController toolController)
    {
        if((toolForUse == ToolType.None || toolController.currentTool == toolForUse) && ReadyToUse)
        {
            if (toolForUse != ToolType.None)
                toolController.SpendTool();
            
            Command(toolController);
           
        }
    }

    public string GetMessage(ToolController toolController)
    {
        if (toolForUse == ToolType.None || toolController.currentTool == toolForUse)
        {
            return "ЛКМ - " + defaultMessage;
        }
        else
        {
            return "Вы не можете " + defaultMessage + ". Нужен инструмент: " + ToolItem.GetToolName(toolForUse);
        }
    }

    protected virtual void Command(ToolController toolController = null)
    {
        Debug.Log("Команда выполнена!");
    }
}
