using UnityEngine;

public class asdrewSmash_bulletController : MonoBehaviour {
    [Header ("Settings")]
    [SerializeField] private string _asteroidTag;

    [Header ("Debug")]
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _used;

    private void Update(){
        transform.position = (Vector2)transform.position + (_moveDirection * _moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(_used) return;
        
        if(col.gameObject.CompareTag(_asteroidTag)){
            col.gameObject.GetComponent<asdrewSmash_asteroidController>().Hit();

            _used = true;
            Destroy(gameObject);
        }
    }

    public void SetMoveDirection(Vector2 _moveDirection){ this._moveDirection = _moveDirection; }
    public void SetMoveSpeed(float _moveSpeed){ this._moveSpeed = _moveSpeed; }
}