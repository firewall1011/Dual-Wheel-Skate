using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField] private KeyCode resetKey = KeyCode.R;

    void Update()
    {
        if(Input.GetKeyDown(resetKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }       
    }
}
