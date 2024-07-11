using UnityEngine;

public class WeaponRotationCore : MonoBehaviour {
    [SerializeField] private float lerp_speed;
    private Vector3 target_angle = new Vector3(0, 0, 0);

    private void Update(){
        Quaternion currentRotation = transform.localRotation;
        Quaternion targetRotation = Quaternion.Euler(target_angle);
        Quaternion newRotation = Quaternion.Lerp(currentRotation, targetRotation, lerp_speed * Time.deltaTime);
        transform.localRotation = newRotation;
    }
}