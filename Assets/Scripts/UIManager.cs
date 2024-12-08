using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moneyText;

    private int totalMoney = 0;


    // Initializes the money text display
    void Start()
    {
        UpdateMoneyText();
    }

    // Adds the specified amount of money and updates the display
    public void AddMoney(int amount)
    {
        totalMoney += amount;
        UpdateMoneyText();
    }

    // Updates the money text display with the current total money value
    void UpdateMoneyText()
    {
        moneyText.text = "Money: $" + totalMoney;
    }
}