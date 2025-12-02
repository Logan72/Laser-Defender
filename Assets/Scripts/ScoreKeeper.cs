using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    static ScoreKeeper instance;
    public int Score 
    {
        get { return score; }
    }

    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    public void AddScore(int amount) => score = Mathf.Clamp(score + amount, 0, int.MaxValue);
    public void ResetScore() => score = 0;
}
