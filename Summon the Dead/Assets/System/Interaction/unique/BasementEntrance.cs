using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementEntrance : MonoBehaviour
{
    [SerializeField] private GameObject cannotProgressPromptText;
    [SerializeField] private AudioClip changeMapSound;
    [SerializeField] private AudioClip cannotProgressSound;
    [SerializeField] private Map map;
    [SerializeField] private Map nextMap;
    void OnMouseDown()
    {
        if (GameManager.instance.magicCirclePuzzleSolved)
        {
            map.ChangeMap(nextMap);
            if (changeMapSound != null)
                AudioSource.PlayClipAtPoint(changeMapSound, Camera.main.transform.position);
        }
        else
        {
            cannotProgressPromptText.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(DisablePrompt());
            if (cannotProgressSound != null)
                AudioSource.PlayClipAtPoint(cannotProgressSound, Camera.main.transform.position);
        }
    }

    IEnumerator DisablePrompt()
    {
        yield return new WaitForSeconds(2);
        cannotProgressPromptText.SetActive(false);
    }
}
