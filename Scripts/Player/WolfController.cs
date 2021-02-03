using UnityEngine;

public class WolfController : MonoBehaviour
{
    // Properties
    public bool isBorking { get; set; }

    // Adjustable
    public float speed = 1.5f;

    // Components
    private Animator _animator;
    
    // Attack pattern
    private float _maxBorkTimer = 0.5f;
    private float _borkTimer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        isBorking = true;
    }

    void Update()
    {
        RotateTowardsMouse();
    }

    private void FixedUpdate()
    {
        if (isBorking) {
            Transform borkDistance = transform.Find("BorkDistance");
            transform.position = Vector3.Lerp(transform.position, borkDistance.position, speed * Time.deltaTime);
            
            HandleBorkTimer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = transform.position;
    }

    private void RotateTowardsMouse()
    {
        //Rotation based on mouse cursor
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5.23f;

        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void HandleBorkTimer()
    {
        _borkTimer -= Time.deltaTime;
        _animator.SetBool("Mouse0 Pressed", true);

        if (_borkTimer < 0)
        {
            isBorking = false;
            _borkTimer = _maxBorkTimer;
            _animator.SetBool("Mouse0 Pressed", false);
        }
    }
}
