using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private float value;
    private float maxValue = 100f;

    public float moveSpeed = 50f;

    private Slider slider;

    public GameObject textObj;
    public TextManager textManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = /* this.gameObject. */GetComponent<Slider>();
        slider.maxValue = maxValue;
        value = maxValue;

        textManager = textObj.GetComponent<TextManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // isEnd == false
        // if(!textManager.isEnd)
        // {
            value -= moveSpeed * Time.deltaTime;

            // スライダーが0になったとき
            if(value < 0)
            {
                textManager.SetTexts();
                ResetSliderValue();    
            };           
        // }
        // else
        // {
        //     ResetSliderValue();
        //     Debug.Log("おわり");
        // }

        slider.value = value;
    }

    // スライダーの量を最大値にリセットする
    public void ResetSliderValue()
    {
        value = maxValue;    
    }
}
