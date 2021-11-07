using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakdown : InteractiveObject
{
    [SerializeField] private UnityEvent afterCommandEvent;

    protected override void Command(ToolController toolController = null)
    {
        afterCommandEvent?.Invoke();
    }
}
