using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float vel;
    [SerializeField] float jumpForce;
    [SerializeField] Transform floorSensor;

    private bool onFloor;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
   
    void Update()
    {
        Move();
        Jump();
        Orientation();
        OnFloor();
        SetAnim();
    }

     public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && onFloor)
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

    public void OnFloor()
    {
        //Utilizando Linecast e LayerMask para verificar a colisao do Sensor com o Piso
        onFloor = Physics2D.Linecast(transform.position, floorSensor.position, 1 << LayerMask.NameToLayer("Floor"));

        print(onFloor);
    }

    public void SetAnim()
    {
        anim.SetFloat("walk", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }
}
