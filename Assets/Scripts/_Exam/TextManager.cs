using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextManager : MonoBehaviour
{
    public List<string> texts = new List<string>();
    Text text;

    private int index = 0;

    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = texts[index];
    }

    public void SetTexts()
    {
        try
        {
            index++;
            text.text = texts[index];
        }catch(ArgumentOutOfRangeException e)
        {
            text.text = "おわり";
            isEnd = true;
            //　時を止める
            Time.timeScale = 0f;
        }
    }
}
