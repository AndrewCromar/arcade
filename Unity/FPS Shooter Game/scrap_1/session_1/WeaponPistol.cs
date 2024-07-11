using UnityEngine;

public class WeaponPistol : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject shoot_sound;
    [SerializeField] private GameObject shell_hit_ground_sound;
    [SerializeField] private GameObject muzzle_position;
    [SerializeField] private GameObject muzzle_flash_particle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
            Instantiate(shoot_sound, transform.position, Quaternion.identity);
            Instantiate(shell_hit_ground_sound, transform.position, Quaternion.identity);
            GameObject new_muzzle_flash = Instantiate(muzzle_flash_particle, muzzle_position.transform.position, Quaternion.identity);
            new_muzzle_flash.transform.parent = muzzle_position.transform;
            new_muzzle_flash.transform.localRotation = Quaternion.identity;
        }
    }

    private void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            if (hitObject.CompareTag("dummy"))
            {
                Dummy dummyScript = hitObject.GetComponent<Dummy>();
                if (dummyScript != null)
                {
                    dummyScript.Hit(damage);
                }
            }
        }
    }
}