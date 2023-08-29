using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("InGame UI Canvas")]
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _pauseGameUI;
    [SerializeField] private GameObject _gameOverPanelUI;
    [SerializeField] private GameObject _soundActiveBtn;
    [SerializeField] private GameObject _soundDeActiveBtn;
    [SerializeField] private TMP_Text _bestScoreValue;
    [SerializeField] private TMP_Text _scoreValue;

    [Header("Menu Canvas")]
    [SerializeField] private GameObject _menuCanvas;

    [Header("Game Objects")]
    [SerializeField] private GameObject _playerCircleGO;

    private GameManager _gameManagerScr;

    private int bestScore;

    private void Awake()
    {
        _gameManagerScr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SetGamePaused(true);
    }

    private void SetGamePaused(bool isPaused)
    {
        Time.timeScale = isPaused ? 0f : 1f;
        _gameManagerScr.isPausGame = isPaused;
    }

    private void Start()
    {
        SoundButtonUIChange();
    }

    public void StartGame()
    {
        _menuCanvas.SetActive(false);
        _inGameUI.SetActive(true);
        SetGamePaused(false);
    }

    public void PauseGame()
    {
        _inGameUI.SetActive(false);
        _pauseGameUI.SetActive(true);
        SetGamePaused(true);
    }

    public void ResumeGame()
    {
        _inGameUI.SetActive(true);
        _pauseGameUI.SetActive(false);
        SetGamePaused(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _inGameUI.SetActive(false);
        _gameOverPanelUI.SetActive(true);
        _bestScoreValue.text = "Best: " + PlayerPrefs.GetInt(nameof(GameDataManager.Instance.bestScore)).ToString();
        _scoreValue.text = "Score: " + _gameManagerScr.score.ToString();
        SetGamePaused(true);
    }

    public void SoundActiveDeActive()
    {
        _gameManagerScr.isSoundActive = !_gameManagerScr.isSoundActive;
        PlayerPrefs.SetInt(nameof(GameDataManager.Instance._isSoundEffect), _gameManagerScr.isSoundActive ? 1 : 0);
        SoundButtonUIChange();
    }

    private void SoundButtonUIChange()
    {
        _soundActiveBtn.SetActive(_gameManagerScr.isSoundActive);
        _soundDeActiveBtn.SetActive(!_gameManagerScr.isSoundActive);
    }
}
