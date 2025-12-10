using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Health;
    public int MaxHealth;
    public int score;

    public TextMeshProUGUI HealthDisplay;
    public TextMeshProUGUI ScoreDisplay;
    public GameObject GameOverDisplay;
    public Player Pr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pr = GameObject.Find("Player").GetComponent<Player>();
        Health = MaxHealth;
        GameOverDisplay.SetActive(false);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateHealth()
    {
        HealthDisplay.text = $"Health: {Health}";
    }


    public void UpdateScore()
    {
        ScoreDisplay.text = $"Score: {score}";
    }

    public void LoseHealth()
    {
        Health--;
        UpdateHealth();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void GameOver()
    {
        Pr.GameOn = false;
        GameOverDisplay.SetActive(true);
    }

    public void PlayerDeath()
    {
        LoseHealth();
        if (Health < 1)
        {
            GameOver();
        }
    }
}
