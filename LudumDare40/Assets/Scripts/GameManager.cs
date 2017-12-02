using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    int points = 0;
    [SerializeField]
    float RewardTime = 0.0f;

    private CookSize[] cooks;
        
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cooks = GameObject.FindWithTag("CookHolder").GetComponentsInChildren<CookSize>();
    }

    public void GainPoints(int amount)
    {
        points += amount;

        gameObject.GetComponent<Timer>().AddTime(RewardTime);

        for (int i = 0; i < cooks.Length; i++)
        {
            cooks[i].IncreaseSize();
        }
    }

    public int Points
    {
        get
        {
            return points;
        }
    }
    
}
