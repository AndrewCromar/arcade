using UnityEngine;

public class ElevatorController : MonoBehaviour {
    [SerializeField] private Vector3[] floorPositions;
    [SerializeField] private Animator animator;
    [SerializeField] bool open = false;
    [SerializeField] public State state = State.Closed;

    public enum State {
        Closed,
        Jammed,
        Fixed
    }

    private void Update(){
        UpdateAnimator();
    }

    private void UpdateAnimator(){
        animator.SetBool("open", open);
        animator.SetBool("jammed", state == State.Jammed);
    }

    public void buttonPressed(int button){
        if(state == State.Closed){
            state = State.Jammed;
        }

        if(state == State.Fixed){
            if(button <= 10){
                open = false;
                GetComponent<ElevatorGoTo>().GoTo(floorPositions[button - 1]);
            } 
        }
    }

    public void onFixed(){ open = true; state = State.Fixed; }

    public void atBottom(){ open = true; }
}