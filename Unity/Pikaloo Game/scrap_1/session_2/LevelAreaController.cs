using UnityEngine;
using UnityEngine.UI;

public class LevelAreaController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private ProgressBarController ProgressBarControllerRef; 
    [SerializeField] private Button LevelUpButtonRef;
    [SerializeField] private Text LevelTextRef;

    [Header ("Settings")]
    [SerializeField] private float ScoreWorth = 50;

    [Header ("Debug")]
    [SerializeField] private float LevelProgress;

    private void Awake(){
        GameManager.Instance.OnScoreChangeEvent.AddListener(OnScoreChange);
        GameManager.Instance.OnLevelChangeEvent.AddListener(OnLevelChange);
        LevelUpButtonRef.onClick.AddListener(OnLevelUpButtonPressed);
    }

    private void Update(){
        LevelUpButtonRef.interactable = LevelProgress == 100;
    }

    private void OnScoreChange(){
        float scoreDifference = GameManager.Instance.GetScoreDifference();
        if(scoreDifference <= 0) return;

        LevelProgress += scoreDifference * (ScoreWorth / 10);
        LevelProgress = Mathf.Clamp(LevelProgress, 0, 100);

        UpdateLevelProgressBar();
    }

    private void OnLevelChange(){
        LevelTextRef.text = "Level " + GameManager.Instance.GetLevel();
        LevelProgress = 0;
        ScoreWorth = ScoreWorth / 2;

        UpdateLevelProgressBar();
    }

    private void UpdateLevelProgressBar(){
        ProgressBarControllerRef.SetProgress(LevelProgress / 100);
    }

    private void OnLevelUpButtonPressed(){
        GameManager.Instance.AddLevel(1);
    }
}