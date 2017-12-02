﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    Text timerText;
    [SerializeField]
    float timerDuration = 10, upperLimit = 20;
    private float sRemaining;
	// Use this for initialization
	void Start ()
    {
        timerText = GetComponent<Text>();
        StartCoroutine(TimerUpdate());
	}
	
    IEnumerator TimerUpdate()
    {
        sRemaining = timerDuration;
        timerText.text = sRemaining.ToString("n1");

        do
        {
            yield return new WaitForSeconds(0.1f);
            timerText.text = sRemaining.ToString("n1");
            sRemaining -= 0.1f;
        } while (sRemaining > 0);

        Debug.Log("You Died");
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
