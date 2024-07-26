using UnityEngine;

public class CoinComponent : MonoBehaviour {
    public Vector3 start;
    public Vector3 end;
    private Vector3 offset;
    private float smoothing = 10;

    private float time_to_collect = 0.75f;

    public GameObject coin_pickup_sound;
    public GameObject coin_collect_sound;

    public float show_delay;

    private bool did_startup = false;
    private bool did_ending = false;

    private void Start(){
        transform.position = start;
        offset = new Vector3(Random.Range(-200, 200), Random.Range(200, 400), 0);

        transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update(){
        show_delay -= Time.deltaTime;

        if(show_delay < 0){
            time_to_collect -= Time.deltaTime;

            if(!did_startup){
                transform.localScale = new Vector3(1, 1, 1);
                GameObject new_sound = Instantiate(coin_pickup_sound);
                did_startup = true;
            }

            if(time_to_collect > 0){
                transform.position = Vector3.Lerp(transform.position, start + offset, smoothing * Time.deltaTime);
            }else{
                transform.position = Vector3.Lerp(transform.position, end, smoothing * Time.deltaTime);

                if(!did_ending){
                    GameObject new_sound = Instantiate(coin_collect_sound);
                    did_ending = true;
                }
            }
        }
    }
}