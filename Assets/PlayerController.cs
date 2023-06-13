using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum MovementMode
{
    RigidbodyAddForce,
    RigidbodyVelocity,
    RigidbodyMovePosition,
    TransformTranslate,
    TransformPosition,
    Vector2MoveToWards
}
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _target;
    [SerializeField] private MovementMode _movementMode;
    Rigidbody _rigidbody;
    Vector3 _velocity = Vector3.up;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        switch (_movementMode)
        {
            case MovementMode.RigidbodyAddForce:
                direction = (_target.position - transform.position).normalized;
                Vector3 force = direction * _speed;
                _rigidbody.AddForce(force);
                break;
            case MovementMode.RigidbodyVelocity:
                direction = (_target.position - transform.position).normalized;
                Vector3 velocity = direction * _speed;
                _rigidbody.velocity = velocity;
                break;
            case MovementMode.RigidbodyMovePosition:
                direction = (_target.position - transform.position).normalized;
                Vector3 movement = direction * _speed * Time.fixedDeltaTime;
                _rigidbody.MovePosition(transform.position + movement);
                break;
            case MovementMode.TransformTranslate:
                direction = (_target.position - transform.position).normalized;
                transform.Translate(direction * _speed * Time.deltaTime, Space.Self);
                break;
            case MovementMode.TransformPosition:
                direction = (_target.position - transform.position).normalized;
                transform.position = transform.position + direction * _speed * Time.deltaTime;
                // transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _velocity, _speed);
                transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
                break;
            case MovementMode.Vector2MoveToWards:
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
                break;
        }
    }
}
