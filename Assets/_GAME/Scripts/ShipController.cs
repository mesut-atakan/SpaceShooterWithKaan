using UnityEngine;

public class ShipController : MonoBehaviour
{
    // Convert To Array
    [SerializeField] private Transform exitPos1;
    [SerializeField] private Transform exitPos2;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpawnDuration = 0.8f;
    public float shipMoveSpeed = 100;

    private float _currentTime;
    private bool _isFire = true;

    private void Update()
    {
        // A -> -1 | D -> +1 | NONE -> 0
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical).normalized * shipMoveSpeed * Time.deltaTime);
        
        if (Input.GetMouseButton(0) && _isFire)
        {
            Fire();
            _currentTime = 0;
            _isFire = false;
        }
        Timer();
    }
    private void Fire()
    {
        Instantiate(bullet, exitPos1.position, Quaternion.identity);
        Instantiate(bullet, exitPos2.position, Quaternion.identity);
    }
    private void Timer()
    {
        if (_currentTime < bulletSpawnDuration)
        {
            _currentTime += Time.deltaTime;
        }
        else // Current Time Buyukse Bullet Spawn Duration'dan
        {
            _isFire = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"CARPISMA: {other.gameObject.name}");
    }
}