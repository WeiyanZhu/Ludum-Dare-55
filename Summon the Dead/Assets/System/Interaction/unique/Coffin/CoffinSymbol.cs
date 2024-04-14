using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinSymbol : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteList;
    private int currentSpriteIndex;
    [SerializeField] private CoffinPuzzleManager coffinPuzzleManager;
    [SerializeField] private AudioClip clickSound;
    
    public void OnMouseDown()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % spriteList.Length;
        GetComponent<SpriteRenderer>().sprite = spriteList[currentSpriteIndex];
        if(clickSound != null)
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        coffinPuzzleManager.Check();
    }
}
