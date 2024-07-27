using UnityEngine;

public class BucketController : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private GameObject BucketTextPrefab;

    [Header ("Settings")]
    [SerializeField] private float ScoreMultiplier;

    private void Awake(){
        GameObject bucketText = Instantiate(BucketTextPrefab);
        bucketText.GetComponent<UIFollowWorldObject>().SetTarget(gameObject.transform);
        bucketText.GetComponent<BucketTextController>().SetText("x" + ScoreMultiplier);
    }

    public void OnTriggerEnter2D(Collider2D col){
        GameObject ballObject = col.gameObject;
        GameManager.Instance.AddScore(ballObject.GetComponent<BallController>().GetCollectPoints() * ScoreMultiplier);
        Destroy(ballObject);
    }
}