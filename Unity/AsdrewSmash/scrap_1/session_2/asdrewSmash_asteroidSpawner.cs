using UnityEngine;

public class asdrewSmash_asteroidSpawner : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private GameObject _asteroidPrefab;

    [Header ("Settings")]
    [SerializeField] private float _spawnRate;
    [SerializeReference] private float _spawnY;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private Vector2 _asteroidDirection;
    [SerializeField] private float _asteroidSpeed;

    [Header ("Debug")]
    [SerializeField] private float _counter;

    private void Update(){
        _counter -= Time.deltaTime;
        if(_counter > 0) return;
        _counter = _spawnRate;

        Vector2 spawnPosition = new Vector2(Random.Range(_minX, _maxX), _spawnY);
        asdrewSmash_asteroidController newAsteroid = Instantiate(_asteroidPrefab, spawnPosition, Quaternion.identity).GetComponent<asdrewSmash_asteroidController>();
        newAsteroid.SetMoveDirection(_asteroidDirection);
        newAsteroid.SetMoveSpeed(_asteroidSpeed);
    }
}