using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreTMP;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        scoreTMP.text = scoreKeeper.Score.ToString("000000000");
    }
    //void Update()
    //{
    //    healthSlider.value = playerHealth.HealthAmount;
    //    scoreTMP.text = scoreKeeper.Score.ToString("000000000");
    //}
    public void AddScore(int score)
    {
        scoreKeeper.AddScore(score);
        scoreTMP.text = scoreKeeper.Score.ToString("000000000");
    }
    public void UpdateHealth(int health)
    {
        healthSlider.value = health;
    }
}
