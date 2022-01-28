using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public int Mana;
    public int Coins;
    public int Pots;

    [SerializeField] private Text ManaText;
    [SerializeField] private Text CoinsText;
    [SerializeField] private Text PotsText;

    private void Start()
    {
        UpdateDataOnGUI();
    }

    public void UpdateDataOnGUI()
    {
        ManaText.text = Mana.ToString();
        CoinsText.text = Coins.ToString();
        PotsText.text = Pots.ToString();
    }
}
