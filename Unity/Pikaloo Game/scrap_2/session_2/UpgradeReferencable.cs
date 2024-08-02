using UnityEngine;

public class UpgradeReferencable : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private UpgradeScriptableObject UpgradeRef;

    [Header ("Debug")]
    [SerializeField] private UpgradeScriptableObject UpgradeDuplicateRef;

    private void Awake(){ UpgradeDuplicateRef = Instantiate(UpgradeRef); }

    public UpgradeScriptableObject GetUpgrade(){ return UpgradeDuplicateRef; }
}