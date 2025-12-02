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
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
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
}
