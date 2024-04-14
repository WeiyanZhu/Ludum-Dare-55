using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleManager : MonoBehaviour
{
    private int candle = 0;
    [Header("Runes Puzzle")]
    [SerializeField] private GameObject runesParent;
    [SerializeField] private List<MagicCircleRune> runesOrder = new List<MagicCircleRune>();
    private List<MagicCircleRune> activatedRunes = new List<MagicCircleRune>();
    [SerializeField] private GameObject magicCircleActivate;
    [SerializeField] private AudioClip runeActivateSound;
    [SerializeField] private AudioClip runeDeactivateSound;

    public void LightCandle()
    {
        candle += 1;
        if(candle >= 3)
        {
            GameManager.instance.ItemManager.ConsumeEquippedItem();
            StartRunePuzzle();
        }
    }

    public void StartRunePuzzle()
    {
        runesParent.SetActive(true);
        ResetRunesPuzzle();
    }

    public void ResetRunesPuzzle()
    {
        foreach (MagicCircleRune rune in activatedRunes)
        {
            rune.Deactivate();
        }
        activatedRunes.Clear();
        activatedRunes.Add(runesOrder[0]);
        activatedRunes[0].Activate();
    }

    public void ActivateRune(MagicCircleRune rune)
    {
        if(activatedRunes.Contains(rune))
        {
            return;
        }
        if (runesOrder[activatedRunes.Count].index == rune.index)
        {
            activatedRunes.Add(rune);
            if (runeActivateSound != null)
                AudioSource.PlayClipAtPoint(runeActivateSound, Camera.main.transform.position);
            rune.Activate();
            if(activatedRunes.Count == runesOrder.Count)
            {
                magicCircleActivate.SetActive(true);
                GameManager.instance.magicCirclePuzzleSolved = true;
            }
        }
        else
        {
            ResetRunesPuzzle();
            if(runeDeactivateSound != null)
                AudioSource.PlayClipAtPoint(runeDeactivateSound, Camera.main.transform.position);
        }
    }   
}
