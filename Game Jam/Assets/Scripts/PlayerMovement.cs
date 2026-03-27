using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputSystem_Actions actions;// This is a reference to the input actions defined in the Input System. It will be used to read player input for movement and jumping.
    private Rigidbody2D body;// This is a reference to the Rigidbody2D component attached to the player GameObject. It will be used to apply physics-based movement and jumping.
    public float speed;// This variable will determine how fast the player moves horizontally. It can be adjusted in the Unity Inspector to fine-tune the movement speed.
    float move;// This variable will store the horizontal input value from the player. It will be used to calculate the movement direction and speed.
    public float jumpForce;// This variable will determine the force applied to the player when they jump. It can be adjusted in the Unity Inspector to fine-tune the jump height.
    bool isFacingRight = false;// This variable will keep track of the direction the player is facing. It can be used to flip the player's sprite when changing direction.

    private void Awake()// This method is called when the script instance is being loaded
    {
        actions = new InputSystem_Actions();// This line initializes the input actions by creating a new instance of the InputSystem_Actions class, which is generated based on the input actions defined in the Unity Editor.
    }

    private void OnEnable()// This method is called when the object becomes enabled and active
    {
        actions.Player.Enable();
        actions.Player.Move.performed += Movement;
        actions.Player.Jump.performed += Jumping;

       
        actions.Player.Move.canceled += Movement;
        actions.Player.Jump.canceled += Jumping;
    }

    private void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= Movement;
        actions.Player.Jump.performed -= Jumping;
    }


    void Movement(InputAction.CallbackContext ctx)// This method is called when the Move action is performed or canceled. It reads the horizontal input value from the input context and stores it in the move variable.
    {
        move = ctx.ReadValue<Vector2>().x;// The ReadValue<Vector2>() method reads the input value as a Vector2, which represents the horizontal and vertical input. We only care about the horizontal input, so we access the x component of the Vector2.
    }

    void Jumping(InputAction.CallbackContext ctx)
    {
        body.linearVelocityY = jumpForce;// This line sets the vertical velocity of the player's Rigidbody2D to the value of jumpForce, which will make the player jump. The linearVelocity property is used to directly set the velocity of the Rigidbody2D, allowing for immediate changes in movement.
    }

    void Start()
    {
        body  = GetComponent<Rigidbody2D>();// This line gets the Rigidbody2D component attached to the player GameObject and assigns it to the body variable. This allows us to manipulate the player's physics-based movement and jumping in other parts of the script.
    }

    private void Update()
    {
        body.linearVelocityX = move * speed;// This line sets the horizontal velocity of the player's Rigidbody2D based on the move variable (which contains the horizontal input) multiplied by the speed variable. This allows the player to move left or right based on their input.
        FlipSprite();// This line calls the FlipSprite method, which checks the direction the player is moving and flips the sprite accordingly to ensure it faces the correct direction.
    }

    void FlipSprite()
    {
        if(isFacingRight && move <0 || !isFacingRight && move > 0)
        {
            isFacingRight = !isFacingRight;// This line toggles the isFacingRight variable to indicate that the player has changed direction.
            Vector3 localScale = transform.localScale;// This line gets the current local scale of the player's transform, which is used to flip the sprite.
            localScale.x *= -1;// This line multiplies the x component of the local scale by -1, effectively flipping the sprite horizontally.
            transform.localScale = localScale;// This line applies the modified local scale back to the player's transform, completing the sprite flip. 
        }
    }
}
