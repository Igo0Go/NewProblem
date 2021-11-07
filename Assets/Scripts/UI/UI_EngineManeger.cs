using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class UI_EngineManeger : MonoBehaviour
{
    public UI_Button_CC Power;
    private EngineSystem engineSystem = EngineSystem.Instant;

    public Text text;

    private void Start()
    {
        Power.Init(engineSystem.GetMaxEnergy(),false);
        Power.IndexCurrEn = engineSystem.CurrentEnergy - 1;
        Power.Colored();
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = (engineSystem.DistancePerSec * engineSystem.CurrentEnergy).ToString();
    }
}
