using UnityEngine;
using UnityEngine.Profiling;

public class ArtificialIntelligenceModifiedSlop : MonoBehaviour
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
    [SerializeField] float down;
   

    private void Start()
    {
        playerPositionX = transform.position.x;
        playerJumpController = playerJumpController.GetComponent<Jump>();
        
    }

    private void Update()
    {
        down = NextPlatformY();

        if (playerPositionX <= CurrentPlatformX())
        {
            playerJumpController.KeepJumping(down);

            if (playerPositionX - (NextPlatformX()) >= 2.5f)
            {
                if (playerPositionX <= UpcommingExtraJump())
                {
                    playerJumpController.KeepJumping(down);
                }
                if (playerPositionX <= UpcommingflyJump())
                {
                    playerJumpController.KeepJumping(down);
                }
                if ((NextPlatformX()) - playerPositionX >= -0.9f || (UpcommingExtraJump()) - playerPositionX >= -0.9f)
                {
                    playerJumpController.StopJump(); extraJumpIndex++;
                }
                if ((NextPlatformX()) - playerPositionX >= -0.9f || (UpcommingflyJump()) - playerPositionX >= -0.9f)
                {
                    playerJumpController.StopJump();
                    FlyJumpIndex++;
                }
            }

            if ((((NextPlatformX()) - playerPositionX)) >= -0.5f)
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
