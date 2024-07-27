using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [Header ("References")]
    [SerializeField] private GameObject OrePrefab;

    [Header ("Settings")]
    [SerializeField] private float SpawnRate;
    [SerializeField] private float SlightVarietion;

    [Header ("Debug")]
    [SerializeField] private float counter;

    private void Update(){
        counter -= Time.deltaTime;
        if(counter > 0) return;
        counter = SpawnRate;

        Instantiate(OrePrefab, (Vector2)transform.position + new Vector2(Random.Range(-SlightVarietion, SlightVarietion), 0), Quaternion.identity);
    }
}