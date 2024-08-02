using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/Upgrade")]
public class UpgradeScriptableObject : ScriptableObject {
    [SerializeField] private float Value;
    [SerializeField] private float Cost;
    [SerializeField] private float Updgrade_CostMultiplier;
    [SerializeField] private float Updgrade_ValueIncreace;

    #region GET
    public float GetValue(){ return Value; }
    public float GetCost(){ return Cost; }

    public float GetNext_Value(){ return Value + Updgrade_ValueIncreace; }
    public float GetNext_Cost(){ return Cost * Updgrade_CostMultiplier; }
    #endregion

    #region SET
    public void SetValue(float _value){ Value = _value; }
    public void SetCost(float _cost){ Cost = _cost; }
    #endregion
}