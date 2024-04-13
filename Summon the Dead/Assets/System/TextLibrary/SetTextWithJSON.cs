using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTextWithJSON : MonoBehaviour
{
    [SerializeField] private string filePath;
    [SerializeField] private string textKey;
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.instance.TextLibrary.GetText(filePath, textKey);
    }

    // Update is called once per frame
    public void UpdateValue()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.instance.TextLibrary.GetText(filePath, textKey);
    }
}
