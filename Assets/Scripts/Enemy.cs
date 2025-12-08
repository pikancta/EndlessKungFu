using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ScoreValue;
    public int EHealth;
    public int MaxEHealth;
    private GameManager gm;
    private Rigidbody2D rb2d;
    private GameObject Pr;
    public float speed;
    public Player Prs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        Pr = GameObject.Find("Player");
        Prs = GameObject.Find("Player").GetComponent<Player>();
        EHealth = MaxEHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Prs.GameOn == true)
        {
            Vector3 lookDirection = (Pr.transform.position - transform.position).normalized;
            rb2d.AddForce(lookDirection * speed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.PlayerDeath();
        }
        else if (collision.gameObject.CompareTag("Punch"))
        {
            LoseEHealth();
        }
    }

    public void LoseEHealth()
    {
        EHealth--;
    }

    public void Death()
    {
        gm.AddScore(ScoreValue);
        Destroy(gameObject);
    }

    public void EDeath()
    {
        if (EHealth < 1) 
        Death();
    }

}
