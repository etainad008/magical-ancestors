using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New attack projectile", menuName = "Attack Projectile")]
public class AttackProjectileScriptableObject : ScriptableObject
{
    public Sprite projectileTexture;
    public int projectileDamage;
    public float projectileLifeTime;
    //[SerializeField] Collider2D projectileCollider;
    public int projectileManaCost;
    public int projectileCooldown;
    public float projectileShotForce;
    public float projectileOffsetRotation;
}
