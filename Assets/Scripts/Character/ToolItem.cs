using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ToolItem : MonoBehaviour
{
    public ToolTipe type;
    public string toolName;

    public string GetMessage()
    {
        return "E - " + "подобрать " + toolName;
    }
}

public enum ToolTipe
{
    DuctTape = 0,
    Drone = 1,
    FireExtinguisher = 2,
    None = 3
}
