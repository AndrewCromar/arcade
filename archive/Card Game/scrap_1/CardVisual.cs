using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour {
    [Header ("Settings")]
    [SerializeField] private float moveSmoothing;
    [SerializeField] private float hoverYOffset;
    [SerializeField] private float selectYOffset;

    [Header ("Debug")]
    [SerializeField] private Image image;
    [SerializeField] private GameObject targetCard;
    [SerializeField] private CardController targetCardScript;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform targetCardRectTransform;
    [SerializeField] private Vector2 positionOffset;
    [SerializeField] private float thisWidth;

    private void Awake(){
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        thisWidth = rectTransform.sizeDelta.x;
        transform.SetParent(GameObject.FindGameObjectWithTag("card_visual_parent").transform);
    }

    private void Update(){
        // check for x offsets
        float targetCardWith = targetCardRectTransform.sizeDelta.x;
        positionOffset.x = (thisWidth / 2) - (targetCardWith / 2);

        // check for y offsets
        if(targetCardScript.GetIsSelected()) positionOffset.y = selectYOffset;
        else if(targetCardScript.GetIsHovered()) positionOffset.y = hoverYOffset;
        else positionOffset.y = 0;

        // set position
        RectTransform targetRectTransform = targetCard.GetComponent<RectTransform>();
        Vector3 targetPosition = targetRectTransform.position;

        rectTransform.position = Vector3.Lerp(rectTransform.position, targetPosition + new Vector3(positionOffset.x, positionOffset.y, 0), moveSmoothing * Time.deltaTime);
    }

    public void SetTargetCard(GameObject _targetCard){
        targetCard = _targetCard;
        targetCardScript = targetCard.GetComponent<CardController>();
        targetCardRectTransform = targetCard.GetComponent<RectTransform>();
    }

    public void SetSprite(Sprite _sprite){ image.sprite = _sprite; }
}