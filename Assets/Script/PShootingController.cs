using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShootingController : MonoBehaviour
{

    public static PShootingController Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private int _bulletThreshold;
    [SerializeField]    
    private GameObject bulletExplosion;

    private List<BulletController> _bulletPool;
    private List<BulletController> _inactiveBullet;


    // Start is called before the first frame update
    void Start()
    {
        _bulletPool = new List<BulletController>();
        _inactiveBullet = new List<BulletController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 spawnPosition, float speed, float angle, float size){
        ShootBulletAtAngle(spawnPosition, angle, speed, size);
    }

    public void ShootBulletAtAngle(Vector3 spawnPosition, float angle, float bulletSpeed, float size){
        if(_bulletPool.Count < _bulletThreshold && _inactiveBullet.Count == 0){
            GameObject newBullet = Instantiate(_bulletPrefab,spawnPosition,Quaternion.Euler(0,0,angle),null);
            BulletController newBulletController = newBullet.GetComponent<BulletController>();
            newBulletController.SetupBullet(angle, bulletSpeed, size);
            newBulletController.SetBulletExplosion(bulletExplosion);
            _bulletPool.Add(newBulletController);
        }else{
            ReuseOldBullet(spawnPosition,angle,bulletSpeed,size);
        }
    }

    public void ReuseOldBullet(Vector3 spawnPosition, float angle, float bulletSpeed, float size){
        if(_inactiveBullet.Count > 0){
            BulletController oldBullet = _inactiveBullet[0];
            oldBullet.Alive(true);
            oldBullet.gameObject.transform.position = spawnPosition;
            oldBullet.gameObject.transform.rotation = Quaternion.Euler(0,0,angle);
            oldBullet.SetupBullet(angle, bulletSpeed, size);
            oldBullet.SetBulletExplosion(bulletExplosion);
            _inactiveBullet.RemoveAt(0);
        }else{
            Debug.LogError("Attempting to reuse bullet but there are no bullets to reuse, supposedly unreachable!");
        }
    }

    public void AddToInactive(BulletController bController){
        _inactiveBullet.Add(bController);
    }
}
