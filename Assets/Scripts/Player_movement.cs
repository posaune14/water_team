    using UnityEngine; 

public class Movement : MonoBehaviour 
{
    Animator m_Animator;
    public GameObject gameobject;
    public SpriteRenderer sprite_renderer; 
  

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
         //Debug.Log(moveX);
         if (moveX>0)
         {

            m_Animator.SetBool("right_bool",true);
            sprite_renderer.flipX = false;
            
            
         }else{

            m_Animator.SetBool("right_bool",false);

         }

         if (moveX<0)
         {

            m_Animator.SetBool("left_bool", true);
            sprite_renderer.flipX = true;
    
            
            
         }else{
            m_Animator.SetBool("left_bool", false);
         }

         
         //Debug.Log(moveY);
         if (moveY>0)

         {

            m_Animator.SetBool("up_bool", true);

         }else{
            m_Animator.SetBool("up_bool",false);
         }

         if (moveY<0)
         {

            m_Animator.SetBool("down_bool",true);

         }else{
            m_Animator.SetBool("down_bool",false);
         }

         moveDirection = new Vector2(moveX, moveY).normalized;   
    }
         
    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * speed, moveDirection.y*speed);

    }

   

    //start is called before the first frame update 

}

    