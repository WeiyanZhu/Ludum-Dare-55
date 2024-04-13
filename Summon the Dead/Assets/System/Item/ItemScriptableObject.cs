using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item", order = 5)]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private string itemNameKey;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int id;

    public string NameKey{get{return itemNameKey;} private set{itemNameKey = value;}}
    public Sprite Sprite{get{return sprite;} private set{sprite = value;}}
    public int ID{get{return id;} private set{id = value;}}
}
