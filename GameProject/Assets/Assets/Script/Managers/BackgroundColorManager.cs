using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorManager : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private Camera _mainCam;
    private int _colorIndex = 0;
    private GameManager _gameManagerScr;
    void Start()
    {
        _mainCam = Camera.main;
        _gameManagerScr = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        ChangeBGColor();
    }
    
    private void ChangeBGColor()
    {
        _mainCam.backgroundColor = Color.Lerp(_mainCam.backgroundColor, _colors[_colorIndex], 1f * Time.deltaTime);
        
    }

    public void ChangeColorIndex()
    {
        if(_colorIndex < _colors.Length)
            _colorIndex++;
    }
}
