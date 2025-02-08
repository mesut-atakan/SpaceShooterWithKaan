using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 200.0f;

    private void Update()
    {
        // Vector3(0x, 0y, +1z)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
