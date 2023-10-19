using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundEffect : MonoBehaviour
{
    private Material _material;
    private float currentScroll;
    [SerializeField] 
    private float scrollingSpeed;

    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        currentScroll += scrollingSpeed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(0, currentScroll);
    }
}
