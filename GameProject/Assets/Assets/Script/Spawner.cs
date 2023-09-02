using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _spawnTime = 1.3f;
    [SerializeField] private GameObject _squareGO;
    [SerializeField] private GameObject _greenSquareGO;
    [SerializeField] private GameObject _greenSquareSpawnPosGO1, _greenSquareSpawnPosGO2;
    private GameManager _gameManagerScr;
    Collider2D _greenSquareSpawnPosCol;
    [SerializeField] private Transform _mainCircleTRN;
    void Start()
    {
        _gameManagerScr = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        StartCoroutine(BlackSquareSpawnSquare());
        StartCoroutine(GreenSquareSpawnEnumerator());
    }

    private void Update()
    {
        if(_gameManagerScr.score >= 20 && _spawnTime == 1.3f)
        {
            _spawnTime = 0.9f;
        }
    }


    IEnumerator BlackSquareSpawnSquare()
    {
        while (true)
        {
            int val = Random.Range(0, 100);
            yield return new WaitForSeconds((val <= 90 ? _spawnTime : 0.3f));
            GameObject _square = Instantiate(_squareGO, _mainCircleTRN.position, _mainCircleTRN.rotation);
            _square.gameObject.transform.SetParent(gameObject.transform);

        }
    }

    IEnumerator GreenSquareSpawnEnumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 4f));
            GreenSquareSpawn();
        }
    }

    private void GreenSquareSpawn()
    {

        GameObject _spawnPointGO;
        Vector2 forceDirection;
        if (Random.Range(0, 2) == 0)
        {
            _spawnPointGO = _greenSquareSpawnPosGO1;
            forceDirection = Vector2.down;
        }
        else
        {
            _spawnPointGO = _greenSquareSpawnPosGO2;
            forceDirection = Vector2.up;
        }
        Vector2 position = GreenSquareSpawnPos(_spawnPointGO);
        GameObject _greenSquare = Instantiate(_greenSquareGO, position, _spawnPointGO.transform.rotation);
        _greenSquare.gameObject.transform.SetParent(gameObject.transform);
        _greenSquare.GetComponent<Rigidbody2D>().AddForce(forceDirection * 65f);
        Destroy(_greenSquare, 6f);
    }

    private Vector2 GreenSquareSpawnPos(GameObject gameObject)
    {
        _greenSquareSpawnPosCol = gameObject.GetComponent<Collider2D>();
        Vector2 position = new Vector2();
        position.x = Random.Range(_greenSquareSpawnPosCol.bounds.min.x, _greenSquareSpawnPosCol.bounds.max.x);
        position.y = gameObject.transform.position.y;

        return position;
    }
}
