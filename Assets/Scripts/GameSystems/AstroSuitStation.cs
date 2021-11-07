using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AstroSuitStation : InterectiveEnergy
{
    [SerializeField] private GameObject helmet;
    [Range(1, 10)] public int CurrentEnergy = 1;
    [Range(1, 10)] public int ChargePerEnergy = 3;
    public int CurrentCharge => CurrentEnergy * ChargePerEnergy;
    [SerializeField] private Slider chargeValueSlider;
    [SerializeField] private float maxSuitEnergy;

    //hi

    private void Awake()
    {
        currentSuitEnergy = maxSuitEnergy;
    }

    private bool containsSuit = true;
    private float currentSuitEnergy;

    public override string GetMessage(ToolController toolController)
    {
        if(containsSuit)
        {
            if(Energy)
            {
                if(currentSuitEnergy < maxSuitEnergy)
                {
                    return "Заряжается. " + base.GetMessage(toolController);
                }
                else
                {
                    return "Заряжено. " + base.GetMessage(toolController);
                }
            }
            else
            {
                return "Нет энергии";
            }
        }

        return base.GetMessage(toolController);
    }

    protected override void Command(ToolController toolController = null)
    {
        HealthPlayer player = toolController.GetComponent<HealthPlayer>();

        if(containsSuit)
        {
            containsSuit = false;
            player.PutOnSuit(currentSuitEnergy);
            helmet.SetActive(false);
            defaultMessage = "Поставить скафандр на зарядку.";
            StopAllCoroutines();
            chargeValueSlider.value = 0;
        }
        else
        {
            containsSuit = true;
            currentSuitEnergy = player.suitCurrentEnergy;
            player.TakeOffSuit();
            helmet.SetActive(true);
            defaultMessage = "Надеть скафандр.";
            StartCoroutine(ChargeSuit());
        }
    }

    private IEnumerator ChargeSuit()
    {
        if (CurrentEnergy != maxSuitEnergy)
        {
            while (currentSuitEnergy < maxSuitEnergy)
            {
                if (Energy)
                {
                    currentSuitEnergy += CurrentCharge * Time.deltaTime;
                    chargeValueSlider.value = currentSuitEnergy;
                    yield return null;
                }
            }
            defaultMessageChanged?.Invoke();
        }
    }
}
