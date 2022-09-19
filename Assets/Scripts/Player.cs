using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private LayerMask _layerMask;

    private bool _wasJumpKeyPressed;
    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody _playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _wasJumpKeyPressed = true;            
        }
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    // Fixed update is called once every physic update
    private void FixedUpdate()
    {                
        if (IsPlayerOnGround() && _wasJumpKeyPressed)
        {
            _playerRigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            _wasJumpKeyPressed = false;
        }
        _playerRigidBody.velocity = new Vector3(_horizontalInput * 2, _playerRigidBody.velocity.y, _verticalInput * 2);
    }

    // Returns false if the player is in the air. It checks if the sphere projected by the GroundCheckTransform object is colliding with anything beside
    // the player mask (the _layerMask is set to Everything except the Player)
    bool IsPlayerOnGround()
    {
        return Physics.OverlapSphere(_groundCheckTransform.position, 0.1f, _layerMask).Length != 0;
    }
}
