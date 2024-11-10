using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    public void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
