using UnityEngine;
using UnityEngine.Profiling;

public class ArtificialIntelligenceModified : MonoBehaviour
{
    [Header("Platformes Data")]
    [SerializeField] private Renderer[] platforms;
    [SerializeField] private Renderer[] extraJumps;
    [SerializeField] private Renderer[] FlyJumps;

    [Header("Player Information (Do not Change)"), Space(15)]
    [SerializeField] private Jump playerJumpController;
    [SerializeField] private int currentPlatformIndex = 0;
    [SerializeField] private int extraJumpIndex = 0;
    [SerializeField] private int FlyJumpIndex = 0;
    [SerializeField] private float playerPositionX;
    [SerializeField] private float playerPositionY;

    private float sloppyDistance;
    private float inverseSloppyDistance;
    public float down;


    private void Start()
    {
        playerPositionX = transform.position.x;
        playerJumpController = playerJumpController.GetComponent<Jump>();
        Debug.Log(((platforms[3].bounds.max.y)-(platforms[2].bounds.max.y))/ ((platforms[3].bounds.max.x) - (platforms[2].bounds.min.x)));
        Debug.Log(((platforms[2].bounds.max.y)-(platforms[1].bounds.max.y))/ ((platforms[2].bounds.max.x) - (platforms[1].bounds.min.x)));
       
    }
    // original and working update function
    // private void Update()
    // {
    //    
    //    
    //     if (playerPositionX <= CurrentPlatformX())
    //     {
    //         playerJumpController.KeepJumping();
    //
    //         if (playerPositionX - (NextPlatformX()) >= 2.5f )
    //         {
    //             if (playerPositionX <= UpcommingExtraJump())
    //             {
    //                 playerJumpController.KeepJumping();
    //             }
    //           if (playerPositionX <= UpcommingflyJump())
    //           {
    //              playerJumpController.KeepJumping();
    //                 
    //
    //           }
    //
    //             if ((NextPlatformX()) - playerPositionX >= -0.9f || (UpcommingExtraJump()) - playerPositionX >= -0.9f )
    //             {
    //                 playerJumpController.StopJump(); extraJumpIndex++;
    //             }
    //             if ((NextPlatformX()) - playerPositionX >= -0.5f || (UpcommingflyJump()) - playerPositionX >= -0.5f)
    //             {
    //                 playerJumpController.StopJump();
    //                 FlyJumpIndex++;
    //             }
    //
    //         }
    //
    //        if ((((NextPlatformX()) - playerPositionX)) >= -0.9f)
    //        {
    //            playerJumpController.StopJump();
    //            currentPlatformIndex++;
    //        }
    //
    //     }
    //   
    // }


   
    private void Update()
    {
        sloppyDistance = (((platforms[currentPlatformIndex + 1].bounds.max.y) - (transform.position.y)) / ((platforms[1].bounds.max.x) - (transform.position.x)));
        inverseSloppyDistance = (((transform.position.y)-(platforms[currentPlatformIndex + 1].bounds.max.y)  ) / ((transform.position.x)-(platforms[1].bounds.max.x) ));
        
        

        if (playerPositionX <= CurrentPlatformX())
        {
            playerJumpController.KeepJumping(down);
   
            if (playerPositionX - (NextPlatformX()) >= 2.5f )
            {
                if (playerPositionX <= UpcommingExtraJump())
                {
                    playerJumpController.KeepJumping(down);
                }
              if (playerPositionX <= UpcommingflyJump())
              {
                 playerJumpController.KeepJumping(down);
                    
   
              }
   
                if ((NextPlatformX()) - playerPositionX >= -0.9f || (UpcommingExtraJump()) - playerPositionX >= -0.9f )
                {
                    playerJumpController.StopJump(); extraJumpIndex++;
                }
                if ((NextPlatformX()) - playerPositionX >= -0.9f || (UpcommingflyJump()) - playerPositionX >= -0.9f)
                {
                    playerJumpController.StopJump();
                    FlyJumpIndex++;
                }
   
            }
   
           if ((((NextPlatformX()) - playerPositionX)) >= -0.9f)
           {
               playerJumpController.StopJump();
               currentPlatformIndex++;
           }
   
        }
      
    }



    private float CurrentPlatformX()
    {
        return (platforms[currentPlatformIndex].bounds.min.x);
    }
    private float CurrentPlatformY()
    {
        return (platforms[currentPlatformIndex].bounds.min.y);
    }

    private float NextPlatformX()
    {
        return platforms[currentPlatformIndex + 1].bounds.max.x;
    }
    private float NextPlatformY()
    {
        return platforms[currentPlatformIndex + 1].bounds.max.y;
    }

    private float UpcommingExtraJump()
    {
        return extraJumps[extraJumpIndex].bounds.max.x;
    }

    private float UpcommingflyJump()
    {
        return FlyJumps[FlyJumpIndex].bounds.max.x;
    }

}
