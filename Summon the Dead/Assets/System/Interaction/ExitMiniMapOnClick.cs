using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMiniMapOnClick : MonoBehaviour
{
    [SerializeField] private GameObject miniMap;
    [SerializeField] private AudioClip exitMiniMapSound;

    private void OnMouseDown()
    {
        if (!GameManager.InMiniMapMode)
        {
            return;
        }
        if(exitMiniMapSound != null)
            AudioSource.PlayClipAtPoint(exitMiniMapSound, Camera.main.transform.position);
        GameManager.InMiniMapMode = false;
        miniMap.SetActive(false);
    }
}
