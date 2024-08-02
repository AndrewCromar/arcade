using UnityEngine;
using UnityEngine.UI;

public class PointsAreaController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private Text PointsTextRef;

    private void Update(){
        PointsTextRef.text = GameManager.Instance.GetPoints().ToString();
    }
}