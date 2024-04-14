using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMagicCircleManager : MonoBehaviour
{
    private bool summoned = false;
    [Header("Before Summon")]
    public GameObject headObj;
    public ItemScriptableObject headItem;
    public GameObject bodyObj;
    public ItemScriptableObject bodyItem;
    public GameObject arm1Obj;
    public GameObject arm2Obj;
    public ItemScriptableObject armItem;
    public GameObject legObj;
    public ItemScriptableObject legItem;
    public AudioClip putSound;
    public AudioClip summonSound;

    [Header("After Summon")]
    private int cutTimes;
    public GameObject awakenedHeadObj;
    public ItemScriptableObject knifeItem;
    public AudioClip cutSound;
    public GameObject[] blood;

    public void OnMouseDown()
    {
        if(summoned)
        {
            CheckAfterSummon();
        }
        else
        {
            CheckBeforeSummon();
        }
    }

    public void CheckBeforeSummon()
    {
        if(GameManager.instance.ItemManager.EquippedItem() == headItem)
        {
            headObj.SetActive(true);
            GameManager.instance.ItemManager.ConsumeEquippedItem();
            if(putSound != null)
                AudioSource.PlayClipAtPoint(putSound, Camera.main.transform.position);
        }else if(GameManager.instance.ItemManager.EquippedItem() == armItem)
        {
            if(arm1Obj.activeSelf)
            {
                arm2Obj.SetActive(true);
            }
            else
            {
                arm1Obj.SetActive(true);
            }
            GameManager.instance.ItemManager.ConsumeEquippedItem();
            if(putSound != null)
                AudioSource.PlayClipAtPoint(putSound, Camera.main.transform.position);
        }else if (GameManager.instance.ItemManager.EquippedItem() == legItem)
        {
            legObj.SetActive(true);
            GameManager.instance.ItemManager.ConsumeEquippedItem();
            if(putSound != null)
                AudioSource.PlayClipAtPoint(putSound, Camera.main.transform.position);
        }else if(GameManager.instance.ItemManager.EquippedItem() == bodyItem)
        {
            bodyObj.SetActive(true);
            GameManager.instance.ItemManager.ConsumeEquippedItem();
            if(putSound != null)
                AudioSource.PlayClipAtPoint(putSound, Camera.main.transform.position);
        }
        CheckSummon();
    }

    public void CheckSummon()
    {
        if(headObj.activeSelf && arm1Obj.activeSelf && arm2Obj.activeSelf && legObj.activeSelf && bodyObj.activeSelf)
        {
            summoned = true;
            if(summonSound != null)
                AudioSource.PlayClipAtPoint(summonSound, Camera.main.transform.position);
            headObj.SetActive(false);
            awakenedHeadObj.SetActive(true);
        }
    }

    public void CheckAfterSummon()
    {
        if(GameManager.instance.ItemManager.EquippedItem() == knifeItem)
        {
            cutTimes++;
            if(cutSound != null)
                AudioSource.PlayClipAtPoint(cutSound, Camera.main.transform.position);
            if(cutTimes == 1)
            {
                blood[0].SetActive(true);
            }else if(cutTimes == 3)
            {
                blood[1].SetActive(true);
            }else if(cutTimes == 5)
            {
                blood[2].SetActive(true);
                StartCoroutine(EndGameRoutine());
            }
        }
    }

    IEnumerator EndGameRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        awakenedHeadObj.SetActive(false);
        headObj.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        GameManager.instance.EndGame();
    }
}
