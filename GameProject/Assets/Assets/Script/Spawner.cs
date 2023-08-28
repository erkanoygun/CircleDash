using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _squareGO;
    [SerializeField] private GameObject _circleGO;
    [SerializeField] private Transform _circleSpawnPosTRS;
    [SerializeField] private Transform _mainCircleTRN;
    void Start()
    {
        StartCoroutine(BoxSpawnSquare());
        StartCoroutine(CircleSpawnSquare());
    }


    IEnumerator BoxSpawnSquare()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.3f);
            GameObject _square = Instantiate(_squareGO, _mainCircleTRN.position, _mainCircleTRN.rotation);
            _square.gameObject.transform.SetParent(gameObject.transform);
            Destroy(_square, 10);
        }
    }

    IEnumerator CircleSpawnSquare()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5f,12f));
            GameObject _circle = Instantiate(_circleGO, _circleSpawnPosTRS.position, _circleSpawnPosTRS.rotation);
            _circle.gameObject.transform.SetParent(gameObject.transform);
            _circle.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 65f);
            Destroy(_circle, 10);
        }
    }
}
