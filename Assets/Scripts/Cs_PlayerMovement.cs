using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_PlayerMovement : MonoBehaviour {
    private Vector2 _newspeed;
    public float _speed;
    public float _acceleration;
    private Rigidbody2D _rb;
	// Use this for initialization
	void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame

	void FixedUpdate () {
        
            
        _newspeed = _rb.velocity;

        _newspeed.x = _newspeed.x + Input.GetAxis("Horizontal") * _acceleration * Time.deltaTime;

        if (_newspeed.x > _speed)
        {
            _newspeed.x = _speed;
        }
        else if (_newspeed.x < -_speed)
        {
            _newspeed.x = -_speed;
        }

        _rb.velocity = _newspeed;
    }
   
}
