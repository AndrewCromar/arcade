using UnityEngine;

public class WeaponPositionCore : MonoBehaviour
{
    [SerializeField] private float lerp_speed;
    private Vector3 target_position = Vector3.zero;

    private void Update()
    {
        Vector3 currentPosition = transform.localPosition;
        Vector3 newPosition = Vector3.Lerp(currentPosition, target_position, lerp_speed * Time.deltaTime);
        transform.localPosition = newPosition;
    }
}