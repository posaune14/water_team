    using UnityEngine; 

public class Movement : MonoBehaviour 
{
    Animator m_Animator;
    public GameObject gameobject;

    void Start()
    {

        m_Animator = gameobject.GetComponent<Animator>();

    }



    
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
         Debug.Log(moveX);
         if (moveX>0)
         {

            m_Animator.SetTrigger("right_key");
            
            
         }

         
         Debug.Log(moveY);
         if (moveY>0)

         {

            m_Animator.SetTrigger("up_key");

         }

         if (moveY<0)
         {

            m_Animator.SetTrigger("down_key");



         }

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

    