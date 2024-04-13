using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item", order = 5)]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private string itemNameKey;
    [SerializeField] private Sprite sprite;

    public string NameKey{get{return itemNameKey;} private set{itemNameKey = value;}}
    public Sprite Sprite{get{return sprite;} private set{sprite = value;}}
}
