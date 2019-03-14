using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_PlayerMovement : MonoBehaviour {

    private Vector2 _newspeed;
    public float _speed;
    public float _acceleration;
    public float _noInputDeceleration;
    public float _jumpSpeed;

    private Rigidbody2D _rb;
    private bool _isGrounded;

	// Use this for initialization
	void Start () {

        _rb = gameObject.GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame

	void FixedUpdate () {
        
        //El juego coge la velocity del rigidbody y la guarda en una variable local sobre la que calcularemos la nueva velocidad
        _newspeed = _rb.velocity;
        //No poner nada antes de esto


        PlayerMovement();

        CheckJump();

        //No poner nada despues de esto
        _rb.velocity = _newspeed;
    }
   

    void PlayerMovement()
    {
        _newspeed.x = _newspeed.x + Input.GetAxis("Horizontal") * _acceleration * Time.fixedDeltaTime;

        //Comprobamos la nueva velocidad supera la velocidad máxima de nuestro personaje. Si la supera, entonces la modificamos para que sea la velocidad máxima
        if (_newspeed.x > _speed)
        {
            _newspeed.x = _speed;
        }
        else if (_newspeed.x < -_speed)
        {
            _newspeed.x = -_speed;
        }

        //Aplicamos la nueva velocidad al propio rigidbody
        
        PlayerBreak();
    }

    void PlayerBreak()
    {
        if (Input.GetAxis("Horizontal") == 0) //Si va a la derecha
        {
            if (_newspeed.x > 0)
            {
                _newspeed.x = _newspeed.x - _noInputDeceleration * Time.fixedDeltaTime;
                if(_newspeed.x < 0) //No pasarse de frenada
                {
                    _newspeed.x = 0;
                }
            }
            else if (_newspeed.x < 0) //Si va a la izquierda
            {
                _newspeed.x = _newspeed.x + _noInputDeceleration * Time.fixedDeltaTime;
                if (_newspeed.x > 0)
                {
                    _newspeed.x = 0;
                }
            }
        }
    }

    void CheckJump()
    {
        Debug.Log(Input.GetAxis("Jump"));
        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log("Hello there");
            Jump();
        }
    }

    void Jump()
    {
        _newspeed.y = _newspeed.y + _jumpSpeed;
    }
}
