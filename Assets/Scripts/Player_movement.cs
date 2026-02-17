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


         m_Animator.SetBool("right_bool",false);
         m_Animator.SetBool("left_bool",false);
         m_Animator.SetBool("up_bool",false);
         m_Animator.SetBool("down_bool",false);
         m_Animator.SetBool("Rup_bool",false);
         m_Animator.SetBool("rd_bool",false);
         m_Animator.SetBool("Lup_bool",false);
         m_Animator.SetBool("Ld_bool",false);
         
         if (moveX>0 && moveY>0)
         {
            m_Animator.SetBool("Rup_bool",true);
            sprite_renderer.flipX = false;
         }

         else if (moveX>0 && moveY<0)
         {
            m_Animator.SetBool("rd_bool",true);
            sprite_renderer.flipX = false;
         }

         else if (moveX<0 && moveY>0)
         {
            m_Animator.SetBool("Lup_bool",true);
            sprite_renderer.flipX = true;
         }

         else if (moveX<0 && moveY<0)
         {
            m_Animator.SetBool("Ld_bool",true);
            sprite_renderer.flipX = true;
         }
         else if(moveX>0)
         {
            m_Animator.SetBool("right_bool",true);
            sprite_renderer.flipX = false;
         }
         // if (moveX>0)
         // {

         //    m_Animator.SetBool("right_bool",true);
         //    sprite_renderer.flipX = false;
            
            
         // }else{

         //    m_Animator.SetBool("right_bool",false);

         // }

         else if (moveX<0)
         {

            m_Animator.SetBool("left_bool", true);
            sprite_renderer.flipX = true;
            
         }
         // else{
         //    m_Animator.SetBool("left_bool", false);
         // }

         
         
         else if (moveY>0)

         {

            m_Animator.SetBool("up_bool", true);

         }
         // else{
         //    m_Animator.SetBool("up_bool",false);
         // }

         else if (moveY<0)
         {

            m_Animator.SetBool("down_bool",true);

         }
         // else{
         //    m_Animator.SetBool("down_bool",false);
         // }

         moveDirection = new Vector2(moveX, moveY).normalized;   
    }
         
    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * speed, moveDirection.y*speed);

    }

   

    //start is called before the first frame update 

}

    