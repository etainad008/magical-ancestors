using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public Sprite enemyTexture;
    public int enemyDamage;
    public float enemyMaxHealth;
    //[SerializeField] Collider2D enemyCollider;
    public float enemyAttackCooldown;
    public float enemySpeed;
    public float enemyAttackRadius;
    public float enemyIdleRadius;
}
