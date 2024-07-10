using UnityEngine;

public class global_objectSuicide : MonoBehaviour {
    [Header ("Settings")]
    [SerializeField] private float _lifetime;

    private void Update(){
        _lifetime -= Time.deltaTime;
        if(_lifetime > 0) return;
        Destroy(gameObject);
    }
}