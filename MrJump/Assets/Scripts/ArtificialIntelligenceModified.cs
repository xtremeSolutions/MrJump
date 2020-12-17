using UnityEngine;
using UnityEngine.Profiling;

public class ArtificialIntelligenceModified : MonoBehaviour
{
    [Header("Platformes Data")]
    [SerializeField] private Renderer[] platforms;
    [SerializeField] private Renderer[] extraJumps;

    [Header("Player Information (Do not Change)"), Space(15)]
    [SerializeField] private Jump playerJumpController;
    [SerializeField] private int currentPlatformIndex = 0;
    [SerializeField] private int extraJumpIndex = 0;
    [SerializeField] private float playerPosition;




    private void Start()
    {
        playerPosition = transform.position.x;
        playerJumpController = playerJumpController.GetComponent<Jump>();

    }

    private void Update()
    {
        Profiler.BeginSample(" your code");
        if (playerPosition <= CurrentPlatform())
        {
            playerJumpController.KeepJumping();

            if (playerPosition - (NextPlatform()) >= 2.5f)
            {
                if (playerPosition <= UpcommingExtraJump())
                {
                    playerJumpController.KeepJumping();
                }
                if ((NextPlatform()) - playerPosition >= -1.4f || (UpcommingExtraJump()) - playerPosition >= -1.4f)
                {
                    playerJumpController.StopJump(); extraJumpIndex++;
                }

            }

            if ((NextPlatform()) - playerPosition >= -0.9f)
            {
                playerJumpController.StopJump();
                currentPlatformIndex++;
            }

        }
        UnityEngine.Profiling.Profiler.EndSample();
    }

    private float CurrentPlatform()
    {
        return (platforms[currentPlatformIndex].bounds.min.x);
    }

    private float NextPlatform()
    {
        return platforms[currentPlatformIndex + 1].bounds.max.x;
    }

    private float UpcommingExtraJump()
    {
        return extraJumps[extraJumpIndex].bounds.max.x;
    }

}
