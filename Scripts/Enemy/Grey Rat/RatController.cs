using UnityEngine;

/* Script for logic and interactions with the rat enemy. Rats will chase the player around
 * the map regardless of where the player goes and try to swarm the player unless dealth
 * with.
 */
public class RatController : MonoBehaviour
{
    // Dependancies
    public Transform target;
    public GameObject menuHandler;

    // Adjustable movement
    public float speed = 3.0f;

    // Components
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {   
        Move();
        SetAnimatorValues();
    }

    // Move towards target gameObject
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

    private void SetAnimatorValues()
    {
        _animator.SetFloat("Move X", transform.position.x);
        _animator.SetFloat("Move Y", transform.position.y);
    }

    // End game state
    private void OnCollisionEnter2D(Collision2D collision)
    {
        WolfController player = collision.gameObject.GetComponent<WolfController>();
        
        if (player != null)
        {
            menuHandler.GetComponent<MenuHandler>().ActivateLoseMenu();
        }

    }

    // Death state
    private void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileController projectile = other.GetComponent<ProjectileController>();

        if (projectile != null)
        {
            SoundController.PlaySound("EnemyDeath");
            Destroy(gameObject);
        }
    }
}
