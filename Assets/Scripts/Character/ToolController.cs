using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public ToolTipe currentTool;

    [SerializeField] private List<GameObject> itemPrefabs;
    [SerializeField] private List<GameObject> toolObjects;

    public void DropCurrentTool()
    {
        if(currentTool != ToolTipe.None)
        {
            toolObjects.ForEach(g => g.SetActive(false));
            Instantiate(itemPrefabs[(int)currentTool], transform.position + transform.up + transform.forward, Quaternion.identity);
            currentTool = ToolTipe.None;
        }
    }

    public void ChangeTool(ToolItem tool)
    {
        DropCurrentTool();
        currentTool = tool.type;

        toolObjects[(int)currentTool].SetActive(true);
        Destroy(tool.gameObject);
    }
}
