using UnityEngine;

public class hh_playerEnterElevatorRoomCollider : MonoBehaviour {
    [SerializeField] private bool used;

    private void OnTriggerEnter(Collider col){
        if(used) return;

        if(col.CompareTag("Player")){ used = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach(GameObject enemy in enemies){
                Debug.Log("Change this later!");
                Destroy(enemy);
            }
        }
    }
}