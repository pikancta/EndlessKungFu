using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    public TextMeshProUGUI HealthDisplay;
    public GameObject GameOverDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
        GameOverDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateHealth()
    {
        HealthDisplay.text = $"Health: {Health}";
    }

    public void LoseHealth()
    {
        Health--;
        UpdateHealth();
    }

    public void GameOver()
    {
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
