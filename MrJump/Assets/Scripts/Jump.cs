using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jump : MonoBehaviour
{
    #region CheckGround And Jump
    [Header("IsGrounded Checker &Jumper")]
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float jumpLaps;
    [SerializeField] private float jumpVelocity = 5;
    [SerializeField] private bool isGrounded;
    [SerializeField] GameObject Spike;
    #endregion

    private float jumpCounter;
    private bool isJumping;
    private bool extraJump = false;
    private bool nitrogenFly = false;
    private int extraJumpCount = 0;
    public Text allow;
   

    #region Self Inteligence
    private float spikePassThroughSpeed;
    #endregion

   

    void Update()
    {
        #region One Extra Jump Scripting
        if ((extraJump == true && Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)))
        {

            extraJump = true;
            extraJumpCount = 1;
        }
        if (extraJumpCount == 1 && (Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)))
        {
            if (jumpCounter > 0)
            {
                rigidbody2D.velocity = Vector2.up * jumpVelocity;
                jumpCounter -= Time.deltaTime;
            }
            else
            {
                extraJump = false;
            }
        }
        #endregion


        #region Nitrogen Continous Jumping Script
        if ((Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)) && nitrogenFly)
        {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            allow.text = "jump";
        }
        #endregion



        #region Normal Ground Jumping Script
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)))
        {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
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
                allow.text = " ";
                isJumping = false;
                extraJump = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
        {
            StopJump();
        }
        #endregion

    }

    public void KeepJumping()
    {
        if (isGrounded||extraJump)
        {
            jumpCounter = jumpLaps;
            isJumping = true;
        }
       
        if (jumpCounter > 0 && isJumping == true)
        {

            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            jumpCounter -= Time.deltaTime;
        }
        else
        {
            
            allow.text = " ";
            isJumping = false;
            extraJump = false;
        }
    }

    public void StopJump() {
        {
            jumpCounter = 0;
            isGrounded = false;
            isJumping = false;
            extraJumpCount -= 1;
            extraJump = false;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            nitrogenFly = false;
            extraJump = false;
            allow.text = "jump";
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
            allow.text = " ";
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
            // Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("NitrogenJump"))
        {
            nitrogenFly = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("SpikeProtector"))
        {
            rigidbody2D.velocity = Vector2.left * jumpVelocity * 2;
            Spike.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(collision.gameObject);

        }

    }


    
}
