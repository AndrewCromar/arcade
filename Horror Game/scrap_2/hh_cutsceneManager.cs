using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class hh_cutsceneManager : MonoBehaviour {
    [HideInInspector] public static hh_cutsceneManager instance;

    [SerializeField] private PlayableDirector playableDirector;

    [SerializeField] private TimelineAsset startCutscene;
    [SerializeField] private TimelineAsset coffeeCutscene;

    private void Awake(){
        instance = this;
    }

    public void PlayStartCutscene(){
        playableDirector.playableAsset = startCutscene;
        playableDirector.Play();
    }

    public void PlayCoffeeCutscene(){
        playableDirector.playableAsset = coffeeCutscene;
        playableDirector.Play();
    }
}