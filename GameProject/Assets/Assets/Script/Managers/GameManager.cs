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
    private MenuManager _menuManagerScr;
    public bool isPausGame = false;
    public bool isSoundActive;

    public int score;
    public int bestScore;
    void Start()
    {
        _menuManagerScr = GameObject.FindWithTag("MenuManager").GetComponent<MenuManager>();
        _colorManagerScr = Camera.main.GetComponent<BackgroundColorManager>();

        isSoundActive = GameDataManager.Instance._isSoundEffect == 1 ? true : false;
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
        _menuManagerScr.GameOver();
    }

    public void ScoreIncrease()
    {
        score++;
        if(score > GameDataManager.Instance.bestScore)
            PlayerPrefs.SetInt(nameof(GameDataManager.Instance.bestScore), score);
        _scoreText.text = score.ToString();
        switch (score)
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
