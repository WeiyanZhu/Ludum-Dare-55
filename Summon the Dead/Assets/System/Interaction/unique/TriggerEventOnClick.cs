using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventOnClick : MonoBehaviour
{
    bool hasTriggered = false;
    [SerializeField] private ItemScriptableObject requiredItem;
    [SerializeField] private bool consumeItemOnUse = false;
    [SerializeField] private AudioClip triggerSound;
    [SerializeField] private UnityEvent onTrigger;

    public void OnMouseDown()
    {
        if (hasTriggered || (requiredItem != null && GameManager.instance.ItemManager.EquippedItem() != requiredItem))
        {
            return;
        }
        if(triggerSound != null)
            AudioSource.PlayClipAtPoint(triggerSound, Camera.main.transform.position);
        onTrigger.Invoke();
        hasTriggered = true;
        if(requiredItem != null && consumeItemOnUse)
        {
            GameManager.instance.ItemManager.ConsumeEquippedItem();
        }
    }
}
