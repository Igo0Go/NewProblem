using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ToolItem : MonoBehaviour
{
    public ToolType type;

    public string GetMessage()
    {
        return "E - " + "��������� " + GetToolName(type);
    }

    public static string GetToolName(ToolType type)
    {
        string result = string.Empty;
        switch (type)
        {
            case ToolType.DuctTape:
                result = "��������";
                break;
            case ToolType.Drone:
                result = "��������� ����";
                break;
            case ToolType.FireExtinguisher:
                result = "������������";
                break;
            case ToolType.OxygenTank:
                result = "����������� ������";
                break;
        }
        return result;
    }
}

public enum ToolType
{
    DuctTape = 0,
    Drone = 1,
    FireExtinguisher = 2,
    OxygenTank = 3,
    None = 4
}
