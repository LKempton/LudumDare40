using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    int points = 0;
    [SerializeField]
    float RewardTime = 0.0f;
    float sizeMultiplier = 1;
    private List<CookSize> cooks;
        
    private void Awake()
    {
        instance = this;
        cooks = new List<CookSize>();
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
