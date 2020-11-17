using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUIManager : MonoBehaviour
{
    [SerializeField, Header("反応までの時間")] private float maxTime = 5f;
    private float time = 0f;

    [SerializeField] private Text nameTxt;
    [SerializeField] private GameObject meterObj;
    [SerializeField] private Image meter;

    private bool isWatching = false;
    public bool IsWatching{
        set{ isWatching = value; }
        get{ return isWatching; }
    }

    [SerializeField, Header("cube")] private GameObject cube;

    void Start()
    {
        nameTxt.gameObject.SetActive(false);
        meterObj.SetActive(false);
        meter.fillAmount = 0;
    }

    void Update()
    {
        if(isWatching)
        {
            nameTxt.gameObject.SetActive(true);
            meterObj.SetActive(true);

            meter.fillAmount = time / maxTime;    
            time += Time.deltaTime;  
            if(meter.fillAmount == 1)
            {
                Instantiate(cube);
            }  
        }else{
            time = 0f;
            if(nameTxt.gameObject.activeSelf || meterObj.activeSelf)
            {
                nameTxt.gameObject.SetActive(false);
                meterObj.SetActive(false);
            }
        }
    }
}
