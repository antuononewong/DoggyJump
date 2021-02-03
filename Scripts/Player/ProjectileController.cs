using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Adjustable
    public float speed = 10.0f;

    // Timeout
    private float _projectileTimer = 2.0f;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * speed; 
    }

    private void Update()
    {
        _projectileTimer -= Time.deltaTime;
        if (_projectileTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RatController enemy = collision.gameObject.GetComponent<RatController>();
        BlackyController blacky = collision.gameObject.GetComponent<BlackyController>();
        EnemyWolfController enemyWolf = collision.gameObject.GetComponent<EnemyWolfController>();

        if (enemy != null)
        {
            Destroy(gameObject);
        }
        if (blacky != null)
        {
            Destroy(gameObject);
        }
        if (enemyWolf != null)
        {
            Destroy(gameObject);
        }
    }

}


