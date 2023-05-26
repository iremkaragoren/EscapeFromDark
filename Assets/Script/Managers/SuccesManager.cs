
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccesManager : MonoBehaviour
{
    public Transform dark;
    public Transform character;

    void Update()
    {
        if (dark.position.x >= character.position.x)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
