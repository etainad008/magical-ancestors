using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyCurrentHealth;
    
    private Rigidbody2D rb;
    private GameObject player;
    public GameEvent OnEnemyAttack;

    [SerializeField] EnemyScriptableObject enemySO;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        enemyCurrentHealth = enemySO.enemyMaxHealth;
        SetEnemyType();
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        
        if(Vector2.Distance(transform.position, player.transform.position) > enemySO.enemyAttackRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySO.enemySpeed * Time.deltaTime);
        }

        else
        {
            Attack();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Projectile>() != null)
        {
            TakeDamage(other.gameObject.GetComponent<Projectile>().projectileSO.projectileDamage);
            Destroy(other.gameObject);
        }
    }

    private void Attack()
    {
        //Display attack animation
        OnEnemyAttack.Raise(enemySO.enemyDamage);
    }

    private void TakeDamage(float amount)
    {
        enemyCurrentHealth -= amount;
        
        if(enemyCurrentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }

    private void SetTexture(Sprite Texture)
    {
        GetComponent<SpriteRenderer>().sprite = Texture;
    }

    private void SetEnemyType()
    {
        SetTexture(enemySO.enemyTexture);
    }
}
