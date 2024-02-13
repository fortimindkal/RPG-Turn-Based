using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Image image;

    public void SetHUD(UnitController unit)
    {
        nameText.text = unit.unit.name;
        hpText.text = unit.unit.hp.ToString();
        image.sprite = unit.unit.image;
    }

    public void SetHP(int hp)
    {
        hpText.text = hp.ToString();
    }
}
