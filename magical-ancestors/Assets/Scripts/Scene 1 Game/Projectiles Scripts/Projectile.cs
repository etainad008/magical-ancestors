using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public AttackProjectileScriptableObject projectileSO;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetProjectileType();
        Invoke(nameof(LifeTimeEnded), projectileSO.projectileLifeTime);
    }

    private void LifeTimeEnded()
    {
        Destroy(gameObject);
    }

    private void AddShotForce(float ShotForce)
    {
        rb.AddForce(-transform.right * ShotForce, ForceMode2D.Impulse);
    }

    private void SetTexture(Sprite Texture)
    {
        GetComponent<SpriteRenderer>().sprite = Texture;
    }

    private void SetProjectileType()
    {
        
        AddShotForce(projectileSO.projectileShotForce);
        SetTexture(projectileSO.projectileTexture);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
