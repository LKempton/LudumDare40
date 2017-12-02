using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    int points = 0;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }

    public void GainPoints(int amount)
    {
        points += amount;
    }

    public int Points
    {
        get
        {
            return points;
        }
    }
    
}
