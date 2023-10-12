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
    public ParticleSystem expSystem;
    public ParticleSystem dirtSystem;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource asPlayer;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        //same as "Physics.gravity = Physics.gravity * gravityModifier"
        Physics.gravity *= gravityModifier;

        animPlayer = GetComponent<Animator>();

        asPlayer = GetComponent<AudioSource>();
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
            dirtSystem.Stop();
            asPlayer.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            dirtSystem.Play();
        }
        //Game is over when the condition is met
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            animPlayer.SetBool("Death_b", true);
            animPlayer.SetInteger("DeathType_int", 2);
            expSystem.Play();
            dirtSystem.Stop();
            asPlayer.PlayOneShot(crashSound, 1.0f);
        }
        
    }
}
