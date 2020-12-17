using UnityEngine;
using UnityEngine.Profiling;

public class ArtificialIntelligenceModified : MonoBehaviour
{
    [Header("Platformes Data")]
    [SerializeField] private Renderer[] platforms;

    [Header("Player Information (Do not Change)"), Space(15)]
    [SerializeField] private Jump playerJumpController;
    [SerializeField] private int currentPlatformIndex = 0;
    [SerializeField] private float playerPosition;

    private void Start()
    {
        playerPosition = transform.position.x;
        playerJumpController = playerJumpController.GetComponent<Jump>();
    }

    private void Update()
    {
        UnityEngine.Profiling.Profiler.BeginSample("your code");
        if (playerPosition <= CurrentPlatform())
        {
            playerJumpController.KeepJumping();

            if ((NextPlatform()) - playerPosition >= -0.9f)
            {
                playerJumpController.StopJump(); currentPlatformIndex++;
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

}
