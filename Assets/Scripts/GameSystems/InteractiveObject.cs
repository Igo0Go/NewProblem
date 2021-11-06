using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private ToolTipe toolForUse;
    [SerializeField] private string defaultMessage;

    public void Use(ToolController toolController)
    {
        if(toolForUse == ToolTipe.None || toolController.currentTool == toolForUse)
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
            return "��� - " + defaultMessage;
        }
        else
        {
            return "�� �� ������ " + defaultMessage + ". ����� ����������: " + ToolItem.GetToolName(toolForUse);
        }
    }

    protected virtual void Command()
    {
        Debug.Log("������� ���������!");
    }
}
