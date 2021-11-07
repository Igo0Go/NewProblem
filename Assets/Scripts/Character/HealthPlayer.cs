using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float curHealth = 100;
    public float suitCurrentEnergy = 100;
    [SerializeField] private int damagePerSeconds = 5;
    [SerializeField] private float energyPerMinutes = 5;
    [SerializeField] private float lightEnergyPerMinutes = 5;
    [SerializeField] private GameObject lightObject;

    private bool useSuit;
    private bool useLight;

    public float CurHealth
    {
        get => curHealth; 
        private set
        {
            curHealth = value;

            if(curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }

            if (value <= 0)
                Death();
        }
    }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    public static event Action<float> Damaged;
    public static event Action<float> Healed;
    public static event Action<bool> ChangeSuitState;
    public static event Action<bool> ChangeLightState;
    public static event Action<float> ChangeSuitEnergy;

    public static event Action Dead;

    private Collider bufer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && useSuit)
        {
            if(useLight)
            {
                LightOff();
            }
            else
            {
                LightOn();
            }
        }
    }

    public void GetDamage(float damage)
    {
        if(useSuit && suitCurrentEnergy > 0)
        {
            suitCurrentEnergy -= damage;
            ChangeSuitEnergy?.Invoke(suitCurrentEnergy);
            return;
        }

        CurHealth -= damage;
        Damaged?.Invoke(CurHealth);
    }

    public void GetHeal(float heal)
    {
        CurHealth += heal;
        Healed?.Invoke(CurHealth);
    }

    public void Death()
    {
        Dead?.Invoke();
    }

    public void PutOnSuit(float energy)
    {
        suitCurrentEnergy = energy;
        useSuit = true;
        ChangeSuitState?.Invoke(useSuit);
        StartCoroutine(SpendEnergy());
    }

    public void TakeOffSuit()
    {
        LightOff();
        useSuit = false;
        ChangeSuitState?.Invoke(useSuit);
        StopCoroutine(SpendEnergy());
    }

    private void LightOn()
    {
        if(suitCurrentEnergy > 0)
        {
            useLight = true;
            lightObject.SetActive(useLight);
            ChangeLightState(useLight);
        }
    }
    private void LightOff()
    {
        useLight = false;
        lightObject.SetActive(useLight);
        ChangeLightState(useLight);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DamageZone"))
        {
            if(bufer == null)
            {
                bufer = other;
                StartCoroutine(DamagePerUnit());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DamageZone"))
        {
            if (other == bufer)
            {
                StopCoroutine(DamagePerUnit());
                bufer = null;
            }
        }
    }

    private IEnumerator DamagePerUnit()
    {
        while(bufer != null)
        {
            GetDamage(damagePerSeconds);
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator SpendEnergy()
    {
        while(suitCurrentEnergy > 0)
        {
            suitCurrentEnergy -= (energyPerMinutes / 60 * Time.deltaTime);

            if(useLight)
            {
                suitCurrentEnergy -= (lightEnergyPerMinutes / 60 * Time.deltaTime);
            }

            ChangeSuitEnergy?.Invoke(suitCurrentEnergy);

            yield return null;
        }

        LightOff();
    }
}
