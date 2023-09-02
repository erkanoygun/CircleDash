using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public int _isSoundEffect;
    public int score;
    public int bestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        GetGameData();
    }
    
    public void GetGameData()
    {
        // When the game starts for the first time, we make sure that the sound effect setting is on.
        _isSoundEffect = PlayerPrefs.HasKey(nameof(_isSoundEffect)) == false ? 1 : PlayerPrefs.GetInt(nameof(_isSoundEffect));
        
        score = PlayerPrefs.GetInt(nameof(score));
        bestScore = PlayerPrefs.GetInt(nameof(bestScore));
    }
}
