using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Dizi Nedir ?
    // Bir Elamanlar Toplulugudur.
    // Nasil Olusturulur
    // Erisim Belirteci - Sinif Turu - [] - degiskenin ismi
    [SerializeField] private Asteroid[] asteroidReferance;
    [SerializeField] private float spawnDuration = 1.2f;
    [SerializeField] private Transform[] spawnReferancePositions;
    [SerializeField] private float minSpeed = 17.5f;
    [SerializeField] private float maxSpeed = 22.5f;

    private float _currentTime = 0.0f;
    private void Start()
    {
        // Instantiate Ornegi
        // Instantiate(asteroidReferance[5], spawnPosition, Quaternion.identity);
        // Loops
        // -> For
        // (degisken tanimla ve degerini gir - dongu ne kadar tekrarlayacak - dongu her tekrarlandiginda ne olacak
    }
    private void Update()
    {
        Timer();
    }

    private void Spawner()
    {
        for (int i = 0; i < asteroidReferance.Length; i++)
        {
            float xRandomPos = Random.Range(spawnReferancePositions[0].position.x, spawnReferancePositions[1].position.x);
            Vector3 spawnPos = new Vector3(xRandomPos, 0, spawnReferancePositions[0].position.z);
            Asteroid asteroid = Instantiate(asteroidReferance[i], spawnPos, Quaternion.identity);
            asteroid.Speed = Random.Range(minSpeed, maxSpeed);
        }
    }

    private void Timer()
    {
        if (_currentTime < spawnDuration)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            Spawner();
            _currentTime = 0;
        }
    }
}
