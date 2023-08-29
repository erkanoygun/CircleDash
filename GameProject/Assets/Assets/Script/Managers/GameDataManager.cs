using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public int _isSoundEffect = 1;
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
        _isSoundEffect = PlayerPrefs.GetInt(nameof(_isSoundEffect));
        score = PlayerPrefs.GetInt(nameof(score));
        bestScore = PlayerPrefs.GetInt(nameof(bestScore));
    }
}
