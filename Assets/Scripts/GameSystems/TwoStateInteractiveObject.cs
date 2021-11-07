using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStateInteractiveObject : InteractiveObject
{
    [SerializeField] private List<LogicModule> modules;

    [SerializeField] private string secondStateMessage;

    private bool firstState = true;
    private string firstStateMessage;

    private void Awake()
    {
        firstStateMessage = defaultMessage;
    }

    protected override void Command(ToolController toolController = null)
    {
        firstState = !firstState;
        defaultMessage = firstState ? firstStateMessage : secondStateMessage;
        defaultMessageChanged?.Invoke();

        for (int i = 0; i < modules.Count; i++)
        {
            if (modules[i] != null)
            {
                modules[i].ActivateModule();
            }
        }
    }
}
