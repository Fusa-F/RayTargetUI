using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUIManager : MonoBehaviour
{
    [SerializeField, Header("反応までの時間")] private float maxTime = 5f;
    private float time = 0f;
    [SerializeField] private Image meter;

    private bool isWatching = false;
    public bool IsWatching{
        set{ isWatching = value; }
        get{ return isWatching; }
    }

    void Start()
    {
        meter.fillAmount = 0;
    }

    void Update()
    {
        if(isWatching)
        {
            meter.fillAmount = time / maxTime;    
            time += Time.deltaTime;  
            if(meter.fillAmount == 1)
            {
                Debug.Log("イベント!");
            }  
        }else{
            time = 0f;
        }
    }
}
