using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeMapOnClick : MonoBehaviour
{
    [SerializeField] private AudioClip triggerSound;
    [SerializeField] private Map mapFrom;
    [SerializeField] private Map mapTo;

    public void OnMouseDown()
    {
        mapFrom.ChangeMap(mapTo);
        if(triggerSound != null)
            AudioSource.PlayClipAtPoint(triggerSound, Camera.main.transform.position);
    }
}
