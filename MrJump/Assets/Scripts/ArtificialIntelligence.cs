using UnityEngine;

public class ArtificialIntelligence : MonoBehaviour
{
    public GameObject[] platforms;
    private Renderer currentRenderer;
    private Renderer nextRenderer;
    private float distance;
    public GameObject Script;

    private void Update()
    {
        UnityEngine.Profiling.Profiler.BeginSample("My code");
        for (int i = 0; i < (platforms.Length - 1); i++)
        {
            currentRenderer = platforms[i].GetComponent<Renderer>();
            nextRenderer = platforms[i + 1].GetComponent<Renderer>();

            if (Mathf.RoundToInt(gameObject.transform.position.x) == Mathf.RoundToInt((currentRenderer.bounds.min.x)))
            {
                distance = (nextRenderer.bounds.max.x) - (gameObject.transform.position.x);
               
                Script.transform.GetComponent<Jump>().KeepJumping();

                if (distance >=-0.9f) 
                {
                    Script.transform.GetComponent<Jump>().StopJump();
                   
                }

            }

        }
        UnityEngine.Profiling.Profiler.EndSample();

    }

}
