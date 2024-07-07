using UnityEngine;

public class hh_doorInteract : MonoBehaviour {
    [SerializeField] private bool door_locked = true;
    [SerializeField] private GameObject rotate_point;
    [SerializeField] private string player_tag;
    private Vector3 closed_rotation = Vector3.zero;
    [SerializeField] private Vector3 x_grater_open_position;
    [SerializeField] private Vector3 x_less_open_position;
    [SerializeField] private Collider door_collider;
    [SerializeField] private float smoothing;
    private Vector3 needed_rotation;
    private bool closed = true;

    [Header ("Soundes")]
    [SerializeField] private GameObject open_sound;
    [SerializeField] private GameObject close_sound;
    [SerializeField] private GameObject locked_sound;

    public void Interact() {
        if (!door_locked) {
            if (closed) { OpenDoor(); } else { CloseDoor(); }
        } else { Instantiate(locked_sound, transform.position, Quaternion.identity); }
    }

    private void Update(){
        rotate_point.transform.localRotation = Quaternion.Lerp(rotate_point.transform.localRotation, Quaternion.Euler(needed_rotation), smoothing * Time.deltaTime);

        if (Quaternion.Angle(rotate_point.transform.localRotation, Quaternion.Euler(needed_rotation)) < 5) {
            door_collider.enabled = true;
        } else {
            door_collider.enabled = false;
        }
    }

    private void OpenDoor() {
        Instantiate(open_sound, transform.position, Quaternion.identity);
        Vector3 player_position = GameObject.FindGameObjectWithTag(player_tag).transform.position;
        needed_rotation = player_position.x > transform.position.x ? x_grater_open_position : x_less_open_position;
        closed = false;
    }

    private void CloseDoor() {
        Instantiate(close_sound, transform.position, Quaternion.identity);
        needed_rotation = closed_rotation;
        closed = true;
    }
}
