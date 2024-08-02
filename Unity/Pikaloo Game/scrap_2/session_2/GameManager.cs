using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    [HideInInspector] public static GameManager Instance;

    [Header ("Events")]
    [HideInInspector] public UnityEvent OnPointChangeEvent;
    [HideInInspector] public UnityEvent OnLevelChangeEvent;

    [Header ("Debug")]
    [SerializeField] private float Points;
    [SerializeField] private int Level;

    [SerializeField] private float PointsDifference;

    private void Awake(){
        Instance = this;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.S)){ AddPoints(10); }
        if(Input.GetKeyDown(KeyCode.L)){ AddLevel(1); }
    }

    public void AddPoints(float _addPoints){
        Points += _addPoints;
        PointsDifference = _addPoints;

        OnPointChangeEvent.Invoke();
    }
    public void AddLevel(int _addLevel){
        Level += _addLevel;

        OnLevelChangeEvent.Invoke();
    }

    public float GetPoints(){ return Points; }
    public float GetPointDifference(){ return PointsDifference; }
    public int GetLevel(){ return Level; }

    #region Upgrades
        public bool CanUpgrade(UpgradeScriptableObject _upgrade){
            return _upgrade.GetCost() <= Points;
        }

        public void DoUpgrade(UpgradeScriptableObject _upgrade){
            if(!CanUpgrade(_upgrade)) return;
            Points -= _upgrade.GetCost();
            _upgrade.SetValue(_upgrade.GetNext_Value());
            _upgrade.SetCost(_upgrade.GetNext_Cost());
        }

    #endregion
}