using UnityEngine;

public class hh_interact : MonoBehaviour {
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;

    void Update(){
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo, distance, layer)){
            hh_interactableObject interactableObject = hitInfo.collider.GetComponent<hh_interactableObject>();
            
            if (interactableObject != null){
                interactableObject.hovering = true;
                if (Input.GetKeyDown(KeyCode.E)){
                    interactableObject.Interact();
                }
            }
        }
    }
}
