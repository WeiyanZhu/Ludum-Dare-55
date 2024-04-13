using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Language language;
    public Language Language { get { return language;} private set { language = value;}}
    [SerializeField] private TextLibrary textLibrary;
    public TextLibrary TextLibrary { get { return textLibrary; } private set { textLibrary = value; } }
    [SerializeField] private ItemManager itemManager;
    public ItemManager ItemManager { get { return itemManager; } private set { itemManager = value; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Initialize()
    {
        language = Language.English;
    }
}
