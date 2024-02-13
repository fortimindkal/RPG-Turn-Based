using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit : ScriptableObject
{
    public string name;
    public int hp;
    public int damage;
    public Sprite image;
}
