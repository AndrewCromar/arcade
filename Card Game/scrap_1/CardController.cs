using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler{
    [Header("Settings")]
    [SerializeField] private int id;
    [SerializeField] private GameObject cardVisualPrefab;

    [Header("Debug")]
    [SerializeField] private bool isHovered;
    [SerializeField] private bool isSelected;
    [SerializeField] private GameObject cardVisual;
    [SerializeField] private CardVisual cardVisualScript;

    private void Start(){
        cardVisual = Instantiate(cardVisualPrefab);
        cardVisualScript = cardVisual.GetComponent<CardVisual>();
        cardVisualScript.SetTargetCard(gameObject);
        cardVisualScript.SetSprite(CardSpriteManager.instance.GetSpriteFromId(id));
    }

    public void Deselect(){
        isSelected = false;
    }

    public bool GetIsSelected(){ return isSelected; }
    public bool GetIsHovered(){ return isHovered; }
    public int GetCardId(){ return id; }

    public void OnPointerEnter(PointerEventData eventData) {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovered = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        isSelected = true;
        CardManager.instance.SelectCard(this);
    }
}
