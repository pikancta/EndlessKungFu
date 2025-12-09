using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rb2D;
    public float MoveSpeed;
    public float HorizontalInput;
    public float JumpForce;

    [Header("Animation")]
    private Animator anim;
    public Sprite Sprite;

    //[Header("Combat")]
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        rb2D.AddForce(Vector2.right * MoveSpeed * HorizontalInput * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space))
        {
          rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
            
    }
}
