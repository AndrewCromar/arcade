using UnityEngine;

public class asdrewSmash_asteroidController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private NextAsteroid[] _nextAsteroids;

    [Header ("Debug")]
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed;

    [System.Serializable]
    private class NextAsteroid {
        public GameObject AsteroidPrefab;
        public Vector2 AsteroidDirection;
    }

    private void Update(){
        transform.position = (Vector2)transform.position + (_moveDirection * _moveSpeed * Time.deltaTime);
    }

    public void Hit(){
        Debug.Log("Got Hit");

        foreach(NextAsteroid nextAsteroid in _nextAsteroids){
            asdrewSmash_asteroidController newAsteroid = Instantiate(nextAsteroid.AsteroidPrefab, transform.position, Quaternion.identity).GetComponent<asdrewSmash_asteroidController>();
            newAsteroid.SetMoveDirection(nextAsteroid.AsteroidDirection);
        }

        Debug.LogWarning("ADD EXPLOSTION SOUND AND GRAPHICS HERE");
        Destroy(gameObject);
    }

    public void SetMoveDirection(Vector2 _moveDirection){ this._moveDirection = _moveDirection; }
    public void SetMoveSpeed(float _moveSpeed){ this._moveSpeed = _moveSpeed; }
}