using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround = true;
    public bool gameOver = false;

    private Animator animPlayer;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        //same as "Physics.gravity = Physics.gravity * gravityModifier"
        Physics.gravity *= gravityModifier;

        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        //conditions met to jump
        if (spaceDown &&onGround && !gameOver)
        {
            //jump code
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
            animPlayer.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        //Game is over when the condition is met
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 2);
        }
        
    }
}
