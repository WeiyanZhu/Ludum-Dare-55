using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemOnClick : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject item;
    [SerializeField] private bool preventOnMiniMapMode = true;

    private void OnMouseDown()
    {
        if (GameManager.InMiniMapMode && preventOnMiniMapMode)
        {
            return;
        }
        GameManager.instance.ItemManager.AddItem(item);
        Destroy(gameObject);
    }
}
