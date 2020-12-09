using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
           
            SceneManager.LoadScene("twoD");
        }
        else if (collision.gameObject.CompareTag("ground")|| collision.gameObject.CompareTag("TOP"))
        {

            SceneManager.LoadScene("twoD");
        }
        else if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("nextlevel"))
        {

            SceneManager.LoadScene("WIN");
        }
    }
}
