using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_WallDetector : MonoBehaviour
{

    private Cs_PlayerMovement _playerMov;
    private bool _isRight;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerMov = gameObject.GetComponentInParent<Cs_PlayerMovement>();

        if (transform.position.x > _playerMov.gameObject.transform.position.x)
        {
            _isRight = true;
        }
        else _isRight = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRight)
        {
            _playerMov.SetIsOnWallR(true);
        }
        else _playerMov.SetIsOnWallL(true);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isRight)
        {
            _playerMov.SetIsOnWallR(false);
        }
        else _playerMov.SetIsOnWallL(false);
    }
}
