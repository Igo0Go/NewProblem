using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public ToolTipe currentTool;

    [SerializeField] private List<GameObject> itemPrefabs;
    [SerializeField] private List<GameObject> toolObjects;

    private float oxygenValueInCurrentTank;

    public void DropCurrentTool()
    {
        if(currentTool != ToolTipe.None)
        {
            toolObjects.ForEach(g => g.SetActive(false));
            GameObject currentItemPrefab = Instantiate(itemPrefabs[(int)currentTool], transform.position + transform.up + transform.forward, Quaternion.identity);
            if (currentTool == ToolTipe.OxygenTank)
            {
                currentItemPrefab.GetComponent<OxygenTank>().OxygenValue = oxygenValueInCurrentTank;
                oxygenValueInCurrentTank = 0;
            }
            currentTool = ToolTipe.None;
        }
    }

    public void ChangeTool(ToolItem tool)
    {
        DropCurrentTool();
        currentTool = tool.type;

        if(currentTool == ToolTipe.OxygenTank)
        {
            oxygenValueInCurrentTank = tool.gameObject.GetComponent<OxygenTank>().OxygenValue;
        }

        toolObjects[(int)currentTool].SetActive(true);
        Destroy(tool.gameObject);
    }

    public void SpendTool()
    {
        toolObjects.ForEach(g => g.SetActive(false));
        currentTool = ToolTipe.None;
    }
}
