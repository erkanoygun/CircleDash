using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _squareGO;
    [SerializeField] private GameObject _circleGO;
    [SerializeField] private GameObject _circleSpawnPosGO1, _circleSpawnPosGO2;
    Collider2D _circleSpawnPosCol;
    [SerializeField] private Transform _mainCircleTRN;
    void Start()
    {
        StartCoroutine(BoxSpawnSquare());
        StartCoroutine(CircleSpawnSquareEnumerator());
    }


    IEnumerator BoxSpawnSquare()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.3f);
            GameObject _square = Instantiate(_squareGO, _mainCircleTRN.position, _mainCircleTRN.rotation);
            _square.gameObject.transform.SetParent(gameObject.transform);
            Destroy(_square, 1.5f);
        }
    }

    IEnumerator CircleSpawnSquareEnumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            CircleSpawn();
        }
    }

    private void CircleSpawn()
    {
        
        GameObject _spawnPointGO;
        Vector2 forceDirection;
        if(Random.Range(0,2) == 0)
        {
            _spawnPointGO = _circleSpawnPosGO1;
            forceDirection = Vector2.down;
        }
        else
        {
            _spawnPointGO = _circleSpawnPosGO2;
            forceDirection = Vector2.up;
        }
        Vector2 position = CircleSpawnPos(_spawnPointGO);
        GameObject _circle = Instantiate(_circleGO, position, _spawnPointGO.transform.rotation);
        _circle.gameObject.transform.SetParent(gameObject.transform);
        _circle.GetComponent<Rigidbody2D>().AddForce(forceDirection * 65f);
        Destroy(_circle, 10);
    }

    private Vector2 CircleSpawnPos(GameObject gameObject)
    {
        _circleSpawnPosCol = gameObject.GetComponent<Collider2D>();
        Vector2 position = new Vector2();
        position.x = Random.Range(_circleSpawnPosCol.bounds.min.x, _circleSpawnPosCol.bounds.max.x);
        position.y = gameObject.transform.position.y;

        return position;
    }
}
