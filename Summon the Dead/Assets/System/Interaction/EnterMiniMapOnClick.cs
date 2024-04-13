using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMiniMapOnClick : MonoBehaviour
{
    [SerializeField] private GameObject miniMap;
    [SerializeField] private AudioClip enterMiniMapSound;

    private void OnMouseDown()
    {
        if (GameManager.InMiniMapMode)
        {
            return;
        }
        if(enterMiniMapSound != null)
            AudioSource.PlayClipAtPoint(enterMiniMapSound, Camera.main.transform.position);
        GameManager.InMiniMapMode = true;
        miniMap.SetActive(true);
    }
}
