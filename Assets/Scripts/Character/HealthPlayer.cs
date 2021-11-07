using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private int damagePerSeconds = 5;
    [SerializeField] private float maxHealth = 100;

    [SerializeField] private float curHealth = 100;

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
    public static event Action Dead;

    private Collider bufer;


    public void GetDamage(float damage)
    {
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

}
