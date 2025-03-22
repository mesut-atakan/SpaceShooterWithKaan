using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ShipController shipController;
    [SerializeField] private float speed = 200.0f;
    [SerializeField] private float destroyDelay = 5.0f;
    private void OnEnable()
    {
        Destroy(gameObject, destroyDelay);
    }
    private void Update()
    {
        // Vector3(0x, 0y, +1z)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            shipController.IncreaseScore();
            Asteroid asteroid = other.GetComponent<Asteroid>();
            asteroid.TakeDamage();
            Destroy(gameObject);
        }
    }
}
