using UnityEngine;

public class ProgressBarController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private RectTransform ImmediateObject;
    [SerializeField] private RectTransform SmoothObject;

    [Header ("Settings")]
    [SerializeField] private float MaxWidth;
    [SerializeField] private float Smoothing;

    [Header ("Debug")]
    [SerializeField] private float Progress;

    private void Update(){
        float width1 = MaxWidth * Progress;
        Vector2 position1 = new Vector2((-(MaxWidth / 2)) + (width1 / 2), 0);
        SetObjectWidthAndPosition(ImmediateObject, width1, position1);

        float width2 = Mathf.Lerp(SmoothObject.sizeDelta.x, MaxWidth * Progress, Smoothing * Time.deltaTime);
        Vector2 position2 = new Vector2((-(MaxWidth / 2)) + (width2 / 2), 0);
        SetObjectWidthAndPosition(SmoothObject, width2, position2);
    }

    private void SetObjectWidthAndPosition(RectTransform _object, float _width, Vector2 _position){
        _object.sizeDelta = new Vector2(_width, _object.sizeDelta.y);
        _object.anchoredPosition = _position;
    }

    public void SetProgress(float _setProgress){ Progress = _setProgress; }
}