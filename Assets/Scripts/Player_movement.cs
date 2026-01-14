    using UnityEngine; 

public class Movement : MonoBehaviour 
{



    
    public float speed = 1.7f;

    public Rigidbody2D rb;

    private Vector2 moveDirection; 

    void Update() //what does this mean? 
    {
        ProcessedInputs();

    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessedInputs()
    {
         float moveX = Input.GetAxisRaw("Horizontal");
         float moveY = Input.GetAxisRaw("Vertical");
         moveDirection = new Vector2(moveX, moveY).normalized;

    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * speed, moveDirection.y*speed);

    }

    Animator anim;
    private Vector2 lastMoveDirection;
    private bool facingLeft = true; //sprite facing left 

    //start is called before the first frame update 

    




}   