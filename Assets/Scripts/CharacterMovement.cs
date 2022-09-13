using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class CharacterMovement : MonoBehaviour
{
    private const string IsMovingParameter = "IsMoving";

    [SerializeField] protected float _velocity;

    protected bool isMoving = false;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _prevoiosPositionX;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        SetAnimatorParameter();
        Flip();
        Move();
    }

    protected abstract void Move();

    private void SetAnimatorParameter()
    {
        _animator.SetBool(IsMovingParameter, isMoving);
    }

    private void Flip()
    {
        if (isMoving)
        {
            float currentPositionX = transform.position.x;
            _spriteRenderer.flipX = (_prevoiosPositionX - currentPositionX) > 0;
            _prevoiosPositionX = currentPositionX;
        }
    }
}
