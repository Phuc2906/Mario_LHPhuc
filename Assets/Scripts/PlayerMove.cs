using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float trucx = 4;
    float trucy = 2;
    float speed = 10;
    float jumpForce = 10f; 
    Rigidbody2D Rigidbody2D;
    bool jumpInput; 
    bool canJump; 

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        if (Rigidbody2D == null)
        {
            Debug.LogError("Rigidbody2D không được tìm thấy trên GameObject này!");
        }
        canJump = true; 
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumpInput = true;
        }
    }

    void FixedUpdate()
    {
        
        if (Mathf.Abs(Rigidbody2D.linearVelocity.y) < 0.01f) 
        {
            canJump = true;
        }
        else
        {
            canJump = false; 
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-trucx, trucy, 1);
            Rigidbody2D.AddForce(new Vector2(-1 * speed, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(trucx, trucy, 1);
            Rigidbody2D.AddForce(new Vector2(1 * speed, 0));
        }

        
        if (jumpInput)
        {
            Rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpInput = false; 
            canJump = false; 
        }
    }
}