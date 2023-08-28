using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanelGO;
    public bool isPausGame = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isPausGame = true;
        StartCoroutine(GameOverEnumerator());
        
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    IEnumerator GameOverEnumerator()
    {
        yield return new WaitForSeconds(1.2f);
        _gameOverPanelGO.SetActive(true);
        Time.timeScale = 0;
    }
}
