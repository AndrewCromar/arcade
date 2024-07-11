using UnityEngine;

public class HealthBar : MonoBehaviour {
    [SerializeField] private float health;
    [SerializeField] private GameObject fill;
    [SerializeField] private GameObject fill_smooth;
    private float max_fill_width = 200;
    private float targetFillWidth;
    [SerializeField] private float lerpSpeed = 3f;

    private void Update(){
        RectTransform fillRectTransform = fill.GetComponent<RectTransform>();
        RectTransform fillSmoothRectTransform = fill_smooth.GetComponent<RectTransform>();

        float currentFillWidth = fillSmoothRectTransform.sizeDelta.x;
        float lerpedFillWidth = Mathf.Lerp(currentFillWidth, targetFillWidth, Time.deltaTime * lerpSpeed);
        fillSmoothRectTransform.sizeDelta = new Vector2(lerpedFillWidth, fillSmoothRectTransform.sizeDelta.y);

        float targetPosX = -100 + (lerpedFillWidth / 2f);
        fillSmoothRectTransform.localPosition = new Vector3(targetPosX, fillSmoothRectTransform.localPosition.y, fillSmoothRectTransform.localPosition.z);

        float fillSmoothWidth = max_fill_width * (health / 100f);
        fillRectTransform.sizeDelta = new Vector2(fillSmoothWidth, fillRectTransform.sizeDelta.y);
        float targetSmoothPosX = -100 + (fillSmoothWidth / 2f);
        fillRectTransform.localPosition = new Vector3(targetSmoothPosX, fillRectTransform.localPosition.y, fillRectTransform.localPosition.z);
    }

    public void SetHealth(float new_health){
        health = new_health;
        targetFillWidth = max_fill_width * (health / 100f);
    }
}