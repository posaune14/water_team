using UnityEngine;
using UnityEngine.InputSystem;


public class Slash : MonoBehaviour
{
    public GameObject square;
    //public Transform player;
    public Transform target;
    public Color current_color;
    private SpriteRenderer spriterenderer;

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriterenderer);
          if (spriterenderer != null)
        {
            //Debug.Log(spriterenderer.color);
            
            current_color = spriterenderer.color;
            current_color.a = 0;
            spriterenderer.color = current_color;
            target = GameObject.FindWithTag("Player").transform;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            current_color.a = 1;
            spriterenderer.color = current_color;
            Debug.Log(current_color.a);
            transform.position = target.position;
            //square.SetActive(true);
            //Debug.Log("left clicked." + target.position);
            Invoke("Disappear", 0.45f);
            Debug.Log(current_color.a);
            

        }
    }

    void Disappear(){
        current_color.a = 0f;
        spriterenderer.color = current_color;
        //square.SetActive(false);
    }
    
}
