using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public GameObject skillMenu;
    public GameObject skillPrefab;
    public Transform skillListContent;

    public UnitController playerUnitController;

    void Start()
    {
        DisplaySkills();
    }

    void DisplaySkills()
    {
        foreach (Skill skill in playerUnitController.unitSkills)
        {
            // Instantiate the skill button prefab
            GameObject skillItem = Instantiate(skillPrefab, skillListContent);
            Button skillButton = skillItem.GetComponent<Button>();

            skillItem.transform.GetChild(0).GetComponent<Image>().sprite = skill.icon;
            skillItem.GetComponentInChildren<TMP_Text>().text = skill.skillName;
            skillItem.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => OnSkillButtonClicked(skill));

            Debug.Log(skillItem.transform.GetChild(2).name);
            Debug.Log(skillItem.transform.GetChild(2).GetComponent<Button>().onClick);

            //// Get the Button component
            //Button skillButton = skillButtonGO.GetComponent<Button>();

            //// Set the icon of the skill button
            //skillButton.image.sprite = skill.icon;

            //// Set the name of the skill button
            //skillButton.GetComponentInChildren<Text>().text = skill.skillName;

            //// Add an onClick listener to the button
            //skillButton.onClick.AddListener(() => OnSkillButtonClicked(skill));
        }
    }

    public void OnSkillButtonClicked(Skill skill)
    {
        // Get the index of the clicked skill
        int index = playerUnitController.unitSkills.IndexOf(skill);

        // Use the skill from the player unit controller
        playerUnitController.UseSkill(index);
    }

    public void ShowSkillsMenu()
    {
        if (skillMenu.activeSelf)
            skillMenu.SetActive(false);
        else
            skillMenu.SetActive(true);
    }
}
