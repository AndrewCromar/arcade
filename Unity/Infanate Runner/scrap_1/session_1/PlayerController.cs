using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jump_power;
    [SerializeField] private float smash_power;
    [SerializeField] private float forward_speed;
    [SerializeField] private float lane_change_speed;

    [SerializeField] private int current_lane;

    [SerializeField] private Transform ground_check;
    [SerializeField] private LayerMask ground_layer;
    [SerializeField] private float ground_distance;
    private bool is_grounded;

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    [SerializeField] private float minDistanceForSwipe;
    private Direction last_direction;
    private float swipe_angle;

    private enum Direction { None, Up, Down, Right, Left }

    private void Update(){
        transform.position += new Vector3(0, 0, forward_speed * Time.deltaTime);

        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_layer);
        if(is_grounded){ transform.position += new Vector3(0, 0.005f, 0); }

        CheckInput();
        DoLanes();
    }

    private void CheckInput(){
        if (Input.touchCount == 1){
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began){
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved){
                fingerUpPosition = touch.position;
                DetectSwipe();
                UseInput();
            }

            if (touch.phase == TouchPhase.Ended){
                fingerUpPosition = touch.position;
                last_direction = Direction.None;
            }
        }
    }

    private void UseInput(){
        Direction direction = GetClosestDirection(swipe_angle);
        if(direction == last_direction){ return; }

        if(direction == Direction.Up && is_grounded){
            rb.AddForce(new Vector3(0, jump_power, 0), ForceMode.Force);
        }

        if(direction == Direction.Down && !is_grounded){
            rb.AddForce(new Vector3(0, -smash_power, 0), ForceMode.Force);
        }

        if(direction == Direction.Left){
            current_lane --;
            current_lane = Mathf.Clamp(current_lane, -1, 1);
        }

        if(direction == Direction.Right){
            current_lane ++;
            current_lane = Mathf.Clamp(current_lane, -1, 1);
        }

        last_direction = direction;
    }

    private void DoLanes(){
        Vector3 new_position = transform.position;
        new_position.x = Mathf.Lerp(transform.position.x, (current_lane == -1 ? -2 : (current_lane == 0 ? 0 : (current_lane == 1 ? 2 : 0))), lane_change_speed * Time.deltaTime);
        transform.position = new_position;
    }

    private void DetectSwipe(){
        if (Vector2.Distance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe){
            Vector2 swipeDirection = fingerUpPosition - fingerDownPosition;
            swipe_angle = Mathf.Atan2(swipeDirection.y, swipeDirection.x) * Mathf.Rad2Deg;
        }
    }

    private Direction GetClosestDirection(float angle) {
        if (angle >= -45 && angle < 45) {
            return Direction.Right;
        } else if (angle >= 45 && angle < 135) {
            return Direction.Up;
        } else if (angle >= -135 && angle < -45) {
            return Direction.Down;
        } else {
            return Direction.Left;
        }
    }
}