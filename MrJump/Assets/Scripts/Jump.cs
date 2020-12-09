using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    #region CheckGround And Jump
    [Header("IsGrounded Checker &Jumper")]
    [SerializeField]private Rigidbody2D rigidbody2D;
    [SerializeField]private float jumpLaps;
    [SerializeField]private float jumpVelocity = 5;
    [SerializeField]private bool isGrounded;
    #endregion

    private float jumpCounter;
    private bool isJumping;
    private bool extraJump = false;
    private bool nitrogenFly = false;
    private int extraJumpCount = 0;
   
    void Update()
    {
        #region One Extra Jump Scripting
        if ( (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)) && extraJump == true)
        {
            extraJump = true;
            extraJumpCount = 1;
        }
        if ((Input.GetKey(KeyCode.Space)|| (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)) && extraJumpCount == 1  )
        {
            if (jumpCounter > 0)
            {
                rigidbody2D.velocity = Vector2.up * jumpVelocity;
                jumpCounter -= Time.deltaTime;     
            }
            else
            {
                isJumping = false;
                extraJump = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
        {
            isJumping = false;
            extraJump = false;
            extraJumpCount -= 1;
        }
        #endregion

        #region Nitrogen Continous Jumping Script
        if ((Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)) && nitrogenFly)
        { 
            rigidbody2D.velocity = Vector2.up * jumpVelocity; 
        }
        #endregion

        #region Normal Ground Jumping Script
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)))
        {
            isJumping = true;
            jumpCounter = jumpLaps;
        }

        if ((Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)) && isJumping == true)
        {
            if (jumpCounter > 0)
            {
                rigidbody2D.velocity = Vector2.up * jumpVelocity;
                jumpCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
                extraJump = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
        {
            isJumping = false;
            extraJumpCount -= 1;    
        }
        #endregion
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            nitrogenFly = false;
            extraJump = false; 
        }
        else if (collision.gameObject.CompareTag("roof"))
        {
            isJumping = false;
            extraJump = false;
               
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            extraJump = false;
                
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ExtraJump"))
        {
            extraJump = true;
            jumpCounter = jumpLaps;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("NitrogenJump"))
        { 
            nitrogenFly = true;
            Destroy(collision.gameObject);
        }
      

    }

}
