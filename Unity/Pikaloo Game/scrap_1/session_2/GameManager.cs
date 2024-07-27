using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    [HideInInspector] public static GameManager Instance;

    [Header ("Events")]
    [HideInInspector] public UnityEvent OnScoreChangeEvent;
    [HideInInspector] public UnityEvent OnLevelChangeEvent;

    [Header ("Debug")]
    [SerializeField] private float Score;
    [SerializeField] private int Level;

    [SerializeField] private float ScoreDifference;

    private void Awake(){
        Instance = this;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.S)){ AddScore(10); }
        if(Input.GetKeyDown(KeyCode.L)){ AddLevel(1); }
    }

    public void AddScore(float _addScore){
        Score += _addScore;
        ScoreDifference = _addScore;

        OnScoreChangeEvent.Invoke();
    }
    public void AddLevel(int _addLevel){
        Level += _addLevel;

        OnLevelChangeEvent.Invoke();
    }

    public float GetScore(){ return Score; }
    public float GetScoreDifference(){ return ScoreDifference; }
    public int GetLevel(){ return Level; }
}