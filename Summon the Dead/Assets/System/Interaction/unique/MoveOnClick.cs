using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveOnClick : MonoBehaviour
{
    [SerializeField] private Transform newPos;
    [SerializeField] private AudioClip moveSfx;
    [SerializeField] private UnityEvent afterMove;
    
    private void OnMouseDown()
    {
        if(transform.position == newPos.position)
            return;
        if (moveSfx != null)
            AudioSource.PlayClipAtPoint(moveSfx, Camera.main.transform.position);
        transform.position = newPos.position;
        afterMove.Invoke();
    }
}
