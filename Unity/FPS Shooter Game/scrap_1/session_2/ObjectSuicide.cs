using UnityEngine;

public class ObjectSuicide : MonoBehaviour {
    [SerializeField] private float time_to_death;

    private void Update(){
        time_to_death -= Time.deltaTime;
        if(time_to_death <= 0){
            Destroy(this.gameObject);
        }
    }
}