using UnityEngine;

public class LunaController : MonoBehaviour {
#region Variables
    [Header ("Gravity Settings")]
    [SerializeField] private float gravity = 0.981f;

    [Header ("Rotation Settings")]
    [SerializeField] private float rotationSmoothing = 20;
    [SerializeField] private float maxZRotation = 90;
    [SerializeField] private float minZRotation = -90;

    [Header ("Dragging Settings")]
    [SerializeField] private float dragRotationMultiplier = 100;
    [SerializeField] private float xAirDrag = 10;

    [Header ("Idle Settings")]
    [SerializeField] private float maxIdleTime = 50;
    [SerializeField] private float minIdleTime = 10;

    [Header ("Walking Settings")]
    [SerializeField] private float maxWalkingTime = 15;
    [SerializeField] private float minWalkingTime = 5;
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private int chanceToIdleAfterTurn = 50;
    [SerializeField] private int chanceToSleepAfterTurn = 25;

    [Header ("Sleeping Settings")]
    [SerializeField] private float maxSleepTime = 120;
    [SerializeField] private float minSleepTime = 40;

    [Header ("Debug")]
    [SerializeField] private Animator animator;

    [SerializeField] private float idleTime;
    [SerializeField] private float sleepTime;

    [SerializeField] private bool walkingRight;
    [SerializeField] private float walkingTime;

    [SerializeField] private bool dragging;
    [SerializeField] private bool falling;

    [SerializeField] private float yVelocity;
    [SerializeField] private float xVelocity;

    [SerializeField] private float zRotation;

    [SerializeField] private float worldTop;
    [SerializeField] private float worldBottom;
    [SerializeField] private float worldLeft;
    [SerializeField] private float worldRight;

    [SerializeField] private Vector3 lastPosition;

    [SerializeField] private State state;


    private enum State {
        Idle,
        Walking,
        Sleeping
    }
#endregion

#region Default Functions
    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Start(){
        GetScreenBounds();
    }

    private void GetScreenBounds(){
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        worldTop = Camera.main.ScreenToWorldPoint(new Vector3(0, screenHeight, 0)).y;
        worldBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        worldLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        worldRight = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x;
    }
    
    private void Update(){
        DoDrag();
        DoFalling();

        DoStates();

        UpdateAnimator();

        xVelocity = lastPosition.x - transform.position.x;
        lastPosition = transform.position;

        Vector3 newRotation = new Vector3(0, 0, zRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), rotationSmoothing * Time.deltaTime);
    }

    private void UpdateAnimator(){
        animator.SetBool("dragging", dragging);
        animator.SetBool("falling", falling);
        animator.SetFloat("state", state == State.Idle ? 0 : state == State.Walking ? 0.5f : 1);
    }
#endregion

#region Dragging
    private void DoDrag(){
        Vector3 mouseWorldPositiion = CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition();
        if(Input.GetMouseButtonDown(0)){
            if(Physics2D.OverlapPoint(mouseWorldPositiion)){
                dragging = true;
            }
        }

        if(Input.GetMouseButtonUp(0)){
            if(dragging){
                dragging = false;
            }
        }

        if(dragging){
            Vector3 targetPosition = new Vector3(mouseWorldPositiion.x, mouseWorldPositiion.y, 0);
            transform.position = targetPosition;

            zRotation = xVelocity * dragRotationMultiplier;
            zRotation = Mathf.Clamp(zRotation, minZRotation, maxZRotation);
        }
    }
#endregion

#region Falling
    private void DoFalling(){
        if(dragging) return;
        falling = true;
        zRotation = 0;

        if(transform.position.y > worldBottom + (transform.localScale.y / 2)){
            yVelocity = yVelocity + (-(gravity * gravity) * Time.deltaTime);
            Vector3 newPosition = transform.position + new Vector3(0, yVelocity, 0);
            transform.position = newPosition;
        }

        if(transform.position.y < worldBottom + (transform.localScale.y / 2)){
            Vector3 newPosition = new Vector3(transform.position.x, worldBottom + (transform.localScale.y / 2), 0);
            transform.position = newPosition;
        }

        if(transform.position.y == worldBottom + (transform.localScale.y / 2)){
            yVelocity = 0;
            falling = false;
        }
    }
#endregion

#region States
    private void DoStates(){
        if(dragging || falling) return;

        if(state == State.Idle) DoIdleState();
        if(state == State.Walking) DoWalkingState();
        if(state == State.Sleeping) DoSleepingState();
    }

    private void DoIdleState(){
        idleTime -= Time.deltaTime;
        if(idleTime > 0) return;
        idleTime = Random.Range(minIdleTime, maxIdleTime);

        state = State.Walking;
    }

    private void DoWalkingState(){
        walkingTime -= Time.deltaTime;

        if(!(walkingTime > 0)){
            walkingRight = !walkingRight;
            walkingTime = Random.Range(minWalkingTime, maxWalkingTime);

            if(Random.Range(0, 100) <= chanceToSleepAfterTurn) state = State.Sleeping;
            else if(Random.Range(0, 100) <= chanceToIdleAfterTurn) state = State.Idle;
        }

        if(transform.position.x >= worldRight - (Mathf.Abs(transform.localScale.x) / 2)) walkingRight = false;
        if(transform.position.x <= worldLeft + (Mathf.Abs(transform.localScale.x) / 2)) walkingRight = true;

        float walkingOffset = walkingRight ? 1 : -1;

        Vector3 newScale = transform.localScale;
        newScale.x = walkingOffset;
        transform.localScale = newScale;

        Vector3 newPosition = transform.position + new Vector3((walkSpeed * Time.deltaTime * walkingOffset), 0, 0);
        transform.position = newPosition;
    }

    private void DoSleepingState(){
        sleepTime -= Time.deltaTime;
        if(sleepTime > 0) return;
        sleepTime = Random.Range(minSleepTime, maxSleepTime);

        state = State.Walking;
    }
#endregion
}