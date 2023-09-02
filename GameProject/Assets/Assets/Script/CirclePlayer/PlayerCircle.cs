using UnityEngine;

public class PlayerCircle : MonoBehaviour
{
    AudioManager _audioManagerScr;
    private GameManager _gameManagerScr;
    [SerializeField] private GameObject _fragmentationeffect, _fragmentationeffect2;
    

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
            _audioManagerScr.PlaySoundEffect(2);
            PlayParticleEffect(_fragmentationeffect, transform.position, transform.rotation);
            _gameManagerScr.GameOver();
        }
        if (other.gameObject.CompareTag("ScoreSquare"))
        {
            _audioManagerScr.PlaySoundEffect(1);
            PlayParticleEffect(_fragmentationeffect2, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            _gameManagerScr.ScoreIncrease();
        }
    }

    private void PlayParticleEffect(GameObject particleeffect, Vector3 pos, Quaternion rot)
    {
        Destroy(Instantiate(particleeffect, pos, rot), 1f);
    }
}
