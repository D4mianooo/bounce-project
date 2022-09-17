using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField][Range(0f,5f)] private float _playerSpeed = 3f;
    [SerializeField]private float _jumpForce = 5f;
    [SerializeField]private float _gravityScale = 5f;
    
    
    private Vector3 _verticalRelativeInput;
    private Vector3 _horizontalRelativeInput;
    
    private float _playerHorizontalInput;
    private float _playerVerticalInput;
    
    private void Start(){
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    
    private void Update(){
        
        SetCursorVisibility();
        
        GetUserAxisInput();
        
        ProcessRelativeInput();
        
        _rigidbody.velocity = _verticalRelativeInput + _horizontalRelativeInput;
        
    }
    
    private void FixedUpdate() {
        
        ProcessGravity();
        ProcessJump();
        
    }
    private static void SetCursorVisibility(){
        if (Input.GetKey(KeyCode.Escape)){
            
            Cursor.visible = true;
            
        }
        if (Input.GetKey(KeyCode.Mouse0)){
            
            Cursor.visible = false;
            
        }
    }

    private void GetUserAxisInput(){
        
        _playerHorizontalInput = Input.GetAxis("Horizontal");
        _playerVerticalInput = Input.GetAxis("Vertical");
        
    }
    
    private void ProcessRelativeInput(){
        
        _verticalRelativeInput = transform.forward * _playerVerticalInput * _playerSpeed;
        _horizontalRelativeInput = transform.right * _playerHorizontalInput * _playerSpeed;
        
    }
    
    private void ProcessGravity(){
        
        Vector3 adjustedGravity = Physics.gravity * _gravityScale;
        _rigidbody.AddForce(adjustedGravity, ForceMode.Acceleration);    
        
    }
    
    private void ProcessJump(){
        
        if(Input.GetKey(KeyCode.Space) && IsGrounded()){
            
            float jumpForce = Mathf.Sqrt(_jumpForce * -2 * (Physics.gravity.y * _gravityScale));
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
        
    }
    
    private bool IsGrounded(){
        
        return Physics.Raycast(_collider.bounds.center, Vector3.down, _collider.bounds.extents.y + 0.01f);
        
    }
    

}
