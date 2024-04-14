using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinPuzzleManager : MonoBehaviour
{
    [SerializeField] private CoffinSymbol[] symbolPair1;
    [SerializeField] private Sprite[] correctSpritePair1;
    [SerializeField] private CoffinSymbol[] symbolPair2;
    [SerializeField] private Sprite[] correctSpritePair2;
    [SerializeField] private CoffinSymbol[] symbolPair3;
    [SerializeField] private Sprite[] correctSpritePair3;
    [SerializeField] private GameObject closedCoffin;
    [SerializeField] private GameObject openCoffin;
    [SerializeField] private AudioClip openSound;
    public void Check()
    {
        if(Check(symbolPair1, correctSpritePair1) && Check(symbolPair2, correctSpritePair2) && Check(symbolPair3, correctSpritePair3))
        {
            closedCoffin.SetActive(false);
            openCoffin.SetActive(true);
            if(openSound != null)
                AudioSource.PlayClipAtPoint(openSound, Camera.main.transform.position);
        }
    }

    private bool Check(CoffinSymbol[] symbols, Sprite[] correctSprites)
    {
        bool answer1 = symbols[0].GetComponent<SpriteRenderer>().sprite == correctSprites[0] && symbols[1].GetComponent<SpriteRenderer>().sprite == correctSprites[1];
        bool answer2 = symbols[1].GetComponent<SpriteRenderer>().sprite == correctSprites[0] && symbols[0].GetComponent<SpriteRenderer>().sprite == correctSprites[1];
        return answer1 || answer2;
    }
}
