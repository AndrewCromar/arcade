using UnityEngine;

public class UIFollowWorldObject : MonoBehaviour {
    [Header("References")]
    [SerializeField] private Transform Target;

    [Header("Settings")]
    [SerializeField] private bool StaticPosition;
    [SerializeField] private bool UseSmoothing;
    [SerializeField] private float SmoothSpeed;

    private Canvas canvas;

    private void Awake(){
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        transform.SetParent(canvas.gameObject.transform);
    }

    private void Update(){
        if(StaticPosition) return;

        if (Target == null || canvas == null) return;

        Vector2 localPoint = GetPosition();

        if (UseSmoothing){
            Vector2 currentPosition = (transform as RectTransform).localPosition;
            Vector2 smoothedPosition = Vector2.Lerp(currentPosition, localPoint, SmoothSpeed * Time.deltaTime);
            (transform as RectTransform).localPosition = smoothedPosition;
        }else{
            (transform as RectTransform).localPosition = localPoint;
        }
    }

    private Vector2 GetPosition(){
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Target.position);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        return localPoint;
    }

    public void SetTarget(Transform newTarget){
        Target = newTarget;
        (transform as RectTransform).localPosition = GetPosition();
    }
}