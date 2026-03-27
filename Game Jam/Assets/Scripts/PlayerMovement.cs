using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputSystem_Actions actions;
    public Rigidbody2D playerRb;
    public float speed;//speed of the player movement
    public float input;// the input value for horizontal movement
    public float jumpForce;// the force applied to the player when jumping
    public float move;// the value of the horizontal movement input


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        actions = new InputSystem_Actions(); // Initialize the input actions    
    }
    void OnEnable()
    {
        actions.Player.Enable(); // Enable the input actions when the script is enabled

        actions.Player.Move.performed += Movement;
        actions.Player.Jump.performed += Jumping;

        actions.Player.Move.canceled += Movement;
        actions.Player.Jump.canceled += Jumping;
    }

    private void OnDisable()
    {
        actions.Player.Disable(); // Disable the input actions when the script is Disabled

        actions.Player.Move.performed -= Movement;
        actions.Player.Jump.performed -= Jumping;
    }

    void Movement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>().x;// Read the horizontal movement input from the callback context
    }

    void Jumping(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

            playerRb.linearVelocityY = jumpForce;// Set the player's vertical velocity to the jump force when the jump action is performed

        }

    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player GameObject
    }

    // Update is called once per frame
    void Update()
    {

        playerRb.linearVelocityX = move * speed;// Set the player's horizontal velocity based on the movement input and speed

    }

}
