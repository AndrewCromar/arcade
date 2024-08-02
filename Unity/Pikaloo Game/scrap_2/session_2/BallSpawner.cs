using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private GameObject OrePrefab;
    [SerializeField] private UpgradeReferencable UpgradeRef;

    [Header ("Settings")]
    [SerializeField] private float SlightPositionVariation;

    [Header ("Debug")]
    [SerializeField] private float counter;

    private void Update(){
        counter -= Time.deltaTime;
        if(counter > 0) return;
        counter = UpgradeRef.GetUpgrade().GetValue();

        Instantiate(OrePrefab, (Vector2)transform.position + new Vector2(Random.Range(-SlightPositionVariation, SlightPositionVariation), 0), Quaternion.identity);
    }
}