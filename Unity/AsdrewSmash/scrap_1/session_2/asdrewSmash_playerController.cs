using UnityEngine;
using UnityEngine.InputSystem;

public class asdrewSmash_playerController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _barrelPosition;

    [Header ("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [Header ("Shooting")]
    [SerializeField] private float _fireRate;
    [SerializeField] private float _bulletSpeed;


    [Header ("Debug")]
    [SerializeField] private float _counter; 

    [SerializeField] private float _moveInput;
    [SerializeField] private bool _shootInput;

    private void Update(){
        DoMove();
        DoShoot();
    }

    private void DoMove(){
        Vector2 newPosition = transform.position;

        newPosition += new Vector2(_moveInput, 0) * _moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, _minX, _maxX);

        transform.position = newPosition;
    }

    private void DoShoot(){
        _counter -= Time.deltaTime;
        if(_counter > 0) return;

        if(_shootInput){
            _counter = _fireRate;
            
            asdrewSmash_bulletController newBullet = Instantiate(_bulletPrefab, _barrelPosition.transform.position, Quaternion.identity).GetComponent<asdrewSmash_bulletController>();
            newBullet.SetMoveDirection(new Vector2(0, 1));
            newBullet.SetMoveSpeed(_bulletSpeed);
        }
    }

    public void MoveInput(InputAction.CallbackContext ctx){ _moveInput = ctx.ReadValue<float>(); }
    public void ShootInput(InputAction.CallbackContext ctx){ _shootInput = ctx.performed; }
}