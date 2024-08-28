using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [Header("Unit Reference")]
    public Unit unit;

    [Header("Unit Parameters")]
    [SerializeField] private int currentHP;
    [SerializeField] private int currentMP;
    [SerializeField] private bool defend;

    [Header("Skills")]
    public List<Skill> unitSkills;

    // Start is called before the first frame update
    void Awake()
    {
        InitializeUnity();
    }

    void InitializeUnity()
    {
        currentHP = unit.hp;
        currentMP = unit.mp;
        defend = false;
        unitSkills = new List<Skill>(unit.skills);
    }

    public bool TakeDamage(int damage)
    {
        int actualDamage = damage;

        // If defending, reduce damage by armor value
        if (defend)
        {
            actualDamage -= unit.armor;
            actualDamage = Mathf.Max(0, actualDamage); // Ensure damage doesn't go negative
        }

        currentHP -= actualDamage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public bool UseSkill(int index)
    {
        // Pastikan indeks skill valid
        if (index < 0 || index >= unitSkills.Count)
            return false;

        Skill skill = unitSkills[index];
        // Periksa apakah unit memiliki cukup mana untuk menggunakan keterampilan
        if (skill.manaCost > 0)
        {
            // Lakukan pengecekan jika unit memiliki cukup mana
            // Jika tidak, return false
            // Jika ya, kurangi mana unit dan lanjutkan dengan menggunakan keterampilan
            if (currentMP < skill.manaCost)
            {
                Debug.Log("Not enough mana to use this skill!");
                return false;
            }
            else
            {
                currentMP -= skill.manaCost;
            }
        }

        // Tambahkan kode untuk menerapkan efek keterampilan pada musuh
        // Misalnya, kurangi HP musuh berdasarkan damage keterampilan
        Debug.Log("Using " + skill.skillName);
        return true;
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
