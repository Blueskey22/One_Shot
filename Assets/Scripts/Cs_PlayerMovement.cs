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
        
        //El juego coge la velocity del rigidbody y la guarda en una variable local sobre la que calcularemos la nueva velocidad
        _newspeed = _rb.velocity;

        //A la velocidad del rigidbody le añadiremos lo que acelera este "frame"
        _newspeed.x = _newspeed.x + Input.GetAxis("Horizontal") * _acceleration * Time.deltaTime;

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
        _rb.velocity = _newspeed;
    }
   
}
