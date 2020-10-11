using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject _restartButtonObject;
    public GameLogic _gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        _restartButtonObject.SetActive(false);
        _gameLogic.ResumeGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Test01");
        
    }
}
