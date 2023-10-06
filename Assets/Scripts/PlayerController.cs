using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround = true;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        //same as "Physics.gravity = Physics.gravity * gravityModifier"
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if (spaceDown &&onGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
