﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    //Text timerText;
    [SerializeField]
    Image timerImage;
    [SerializeField]
    float timerDuration = 10, upperLimit = 20;
    [SerializeField]
    private float sRemaining;
	// Use this for initialization
	void Start ()
    {
        //timerText = GetComponent<Text>();
        StartCoroutine(TimerUpdate());
        
	}
	
    IEnumerator TimerUpdate()
    {
        yield return new WaitForSeconds(3f);

        timerImage.enabled = true;

        sRemaining = timerDuration;
        //timerText.text = sRemaining.ToString("n1");
        float timerPercentage = sRemaining / upperLimit;
        timerImage.fillAmount = timerPercentage;

        do
        {
            yield return new WaitForSeconds(0.1f);
            sRemaining -= 0.1f;
            timerPercentage = sRemaining / upperLimit;
            //timerText.text = sRemaining.ToString("n1");
            timerImage.fillAmount = timerPercentage;
        } while (sRemaining > 0);

        
        GameManager.instance.GameOver();
    }

    public void RestartTimer()
    {
        StopCoroutine(TimerUpdate());
        StartCoroutine(TimerUpdate());
    }

    public void AddTime(float amount)
    {


        sRemaining += amount;
        if (sRemaining> upperLimit)
        {
            sRemaining = upperLimit;
        }
    }

    public void RestartTimer(float duration)
    {
        timerDuration = duration;
        StopCoroutine(TimerUpdate());
        StartCoroutine(TimerUpdate());
    }
}
