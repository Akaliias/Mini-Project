using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moneyText;

    private int totalMoney = 0;

    void Start()
    {
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        totalMoney += amount;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        moneyText.text = "Money: $" + totalMoney;
    }
}