using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private MarketPlaceGUI marketPlaceGUI;
    [SerializeField] private GameObject GUIObject;
    //[SerializeField] private Resources resources;
    private MarketPlace currentMarketPlace;

    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentMarketPlace.SetCoins(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentMarketPlace.SetCoins(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentMarketPlace.SetCoins(3);
        }
    }

    public void SetCurrentMarketPlace(MarketPlace marketPlace)
    {
        currentMarketPlace?.ResetHighlight();
        currentMarketPlace = marketPlace;
        FillMarketPlaceData();
    }

    //Кастыль нечеловеческий
    public void SetValuesFormGui(float value, ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Coins:
                currentMarketPlace.CoinsCount = value;
                break;
            case ResourceType.Mana:
                currentMarketPlace.ManaCount = value;
                break;
            case ResourceType.Pots:
                currentMarketPlace.PotsCount = value;
                break;
        }
    }

    public void DeselectMarketPlace()
    {
        currentMarketPlace?.ResetHighlight();
    }

    private void FillMarketPlaceData()
    {
        GUIObject.SetActive(true);
        marketPlaceGUI.SetGUIData(currentMarketPlace);
    }
}

public enum ResourceType
{
    Coins,
    Mana,
    Pots
}