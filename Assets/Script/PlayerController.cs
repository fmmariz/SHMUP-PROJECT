using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb ;
    private PShootingController _sc;

    [SerializeField]
    private float _movespeed;
    [SerializeField]
    private float _shootingDelay;

    private Vector3 movement;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sc = GetComponent<PShootingController>();
    }

    private float _shootingDelayTimer;

    // Update is called once per frame
    void Update()
    {
         movement = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0f
        );
        Vector3 displacement = _movespeed * movement.normalized;
        _rb.MovePosition(_rb.transform.position + displacement);

        if(Input.GetKey(KeyCode.Z) && _shootingDelayTimer <= 0){
            _shootingDelayTimer = _shootingDelay;
            Debug.Log("Z Pressed.");
            Vector3 above = Vector2.up * 0.1f;
                _sc.Shoot(transform.position + above, 12f, 0f, 1.5f);
                _sc.Shoot(transform.position + above, 12f, -25f, 1f);
                _sc.Shoot(transform.position + above, 12f, 25f, 1f);

        }
        _shootingDelayTimer -= Time.deltaTime;
    }

}
