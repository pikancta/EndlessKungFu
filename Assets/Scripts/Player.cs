using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rb2D;
    public float MoveSpeed;
    public float HorizontalInput;
    public float JumpForce;
    public bool isGrounded;
    public bool GameOn = true;
    private GameManager gm;

    [Header("Animation")]
    private Animator anim;
    public Sprite Sprite;
    public bool facingRight = true;
    

    [Header("Combat")]
    [SerializeField] private GameObject punch;


    
    
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2D = GetComponent<Rigidbody2D>(); 
        GameOn = true;
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void faceDirection()
    {
        if (HorizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (HorizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        // Combat
        if (Input.GetButtonDown("Punch") && GameOn == true)
        {
            StartCoroutine(PunchRoutine());
        }


        // Movement
       if (GameOn == true)
       {
            HorizontalInput = Input.GetAxis("Horizontal");
            rb2D.AddForce(Vector2.right * MoveSpeed * HorizontalInput);
            faceDirection();
       }
        
        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded && GameOn == true)
        {
          rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
          isGrounded = false;
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    IEnumerator PunchRoutine()
    {
        punch.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        punch.SetActive(false);
    }
}
