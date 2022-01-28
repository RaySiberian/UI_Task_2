using UnityEngine;
using UnityEngine.UI;

public class MarketPlaceGUI : MonoBehaviour
{
    public Text MarketName;
    public Slider ManaSlider;
    public Slider CoinsSlider;
    public Slider PotSlider;
    [SerializeField] private GameObject GUIObject;

    public void CloseBtn()
    {
        LevelManager.Instance.DeselectMarketPlace();
        GUIObject.SetActive(false);
    }

    public void SetGUIData(MarketPlace currentMarketPlace)
    {
        MarketName.text = currentMarketPlace.Name;
        CoinsSlider.value = currentMarketPlace.CoinsCount;
        ManaSlider.value = currentMarketPlace.ManaCount;
        PotSlider.value = currentMarketPlace.PotsCount;
    }

    private void Start()
    {
        CoinsSlider.onValueChanged.AddListener(delegate(float newValue)
        {
            LevelManager.Instance.SetValuesFormGui(newValue, ResourceType.Coins);
        });
        ManaSlider.onValueChanged.AddListener(delegate(float newValue)
        {
            LevelManager.Instance.SetValuesFormGui(newValue, ResourceType.Mana);
        });
        PotSlider.onValueChanged.AddListener(delegate(float newValue)
        {
            LevelManager.Instance.SetValuesFormGui(newValue, ResourceType.Pots);
        });
        GUIObject.SetActive(false);
    }
}