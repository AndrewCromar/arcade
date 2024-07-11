using UnityEngine;

public class ObjectTrackingUIElement : MonoBehaviour
{
    public GameObject targetObject;
    public Vector2 offset;

    void Update()
    {
        if (targetObject != null)
        {
            // Convert the target object's position from world space to screen space
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.transform.position + (Vector3)offset);

            // Set the UI element's anchored position to the screen position of the target object
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = screenPos - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
    }
}