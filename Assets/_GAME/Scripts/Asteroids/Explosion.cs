using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Rigidbody[] rbs;
    public float explosionPower = 4f;
    private void OnEnable()
    {
        ExplosionPhysiscs();
    }
    private void ExplosionPhysiscs()
    {
        Debug.Log("Explosion Physics");
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].AddForce(new Vector3(Random.Range(-explosionPower, explosionPower), Random.Range(-explosionPower, explosionPower), Random.Range(-explosionPower, explosionPower)));
            Destroy(rbs[i].gameObject, 5);
        }
    }
}
