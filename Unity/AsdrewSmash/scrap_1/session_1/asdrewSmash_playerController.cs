using UnityEngine;
using UnityEngine.InputSystem;

public class asdrewSmash_playerController : MonoBehaviour {
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _barrelPosition;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private float _counter; 

    [SerializeField] private Vector2 _moveInput;
    [SerializeField] private bool _shootInput;

    private void Update(){
        _counter -= Time.deltaTime;
        if(_counter > 0) return;

        if(Input.GetMouseButton(0)){
            _counter = _fireRate;
            
            asdrewSmash_bulletController newBullet = Instantiate(_bulletPrefab, _barrelPosition.transform.position, Quaternion.identity).GetComponent<asdrewSmash_bulletController>();
            newBullet.SetMoveDirection(new Vector2(0, 1));
            newBullet.SetMoveSpeed(_bulletSpeed);
        }
    }

    public void MoveInput(InputAction.CallbackContext ctx){ _moveInput = ctx.ReadValue<Vector2>(); }
    public void ShootInput(InputAction.CallbackContext ctx){ _shootInput = ctx.ReadValue<bool>(); }
}