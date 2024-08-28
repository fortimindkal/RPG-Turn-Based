using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] Slider hpBar;
    [SerializeField] Image image;

    public void SetHUD(UnitController unit)
    {
        nameText.text = unit.unit.name;
        hpBar.value = unit.GetHP();
        hpBar.maxValue = unit.unit.hp;
        image.sprite = unit.unit.image;
    }

    public void SetHP(int hp)
    {
        hpBar.value = hp;
    }
}
