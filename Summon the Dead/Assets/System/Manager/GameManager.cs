using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool InMiniMapMode = false;
    private Language language;
    public Language Language { get { return language;} private set { language = value;}}
    [SerializeField] private TextLibrary textLibrary;
    public TextLibrary TextLibrary { get { return textLibrary; } private set { textLibrary = value; } }
    [SerializeField] private ItemManager itemManager;
    public ItemManager ItemManager { get { return itemManager; } private set { itemManager = value; } }

    public bool magicCirclePuzzleSolved = false;
    [SerializeField] private GameObject endGameUI;
    [Header("Shit since no enough time")]
    [SerializeField] private AudioClip buySound;

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

    public void EndGame()
    {
        InMiniMapMode = true;
        endGameUI.SetActive(true);
    }

    public void PlayBuySound()
    {
        if (buySound != null)
            AudioSource.PlayClipAtPoint(buySound, Camera.main.transform.position);
    }
}
