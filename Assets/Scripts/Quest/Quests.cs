using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quests : ScriptableObject
{
    public string questName;
    public int questLevel;
    public int[] questRewards;
}