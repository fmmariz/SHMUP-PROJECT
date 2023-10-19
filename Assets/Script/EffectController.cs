using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EffectController : MonoBehaviour
{
    private enum ParticleType{
        BULLET,
        ENEMY
    }

    [SerializeField]
    private ParticleType _pType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable(){
        switch(_pType){
            case ParticleType.BULLET:
                EffectsController.Instance.AddToInactiveBullet(this.gameObject);
            break;
            case ParticleType.ENEMY:
                EffectsController.Instance.AddToInactiveEnemy(this.gameObject);
            break;
        }
    }
}
