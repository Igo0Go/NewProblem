using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Slider healthSlider;

    private float targetHealthValue;

    void Awake()
    {
        InteractionController interactionController = FindObjectOfType<InteractionController>();
        HealthPlayer.Damaged += OnGetDamage;
        HealthPlayer.Healed += OnGetDamage;
        HealthPlayer.Dead += OnDead;

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

    private void OnGetHeal(int value)
    {
        MoveSlider(value);
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
