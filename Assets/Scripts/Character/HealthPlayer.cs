using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;

    [SerializeField] private float curHealth = 100;

    public float CurHealth
    {
        get => curHealth; 
        private set
        {
            curHealth = value;

            if (value <= 0)
                Death();
        }
    }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    public static event Action Damaged;
    public static event Action Healed;
    public static event Action Dead;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDamage(float damage)
    {
        CurHealth -= damage;
        Damaged?.Invoke();
    }

    public void GetHeal(float heal)
    {
        CurHealth += heal;
        Healed?.Invoke();
    }

    public void Death()
    {
        Dead?.Invoke();
    }

}
