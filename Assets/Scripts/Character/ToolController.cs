using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public ToolType currentTool;

    [SerializeField] private List<GameObject> itemPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> toolObjects = new List<GameObject>();

    public float oxygenValueInCurrentTank;

    public void DropCurrentTool()
    {
        if (currentTool != ToolType.None)
        {
            toolObjects.ForEach(g => g.SetActive(false));
            GameObject currentItemPrefab = Instantiate(itemPrefabs[(int)currentTool], transform.position + transform.up + transform.forward, Quaternion.identity);
            if (currentTool == ToolType.OxygenTank)
            {
                currentItemPrefab.GetComponent<OxygenTank>().OxygenValue = oxygenValueInCurrentTank;
                oxygenValueInCurrentTank = 0;
            }
            currentTool = ToolType.None;
        }
    }

    public void ChangeTool(ToolItem tool)
    {
        DropCurrentTool();
        currentTool = tool.type;

        if (currentTool == ToolType.OxygenTank)
        {
            oxygenValueInCurrentTank = tool.gameObject.GetComponent<OxygenTank>().OxygenValue;
        }

        toolObjects[(int)currentTool].SetActive(true);
        Destroy(tool.gameObject);
    }

    public void ChangeTool(ToolType tool)
    {
        DropCurrentTool();
        currentTool = tool;

        toolObjects[(int)currentTool].SetActive(true);
    }

    public void SpendTool()
    {
        toolObjects.ForEach(g => g.SetActive(false));
        currentTool = ToolType.None;
    }
}
