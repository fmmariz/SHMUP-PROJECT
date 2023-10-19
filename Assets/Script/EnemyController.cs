using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D _rb;
    private float _speed;
    private Vector3 _direction;

    private GameObject explosionObject;
    

    void Start()
    {
    }

    public void SetupEnemy(float angle, float speed, float size){
        _direction =  Quaternion.Euler(0,0,angle) * Vector3.one;
        _speed = speed;
        _rb = GetComponent<Rigidbody2D>();
        _currentHealth = 5;


        _rb.velocity = _direction.normalized * _speed;
        float currentSize = transform.localScale.x;
        transform.localScale = new Vector3(size*currentSize, size*currentSize   , 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetExplosionObject(GameObject explosion){
        explosionObject = explosion;
    }

    public void SetMovementAngle(float angle){
        if(_rb == null) _rb = GetComponent<Rigidbody2D>();
        _direction = Quaternion.Euler(0,0,angle) * Vector3.one;
        _rb.velocity = _direction.normalized * _speed;
    }

    public void SetSpeed(float speed){
        if(_rb == null) _rb = GetComponent<Rigidbody2D>();
        _speed = speed;
        _rb.velocity = _direction.normalized * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Equals("screenEdge")){
            Die();
        }
    }


    private float _currentHealth;

    private void SetHealth(float health){
        _currentHealth = health;
    }

    public void TakeDamage(float damage){
        _currentHealth -= damage;
        if(_currentHealth <= 0 ) Die();
    }

    private void Die(){
        EffectsController.Instance.CreateEnemyExplosion(transform.position, 1f);
        Destroy(this.gameObject);
    }
}
