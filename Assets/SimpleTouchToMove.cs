using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleTouchToMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _stopForce;
    private bool _isMoving = false;
    private float _gravity = Physics.gravity.magnitude;
    private Touch _touch; 
    private Vector2 _initPosition;
    private Vector2 _direction;
    private Vector3 _moveDirection;
    private CharacterController _characterController;
    private Animator _catAnimator;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _catAnimator = GetComponent<Animator>();
    }
   
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _isMoving = true;
            _touch = Input.GetTouch(0);
            //Debug.Log(_touch.position);
            if (_touch.phase == TouchPhase.Began)
            {
                _initPosition = _touch.position;
            }
            if (_touch.phase == TouchPhase.Moved)
            {
                _direction = _touch.deltaPosition;
            }
            
            if(_characterController.isGrounded)
            {
                _moveDirection = new Vector3(
                    _touch.position.x -_initPosition.x, 
                    0, 
                    _touch.position.y -_initPosition.y
                );
                Quaternion characterRotation = 
                    _moveDirection != Vector3.zero 
                    ? Quaternion.LookRotation(_moveDirection) 
                    : transform.rotation;

                transform.rotation =  characterRotation;
                _moveDirection = _moveDirection * _speed;
            }
            if (_touch.phase == TouchPhase.Ended && _characterController.isGrounded)
            {
                 _moveDirection.y += _jumpForce;

            }
        }
        else
        {
            _isMoving = false;
            _moveDirection = Vector3.Lerp(
                _moveDirection, Vector3.zero, _stopForce * Time.deltaTime );
        }

        _moveDirection.y =  _moveDirection.y - (_gravity * Time.deltaTime);
         _catAnimator.SetBool("IsWalking", _isMoving);
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
