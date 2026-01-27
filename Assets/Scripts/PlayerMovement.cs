using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public InputAction moveInput;
    
    private void OnEnable(){
        moveInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
    }

    /*public void OnMove(InputValue input)
    {
        print("on move input reading works");
        moveInput = ReadValue<Vector2>();
        print(moveInput);
    }*/

    private void Update()
    {
        Vector2 move = moveInput.ReadValue<Vector2>();
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
