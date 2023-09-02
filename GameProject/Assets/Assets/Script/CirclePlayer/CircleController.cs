using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircleController : MonoBehaviour
{
    public float rotationSpeed = 45f;
    private bool _isRight = false;

    AudioManager _audioManagerScr;
    private GameManager _gameManagerScr;

    private TrailRenderer _trailRnd;

    private void Start()
    {
        _audioManagerScr = GetComponent<AudioManager>();
        _gameManagerScr = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                StartCoroutine(DashEffectEnumerator());
                if(!_gameManagerScr.isPausGame)
                    _audioManagerScr.PlaySoundEffect(0);
                _isRight = !_isRight;
            }
        }

        transform.rotation *= Quaternion.Euler(0f, 0f, (!_isRight ? rotationSpeed : -rotationSpeed) * Time.deltaTime);
    }

    IEnumerator DashEffectEnumerator()
    {
        yield return new WaitForSeconds(0.1f);
    }
    
}
