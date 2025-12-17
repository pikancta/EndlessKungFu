using UnityEngine;

public class VelocityCap : MonoBehaviour
{
    public float maxVelocity;
    public Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentVelocity = rb.linearVelocity.magnitude;
        if(currentVelocity > maxVelocity)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
        }
    }
}
