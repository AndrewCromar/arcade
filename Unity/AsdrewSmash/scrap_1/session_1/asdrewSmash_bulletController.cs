using UnityEngine;

public class asdrewSmash_bulletController : MonoBehaviour {
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private float _moveSpeed;

    private void Update(){
        transform.position = (Vector2)transform.position + (_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("asteroid")){
            col.gameObject.GetComponent<asdrewSmash_asteroidController>().Hit();
        }
    }

    public void SetMoveDirection(Vector2 _moveDirection){ this._moveDirection = _moveDirection; }
    public void SetMoveSpeed(float _moveSpeed){ this._moveSpeed = _moveSpeed; }
}