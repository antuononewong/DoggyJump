using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    // Dependancies
    public GameObject menuHandler;

    // Adjustable
    public float speed = 10.0f;

    // Attack pattern
    private float _projectileTimer = 2.0f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
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
        WolfController player = collision.GetComponent<WolfController>();
        
        if (player != null)
        {
            menuHandler.GetComponent<MenuHandler>().ActivateLoseMenu();
        }
    }
}
