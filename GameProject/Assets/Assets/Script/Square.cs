using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Black Square Component
public class Square : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _force = 100f;

    private Vector2 _vector;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        ForceRB();
        Destroy(gameObject, 1.5f);
    }

    private void ForceRB()
    {
        _vector = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        while (_vector == Vector2.zero)
        {
            _vector = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        }

        _rb.AddForce(_vector * _force);
    }

}
