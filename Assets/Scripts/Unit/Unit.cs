using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit : ScriptableObject
{
    public string unitName;
    public int hp;
    public int level;
    public int damage;
    public Sprite image;
}
