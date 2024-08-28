using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit : ScriptableObject
{
    public string unitName;
    public int hp;
    public int mp;
    public int level;
    public int damage;
    public int armor;
    public Sprite image;
    public List<Skill> skills;
}
