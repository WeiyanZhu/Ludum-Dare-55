using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private TMPro.TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemSprite;
    [SerializeField] private GameObject equipIndicator;

    public void OnClick()
    {
        itemManager.EquipItem(index);
    }

    public void UpdateUI(ItemScriptableObject itemData, int equippedItemId)
    {
        if (itemData == null)
        {
            itemNameText.gameObject.SetActive(false);
            itemSprite.gameObject.SetActive(false);
            equipIndicator.SetActive(false);
            return;
        }
        else
        {
            itemNameText.gameObject.SetActive(true);
            itemNameText.text = GameManager.instance.TextLibrary.GetText("items", itemData.NameKey);
            itemSprite.gameObject.SetActive(true);
            itemSprite.sprite = itemData.Sprite;
            equipIndicator.SetActive(index == equippedItemId);
        }
    }
}
