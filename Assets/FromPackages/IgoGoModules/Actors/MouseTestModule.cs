using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Модуль для тестирования
/// </summary>
[HelpURL("https://docs.google.com/document/d/1ft866-BaExr--4YvxKyAUX0_sCJJdJtuhQvI5Hnp_KE/edit?usp=sharing")]
public class MouseTestModule : LogicActor
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ActivateModule();
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            ReturnToDefaultState();
            return;
        }
    }

    public override void ActivateModule()
    {
        ActivateAllNextModules();
    }

    public override void ReturnToDefaultState()
    {
        AllNextModulesToDefaultState();
    }
}
