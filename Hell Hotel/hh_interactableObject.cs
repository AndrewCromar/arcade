using UnityEngine;
using UnityEngine.Events;

public class hh_interactableObject : MonoBehaviour {
    [SerializeField] public bool canInteract = true;
    [SerializeField] private Outline outline_object;
    [HideInInspector] public bool hovering;

    public UnityEvent onInteractEvent = new UnityEvent();

    private void Update(){
        if(hovering && canInteract){
            outline_object.enabled = true;
        } else {
            outline_object.enabled = false;
        }
        hovering = false;
    }

    public void Interact(){
        if(!canInteract) return;

        onInteractEvent.Invoke();
    }
}