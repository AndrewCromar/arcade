using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private Image IconRef;

    [SerializeField] private Text TitleTextRef;

    [SerializeField] private Button ButtonRef;
    [SerializeField] private Text ButtonTextRef;

    [SerializeField] private Text ValueTextRef;

    [SerializeField] private UpgradeReferencable UpgradeRef;

    [Header ("Settings")]
    [SerializeField] private Sprite Icon;

    [SerializeField] private string Title;

    [SerializeField] private string ValueTextPrefix;
    [SerializeField] private string ValueTextSufix;

    private void Awake(){
        IconRef.sprite = Icon;
        TitleTextRef.text = Title;
        ButtonRef.onClick.AddListener(OnUpgradeButtonPressed);
    }

    private void Update(){
        ButtonRef.interactable = GameManager.Instance.CanUpgrade(UpgradeRef.GetUpgrade());
        ButtonTextRef.text = "$" + UpgradeRef.GetUpgrade().GetCost().ToString();

        ValueTextRef.text = ValueTextPrefix + UpgradeRef.GetUpgrade().GetValue().ToString() + ValueTextSufix;
    }

    private void OnUpgradeButtonPressed(){
        GameManager.Instance.DoUpgrade(UpgradeRef.GetUpgrade());
    }
}