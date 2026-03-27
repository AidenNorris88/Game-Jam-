using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Running
        if (move != 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        // Attack
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumping", false);
        }

        // Hurt (test key)
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("hurt");
        }

        // Death (test key)
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("die");
        }
    }
}