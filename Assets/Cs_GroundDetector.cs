using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_GroundDetector : MonoBehaviour
{
    private Cs_PlayerMovement _playerMov;

    // Start is called before the first frame update
    void Start()
    {
        _playerMov = gameObject.GetComponentInParent<Cs_PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerMov.SetGrounded(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerMov.SetGrounded(false);
    }
}
