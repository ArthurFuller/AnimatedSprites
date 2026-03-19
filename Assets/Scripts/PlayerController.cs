using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float vel;
    [SerializeField] float jumpForce;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
   
    void Update()
    {
        Move();
        Jump();
        Orientation();
    }

     public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
        }
    }

    public void Orientation()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sr.flipX = true;
        }
    }
}
