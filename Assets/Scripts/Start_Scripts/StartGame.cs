using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartGame : MonoBehaviour
{
    public void Start() {
        transform.DOShakeRotation(1,20,10,90,true).SetLoops(-1);
    }
    public void StartTheGame(){
        SceneManager.LoadScene("GameScene");
    }
}
