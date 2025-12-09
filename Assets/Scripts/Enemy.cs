using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ScoreValue;
    private GameManager gm;
    private Rigidbody2D rb2d;
    private GameObject player;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        rb2d.AddForce(lookDirection * speed *  Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.PlayerDeath();
        }
    }

}
