using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private Transform cameraTransform;

    [Header ("Settings - Look")]
    [SerializeField] private Vector2 mouseSensitivity;
    [SerializeField] private float lookSmoothing;
    [SerializeField] private float maxXRotation;
    [SerializeField] private float minXRotation;

    [Header ("Settings - Zoom")]
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float zoomSmoothing;
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;

    [Header ("Debug")]
    [SerializeField] private bool lookInput;
    [SerializeField] private Vector2 mouseDelta;
    [SerializeField] private float scrollDelta;
    [SerializeField] private float yRotation;
    [SerializeField] private float xRotation;
    [SerializeField] private float zoom;

    private void Update(){
        // update look and zoom
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), lookSmoothing * Time.deltaTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, new Vector3(0, 0, -zoom), zoomSmoothing * Time.deltaTime);

        // look
        if(lookInput){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            yRotation += mouseDelta.x * mouseSensitivity.x * Time.deltaTime;
            xRotation -= mouseDelta.y * mouseSensitivity.y * Time.deltaTime;

            xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);
        }else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // zoom
        zoom -= Mathf.RoundToInt(scrollDelta) * (zoomSpeed * Time.deltaTime);
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
    }

    public void LookInput(InputAction.CallbackContext ctx){ lookInput = ctx.performed; }
    public void MouseDeltaInput(InputAction.CallbackContext ctx){ mouseDelta = ctx.ReadValue<Vector2>(); }
    public void ScrollDeltaInput(InputAction.CallbackContext ctx){ scrollDelta = ctx.ReadValue<Vector2>().y; }
}