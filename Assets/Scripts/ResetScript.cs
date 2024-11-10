using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour
{
    public void GameReset()
    {
        PlayerClone.clones = new();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
