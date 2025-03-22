using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Speed = 20;
    private Fracture _fracture;

    private void Awake()
    {
        _fracture = GetComponent<Fracture>();
    }
    private void Update()
    {
        transform.Translate(-Vector3.forward * Speed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        _fracture.Explosion();
    }
}
