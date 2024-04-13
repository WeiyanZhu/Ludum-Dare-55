using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private AudioClip changeMapSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMap(Map from, Map to)
    {
        if(GameManager.InMiniMapMode)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(changeMapSound, Camera.main.transform.position);
        from.gameObject.SetActive(false);
        to.gameObject.SetActive(true);
    }
}
