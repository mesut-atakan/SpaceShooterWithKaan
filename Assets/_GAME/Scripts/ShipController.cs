using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Convert To Array
    [SerializeField] private Transform exitPos1;
    [SerializeField] private Transform exitPos2;
    [SerializeField] private GameObject bullet;
    public float shipMoveSpeed = 100;
    private void Update()
    {
        // A -> -1 | D -> +1 | NONE -> 0
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical).normalized * shipMoveSpeed * Time.deltaTime);
        
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(bullet, exitPos1.position, Quaternion.identity);
        Instantiate(bullet, exitPos2.position, Quaternion.identity);
    }
}