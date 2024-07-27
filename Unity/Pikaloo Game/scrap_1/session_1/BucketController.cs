using UnityEngine;

public class BucketController : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D col){
        Destroy(col.gameObject);
    }
}