using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    private float _speed;
    private float _size;
    private Vector3 _direction;
    private bool _isActive;
    private GameObject explosionAnimation;


    void Start()
    {
    }

    public void SetupBullet(float angle, float speed, float size){
        
        _direction = transform.up;
        _speed = speed;
        _size = size;
        _rb = GetComponent<Rigidbody2D>();


        _rb.velocity = _direction * _speed;
        transform.localScale = new Vector3(size, size, 1f);
    }

    public void SetupStartResistant(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Equals("screenEdge")){
            Alive(false);
        }else if(other.gameObject.GetComponent<EnemyController>() != null){
            Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyController>().TakeDamage(10);
            EffectsController.Instance.CreateBulletExplosion(transform.position, 1f);
            Alive(false);
        }
    }

    public bool IsActive(){
        return _isActive;
    }

    public void Alive(bool active){
        if(!active){
            _rb.velocity = Vector3.zero;
            PShootingController.Instance.AddToInactive(this);
        }
        _isActive = active;
        gameObject.SetActive(active);
    }


    public void SetBulletExplosion(GameObject explosion){
        explosionAnimation = explosion;
    }
}
