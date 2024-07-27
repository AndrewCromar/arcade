using UnityEngine;

public class BallController : MonoBehaviour {
    [Header ("Settings")]
    [SerializeField] private float CollectPoints;

    public float GetCollectPoints(){ return CollectPoints; }
}