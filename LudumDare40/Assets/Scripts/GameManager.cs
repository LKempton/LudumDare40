﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    int points = 0;
    [SerializeField]
    float RewardTime = 0.0f;
    float sizeMultiplier = 1;
    private List<CookSize> cooks;

    [SerializeField]
    private GameObject gameoverText;
    private bool isGameover = false;
        
    private void Awake()
    {
        instance = this;
        cooks = new List<CookSize>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameover)
        {
            gameoverText.SetActive(false);
            isGameover = false;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGameover)
        {
            gameoverText.SetActive(false);
            isGameover = false;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        }
    }


    public void GainPoints(int amount)
    {
        points += amount;

        gameObject.GetComponent<Timer>().AddTime(RewardTime);

        
        for (int i = 0; i < cooks.Count; i++)
        {
            cooks[i].IncreaseSize();
        }
        sizeMultiplier++;
    }

    public void GameOver()
    {
        Debug.Log("You Died");
        gameoverText.SetActive(true);
        isGameover = true;
        Time.timeScale = 0.0f;
    }

    public void AddCook(CookSize cook)
    {
        cooks.Add(cook);
    }

    public int Points
    {
        get
        {
            return points;
        }
    }
    
}
