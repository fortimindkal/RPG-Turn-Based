using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public int skillDamage;
    public int manaCost;
    public Sprite icon;
}