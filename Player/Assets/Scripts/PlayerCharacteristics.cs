using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    static int Health;
    static int Hungry;
    static int MaxHealth;
    static int MaxHungry;
    static Animator animator;

    public int _MaxHealth;
    public int _MaxHungry;
    public Animator _animator;
    void Start()
    {
        Health = _MaxHealth;
        Hungry = _MaxHungry;
        MaxHealth = _MaxHealth;
        MaxHungry = _MaxHungry;
        animator = _animator;
    }
    public static void Eat(int HealthAmount, int HungryAmount) //collor of food
    {
        //animation;
        ChangeHealth(HealthAmount);
        ChangeHungry(HungryAmount);

    }
    public static void ChangeHungry(int value)
    {
        Hungry += value;
        if (Hungry > MaxHungry)
            Hungry = MaxHungry;
        if (Hungry <= 0)
        {
            Health += Hungry;
            Hungry = 0;
            Debug.Log("Hungry");
        }

    }
    public static void ChangeHealth(int value)
    {
        Health += value;
        if (Health > MaxHealth)
            Health = MaxHealth;
        if (Health <= 0)
        {
            Debug.Log("DEAD");
        }

    }
   
}
