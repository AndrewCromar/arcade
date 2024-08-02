using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/Upgrade")]
public class UpgradeScriptableObject : ScriptableObject {
    [SerializeField] private float Value;
    [SerializeField] private float Cost;

    #region API
    #region GET

    public float GetValue(){ return Value; }
    public float GetCost(){ return Cost; }

    #endregion

    #region SET

    public void SetValue(float _value){ Value = _value; }
    public void SetCost(float _cost){ Cost = _cost; }
    
    #endregion
    #endregion
}