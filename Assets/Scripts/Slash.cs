using UnityEngine;
using UnityEngine.InputSystem;


public class Slash : MonoBehaviour
{
    public GameObject square;
    void Start()
    {
        square.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            square.SetActive(true);
            //Debug.Log("left clicked.");
            Invoke("Disappear", 0.45f);
            

        }
    }

    void Disappear(){
        square.SetActive(false);
    }
    
}
