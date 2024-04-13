using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private List<ItemScriptableObject> items = new List<ItemScriptableObject>();
    [SerializeField] private List<ItemUI> itemUIs = new List<ItemUI>();
    [SerializeField] private AudioClip getItemSound;
    [SerializeField] private AudioClip equipSound;
    [SerializeField] private AudioClip unequipSound;
    

    private int equippedItemIndex = -1;

    public void Start()
    {
        UpdateUI();
    }

    public void AddItem(ItemScriptableObject item)
    {
        items.Add(item);
        AudioSource.PlayClipAtPoint(getItemSound, Camera.main.transform.position);
        UpdateUI();
    }

    public void HasItem(ItemScriptableObject item)
    {
        items.Contains(item);
    }

    public void EquipItem(int index)
    {
        if (equippedItemIndex == index)
        {
            equippedItemIndex = -1;
            AudioSource.PlayClipAtPoint(unequipSound, Camera.main.transform.position);
        } 
        else if(index >= 0 && index < items.Count)
        {
            equippedItemIndex = index;
            AudioSource.PlayClipAtPoint(equipSound, Camera.main.transform.position);
        }
        UpdateUI();
    }

    public ItemScriptableObject EquippedItem()
    {
        return equippedItemIndex >= 0? items[equippedItemIndex]: null;
    }

    public void ConsumeEquippedItem()
    {         
        if (equippedItemIndex >= 0)
        {
            items.RemoveAt(equippedItemIndex);
            equippedItemIndex = -1;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        for(int i = 0; i < itemUIs.Count; i++)
        {
            itemUIs[i].UpdateUI(i < items.Count? items[i]: null, equippedItemIndex);
        }
    }
}
