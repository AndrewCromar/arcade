using UnityEngine;

public class CameraContainer : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float camera_smoothing;

    private void Update(){
        transform.position = Vector3.Lerp(transform.position, target.position + offset, camera_smoothing * Time.deltaTime);
        transform.LookAt(target);
    }
}