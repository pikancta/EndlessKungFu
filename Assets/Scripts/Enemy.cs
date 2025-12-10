using System;
using System.Collections;
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
    [Header("Combat")]
    [SerializeField] private GameObject punch;
    [SerializeField] private float punchDelay;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        Pr = GameObject.Find("Player");
        Prs = GameObject.Find("Player").GetComponent<Player>();
        EHealth = MaxEHealth;
    }
    void Update()
    {
        if (Prs.GameOn == true)
        {
            Vector3 lookDirection = (Pr.transform.position - transform.position).normalized;
            rb2d.AddForce(lookDirection * speed);
            if(lookDirection.x < 0 && transform.localScale.x > 0)
            {
                Vector3 Scale = transform.localScale;
                Scale.x *= -1;
                transform.localScale = Scale;
            }
            else if (lookDirection.x > 0 && transform.localScale.x < 0)
            {
                Vector3 Scale = transform.localScale;
                Scale.x *= -1;
                transform.localScale = Scale;
            }
        }
        if (EHealth < 1)
        {
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PunchRoutine());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Punch"))
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
    IEnumerator PunchRoutine()
    {
        punch.SetActive(true);
        yield return new WaitForSeconds(.5f);
        punch.SetActive(false);
        yield return new WaitForSeconds(punchDelay);
    }
}
