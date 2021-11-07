using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ToolItem : MonoBehaviour
{
    public ToolTipe type;

    public string GetMessage()
    {
        return "E - " + "��������� " + GetToolName(type);
    }

    public static string GetToolName(ToolTipe type)
    {
        string result = string.Empty;
        switch (type)
        {
            case ToolTipe.DuctTape:
                result = "��������";
                break;
            case ToolTipe.Drone:
                result = "��������� ����";
                break;
            case ToolTipe.FireExtinguisher:
                result = "������������";
                break;
            case ToolTipe.OxygenTank:
                result = "����������� ������";
                break;
        }
        return result;
    }
}

public enum ToolTipe
{
    DuctTape = 0,
    Drone = 1,
    FireExtinguisher = 2,
    OxygenTank = 3,
    None = 4
}
