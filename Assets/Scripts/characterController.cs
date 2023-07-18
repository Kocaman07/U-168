using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera; 
    
    
    
    
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        charPos = transform.position;
    }


    private void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0f);
    }


    void Update()
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y + (r2d.velocity.y * Time.deltaTime));
        transform.position = charPos;

        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }


    private void LateUpdate()
    {
       //_camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }
}
