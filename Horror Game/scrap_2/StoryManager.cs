using UnityEngine;
using UnityEngine.Playables;

public class StoryManager : MonoBehaviour {
    public float point_in_story = 0;
    // 0 = just started
    // 0.1 = finished starting cutscene
    // 0.2 = opened door
    // 1 = got to kitchen
    // 2 = interacted with coffee
    // 2.1 = coffee cutscene finished
    // 3 = transported to other kitchen
    // 4 = finding elevator
    // 5 = found elevator
    // 5.1 = elevator broken and looking for parts
    // 6 = found elevator parts
    // 7 = fixed elevator
    // 7.1 = entered elevator
    // 7.2 = pressed the down button
    // 7.3 = finished elevator cutscene
    // 8 = made it to ground floor
    // 8.1 = tried to exit out front doors
    // 8.2 = saw monster shadow
    // 8.3 = got headache
    // 9 = passed out
    // 10 = finished chapter 1

    public static StoryManager instance;

    [SerializeField] private hh_taskCard taskCardPrefab;

    [SerializeField] private GameObject player;
    [SerializeField] private hh_playerMovement player_movement_script;
    [SerializeField] private GameObject camera_container;

    [SerializeField] private float start_cutscene_duration;
    private float start_cutscene_timer;
    private bool start_cutscene_started = false;
    private bool start_cutscene_finished = false;

    [SerializeField] private GameObject starting_cutscene;
    [SerializeField] private GameObject room_spawn_location;

    [SerializeField] private GameObject playerEnteredKitchenObject;
    [SerializeField] private Transform coffee_cutscene_positioning;

    [SerializeField] private BoxCollider leave_room_collider;

    [SerializeField] private float coffee_cutscene_duration;
    private float coffee_cutscene_timer;
    private bool coffee_cutscene_started = false;
    private bool coffee_cutscene_finished = false;

    private bool start_cutscene_enabled;
    private bool player_opened_door;

    private void Awake(){ instance = this; }

    private void Update(){
        if(point_in_story == 0 && !start_cutscene_enabled){
            ActivateStartingCutscene();
        }

        if(start_cutscene_started && !start_cutscene_finished){
            start_cutscene_timer -= Time.deltaTime;
            if(start_cutscene_timer <= 0){
                start_cutscene_finished = true;
                StartingCutsceneFinished();
            }
        }

        if(coffee_cutscene_started && !coffee_cutscene_finished){
            coffee_cutscene_timer -= Time.deltaTime;
            if(coffee_cutscene_timer <= 0){
                coffee_cutscene_finished = true;
                CoffeeCutsceneStopped();
            }
        }
    }

    private void ActivateStartingCutscene(){
        //this will be different later but for now enable text
        Debug.Log("Starting start cutscene.");
        starting_cutscene.SetActive(true);
        start_cutscene_enabled = true;
        StartingCutsceneFinished();
    }

    public void StartingCutsceneFinished(){
        Debug.Log("Finished starting cutscene.");
        point_in_story = 0.1f;
        SpawnPlayerInRoom();
    }

    private void SpawnPlayerInRoom(){
        Debug.Log("Player spawned.");
        player.transform.position = room_spawn_location.transform.position;
        player.SetActive(true);
        hh_taskCard newTaskCard = Instantiate(taskCardPrefab);
        newTaskCard.SetTaskDescription("Exlpore.");
    }

    public void PlayerOpenedDoor(){
        if(player_opened_door){ return; }

        Debug.Log("Player opened door.");
        point_in_story = 0.2f;
        player_opened_door = true;
    }

    public void PlayerEnteredKitchen(){
        point_in_story = 1;
        playerEnteredKitchenObject.SetActive(false);
        
        // play "oh im thirsty" sound effect

        hh_taskCard newTaskCard = Instantiate(taskCardPrefab);
        newTaskCard.SetTaskDescription("Find something to drink.");
    }

    public void StartCoffeeCutscene(){
        point_in_story = 2;

        player_movement_script.player_can_dostuff = false;

        player.transform.position = coffee_cutscene_positioning.position;
        player.transform.rotation = coffee_cutscene_positioning.rotation;

        camera_container.transform.rotation = coffee_cutscene_positioning.rotation;

        hh_cutsceneManager.instance.PlayCoffeeCutscene();

        coffee_cutscene_timer = coffee_cutscene_duration;
        coffee_cutscene_started = true;

        Debug.Log("Start coffee cutscene.");
    }

    private void CoffeeCutsceneStopped(){
        point_in_story = 2.1f;

        player_movement_script.player_can_dostuff = true;

        hh_taskCard newTaskCard = Instantiate(taskCardPrefab);
        newTaskCard.SetTaskDescription("Coffee cutscene finished.");
    }
}