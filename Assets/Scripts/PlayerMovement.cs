using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : CharacterMovement
{
    [SerializeField] private float _jumpForce;
    
    private Rigidbody2D _rigidbody;
    private bool isGrounded = false;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    protected override void Move()
    {
        isMoving = false;

        MoveRight();
        MoveLeft();
        Jump();
    }

    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_velocity * Time.deltaTime, 0, 0);
            isMoving = true;
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_velocity * Time.deltaTime * -1, 0, 0);
            isMoving = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && (_rigidbody.velocity.y == 0))
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}
