using System;
using UnityEngine;

public class MarketPlace : MonoBehaviour
{
    public string Name;
    public int CoinsSpriteCount;
    public GameObject[] Coins;
    public GameObject Pointer;

    public float ManaCount;
    public float CoinsCount;
    public float PotsCount;

    private void Start()
    {
        Pointer.SetActive(false);
        for (int i = 0; i < Coins.Length; i++)
        {
            Coins[i].SetActive(false);
        }

        for (int i = 0; i < CoinsSpriteCount; i++)
        {
            Coins[i].SetActive(true);
        }
    }

    public void SetCoins(int value)
    {
        if (CoinsSpriteCount > value)
        {
            return;
        }
        CoinsSpriteCount = value;
        for (int i = 0; i < CoinsSpriteCount; i++)
        {
            Coins[i].SetActive(true);
        }
    }
    
    public void SendDataToLevelManager()
    {
        LevelManager.Instance.SetCurrentMarketPlace(this);
        HighlightMarketPlace();
    }

    private void HighlightMarketPlace()
    {
        Pointer.SetActive(true);
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void ResetHighlight()
    {
        Pointer.SetActive(false);
        transform.localScale = Vector3.one;
    }
}
