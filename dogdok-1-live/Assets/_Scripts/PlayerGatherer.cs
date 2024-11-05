using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGatherer : MonoBehaviour
{
    public int CoinsCollected;
    public Text CoinText;

    private void Update()
    {
        CoinText.text = "Coins: " + CoinsCollected.ToString();
    }
}
