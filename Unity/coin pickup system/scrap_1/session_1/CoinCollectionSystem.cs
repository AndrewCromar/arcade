using System.Collections.Generic;
using UnityEngine;

public class CoinCollectionSystem : MonoBehaviour {
    [Header ("UI")]
    [SerializeField] private GameObject coin_object;
    [SerializeField] private GameObject coin_object_parent;

    [Header ("Position")]
    [SerializeField] private Vector3 start;
    [SerializeField] private Vector3 end;

    [Header ("Sound")]
    [SerializeField] private GameObject coin_collect_sound;
    [SerializeField] private GameObject coin_pickup_sound;
    [SerializeField] private float sound_lifetime;

    private List<GameObject> sounds = new List<GameObject>();

    public void CollectCoins(int num_coins){
        for(int i = 0; i < num_coins; i ++){
            GameObject new_coin = Instantiate(coin_object);
            new_coin.transform.parent = coin_object_parent.transform;
            new_coin.GetComponent<CoinComponent>().start = start;
            new_coin.GetComponent<CoinComponent>().end = end;
            new_coin.GetComponent<CoinComponent>().show_delay = 0.05f * i;
            new_coin.GetComponent<CoinComponent>().coin_pickup_sound = coin_pickup_sound;
            new_coin.GetComponent<CoinComponent>().coin_collect_sound = coin_collect_sound;
        }
    }
}
