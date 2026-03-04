using UnityEngine;
using UnityEngine.InputSystem;


public class Slash : MonoBehaviour
{
    public GameObject square;
    //public Transform player;
    public Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        square.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {

            transform.position = target.position;
            square.SetActive(true);
            Debug.Log("left clicked." + target.position);
            Invoke("Disappear", 0.45f);
            

        }
    }

    void Disappear(){
        square.SetActive(false);
    }
    
}
