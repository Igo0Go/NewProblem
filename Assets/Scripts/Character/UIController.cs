using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject suitGroup;
    [SerializeField] private Slider suitEnergySlider;
    [SerializeField] private Image lightIndicator;

    private float targetHealthValue;

    void Awake()
    {
        InteractionController interactionController = FindObjectOfType<InteractionController>();
        HealthPlayer.Damaged += OnGetDamage;
        HealthPlayer.Healed += OnGetHeal;
        HealthPlayer.Dead += OnDead;

        HealthPlayer.ChangeSuitState += OnChangeSuitState;
        HealthPlayer.ChangeLightState += OnChangeLightState;
        HealthPlayer.ChangeSuitEnergy += OnChangeSuitEnergyValue;

        interactionController.changeMessageEvent += ChangeMessage;

        ChangeMessage(string.Empty);
    }

    private void ChangeMessage(string newMessage)
    {
        messageText.text = newMessage;
    }

    private void OnGetDamage(float value)
    {
        MoveSlider(value);
    }

    private void OnGetHeal(float value)
    {
        MoveSlider(value);
    }

    private void OnChangeSuitState(bool state)
    {
        suitGroup.SetActive(state);
    }
    private void OnChangeLightState(bool light)
    {
        lightIndicator.enabled = light;
    }
    private void OnChangeSuitEnergyValue(float value)
    {
        suitEnergySlider.value = value;
    }


    private void OnDead()
    {

    }

    private void MoveSlider(float value)
    {
        targetHealthValue = value;
        StopCoroutine(ChangeHealth());
        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            healthSlider.value = Mathf.Lerp(healthSlider.value, targetHealthValue, t);
            yield return null;
        }
    }
}
