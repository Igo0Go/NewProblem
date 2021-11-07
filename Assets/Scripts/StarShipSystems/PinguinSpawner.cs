using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PinguinSpawner : InteractiveObject
{
    private Animator anim;
    private bool opportunityToGetItem;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        opportunityToGetItem = true;
    }

    public override string GetMessage(ToolController toolController)
    {
        if (opportunityToGetItem)
        {
            return "ËÊÌ - " + defaultMessage;
        }
        else
        {
            return "Îם םו דמעמג";
        }
    }

    protected override void Command(ToolController toolController = null)
    {
        if (opportunityToGetItem)
        {
            toolController.ChangeTool(ToolType.DuctTape);
            anim.SetTrigger("Action");
            opportunityToGetItem = false;
            defaultMessageChanged?.Invoke();
        }
    }

    public void OnEndAnimation()
    {
        opportunityToGetItem = true;
        defaultMessageChanged?.Invoke();
    }
}
