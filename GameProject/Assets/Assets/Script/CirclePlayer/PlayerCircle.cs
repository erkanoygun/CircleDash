using UnityEngine;

public class PlayerCircle : MonoBehaviour
{
    AudioManager _audioManagerScr;
    private GameManager _gameManagerScr;
    [SerializeField] private GameObject _fragmentationeffect;

    

    private void Start()
    {
        _audioManagerScr = gameObject.transform.parent.GetComponent<AudioManager>();
        _gameManagerScr = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(_fragmentationeffect, transform.position, transform.rotation);
            _gameManagerScr.GameOver();
        }
        if (other.gameObject.CompareTag("ScoreCircle"))
        {
            _audioManagerScr.PlaySoundEffect(1);
            Destroy(other.gameObject);
            _gameManagerScr.ScoreIncrease();
        }
    }
}
