using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartTheGame(){
        SceneManager.LoadScene("GameScene");
    }
}