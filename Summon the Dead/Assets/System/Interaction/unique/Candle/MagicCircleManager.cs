using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleManager : MonoBehaviour
{
    private int candle = 0;

    public void LightCandle()
    {
        candle += 1;
        if(candle >= 3)
        {
            GameManager.instance.ItemManager.ConsumeEquippedItem();
        }
    }
}
