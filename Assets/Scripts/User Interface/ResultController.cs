using UnityEngine;
using TMPro;

public class ResultController : MonoBehaviour
{
    [SerializeField] TMP_Text conditionText;
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text expText;

    public void ShowResultMenu(GameManager result)
    {
        if(result.currentState == GameState.Won)
        {
            conditionText.text = "You won!";
            goldText.text = "Gold : " + result.goldRewards.ToString();
            expText.text = "Exp : " + result.expRewards.ToString();
        }
        else if(result.currentState == GameState.Lost)
        {
            conditionText.text = "You lost!";
        }
        gameObject.SetActive(true);
    }
}
