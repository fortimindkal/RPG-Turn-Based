using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public GameObject questMenu;
    public GameObject questPrefab;
    public Transform questListContent;

    [Header("Skills")]
    public List<Quests> listQuests;


    void Start()
    {
        DisplayQuest();
    }

    void DisplayQuest()
    {
        foreach (Quests quests in listQuests)
        {
            GameObject questItem = Instantiate(questPrefab, questListContent);

            questItem.transform.GetChild(0).GetComponent<TMP_Text>().text = quests.questName;
            questItem.transform.GetChild(1).GetComponent<TMP_Text>().text = quests.questLevel.ToString();
        }
    }
}
