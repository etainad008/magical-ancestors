using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    private float Xmouse;
    private float Ymouse;
    //private bool readyToShoot;
    public int selectedProjectile = 0;
    private float shotRotateZ;
    public float offsetRotation;
    Vector2 shootDirection;

    [SerializeField] Transform shotPoint;
    [SerializeField] Projectile[] projectiles;

    private void Update()
    {
        HandleProjectileSelection();
        HandleShootProjectile();
    }

    private void HandleShootProjectile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // calculate vector dir.
            shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotPoint.position;

            // calculate rotation around Z-Axis
            shotRotateZ = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            Debug.Log(shotRotateZ);
            // Shoot projectile
            Instantiate(projectiles[selectedProjectile], shotPoint.position, Quaternion.Euler(0f,0f, shotRotateZ + offsetRotation));
        }
    }

    private void HandleProjectileSelection()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedProjectile >= projectiles.Length - 1)
            {
                selectedProjectile = 0;
            }

            else
            {
                selectedProjectile++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedProjectile <= 0)
            {
                selectedProjectile = projectiles.Length - 1;
            }

            else
            {
                selectedProjectile--;
            }
        }
    }

}
