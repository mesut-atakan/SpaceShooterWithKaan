using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int TotalScore = 0;
    public int asteroidScore = 5;
    // Convert To Array
    [SerializeField] private ScoreMenu scoreMenu;
    [SerializeField] private Transform exitPos1;
    [SerializeField] private Transform exitPos2;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float bulletSpawnDuration = 0.8f;
    public float shipMoveSpeed = 100;

    private float _currentTime;
    private bool _isFire = true;

    private void Awake()
    {
        scoreMenu.ChangeScore(0);
    }

    private void Update()
    {
        // A -> -1 | D -> +1 | NONE -> 0
        // Get Axis => Float
        // Get Axis Raw => Int
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical).normalized * shipMoveSpeed * Time.deltaTime);
        
        if (Input.GetMouseButton(0) && _isFire)
        {
            Fire();
            _currentTime = 0;
            _isFire = false;
        }
        Timer();
    }
    public void IncreaseScore()
    {
        TotalScore += asteroidScore;
        scoreMenu.ChangeScore(TotalScore);
    }
    private void Fire()
    {
        Bullet b1 =  Instantiate(bullet, exitPos1.position, Quaternion.identity);
        Bullet b2 = Instantiate(bullet, exitPos2.position, Quaternion.identity);
        b1.shipController = this;
        b2.shipController = this;
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