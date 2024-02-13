using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [Header("Unit Reference")]
    public Unit unit;

    [Header("Unit Parameters")]
    [SerializeField] private int currentHP;
    [SerializeField] private bool defend;

    // Start is called before the first frame update
    void Start()
    {
        InitializeUnity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeUnity()
    {
        currentHP = unit.hp;
        defend = false;
    }

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public int GetDamage()
    {
        return unit.damage;
    }

    public int GetHP()
    {
        return currentHP;
    }

    public void Defend(bool value)
    {
        defend = value;
    }

    public bool IsDefend()
    {
        return defend;
    }
}
