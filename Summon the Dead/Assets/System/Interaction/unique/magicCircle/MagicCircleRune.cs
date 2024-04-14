using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleRune : MonoBehaviour
{
    [SerializeField] private GameObject runeActivateSprite;
    [SerializeField] private MagicCircleManager magicCircle;
    public int index;

    public void OnMouseDown()
    {
        magicCircle.ActivateRune(this);
    }

    public void Activate()
    {
        runeActivateSprite.SetActive(true);
    }

    public void Deactivate()
    {
        runeActivateSprite.SetActive(false);
    }
}
