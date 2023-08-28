using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text _scoreText;
    private BackgroundColorManager _colorManagerScr;
    
    [SerializeField] private GameObject _gameOverPanelGO;
    public bool isPausGame = false;

    public int _score;
    void Start()
    {
        _colorManagerScr = Camera.main.GetComponent<BackgroundColorManager>();
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

    public void ScoreIncrease()
    {
        _score++;
        _scoreText.text = _score.ToString();
        switch (_score)
        {
            case 8:
               _colorManagerScr.ChangeColorIndex();
               break;
            case 17:
               _colorManagerScr.ChangeColorIndex();
               break;
            case 25:
               _colorManagerScr.ChangeColorIndex();
               break;
            case 35:
               _colorManagerScr.ChangeColorIndex();
               break;
        }
    }
}
