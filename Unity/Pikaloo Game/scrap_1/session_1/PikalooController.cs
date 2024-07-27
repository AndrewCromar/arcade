using UnityEngine;

public class PikalooController : MonoBehaviour {
    [Header ("Settings")]
    [SerializeField] private float SwitchTime;
    [SerializeField] private float DefaultRotateSpeed;
    [SerializeField] private float RotationRandomness;

    [Header ("Debug")]
    [SerializeField] private bool RotateClockwise;
    [SerializeField] private float ZRotation;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private float counter;

    private void Awake(){
        RotateClockwise = Random.value > 0.5f;

        RotationSpeed = DefaultRotateSpeed + Random.Range(-RotationRandomness, RotationRandomness);
    }

    private void Update(){
        ZRotation += RotationSpeed * Time.deltaTime * (RotateClockwise ? 1 : -1);
        transform.rotation = Quaternion.Euler(0, 0, ZRotation);

        counter -= Time.deltaTime;
        if(counter > 0) return;
        counter = SwitchTime;
        RotateClockwise = !RotateClockwise;
    }
}