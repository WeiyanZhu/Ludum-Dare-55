using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedEntranceToMiniMap : MonoBehaviour
{
    [SerializeField] private GameObject miniMap;
    [SerializeField] private ItemScriptableObject key;
    private bool locked = true;
    [SerializeField] private AudioClip lockedSound;
    [SerializeField] private AudioClip unlockSound;
    [SerializeField] private AudioClip enterMiniMapSound;

    private void OnMouseDown()
    {
        if (GameManager.InMiniMapMode)
        {
            return;
        }
        if (locked)
        {
            if(GameManager.instance.ItemManager.EquippedItem() == key)
            {
                locked = false;
                if (unlockSound != null)
                    AudioSource.PlayClipAtPoint(unlockSound, Camera.main.transform.position);
                GameManager.instance.ItemManager.ConsumeEquippedItem();
            }
            else
            {
                if (lockedSound != null)
                    AudioSource.PlayClipAtPoint(lockedSound, Camera.main.transform.position);
            }
            return;
        }
        if (enterMiniMapSound != null)
            AudioSource.PlayClipAtPoint(enterMiniMapSound, Camera.main.transform.position);
        GameManager.InMiniMapMode = true;
        miniMap.SetActive(true);
    }
}
