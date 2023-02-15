using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public MovementSettings movementSettings;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveInDirection(Vector2 direction)
    {
        // _rb.velocity = direction.normalized * movementSettings.moveSpeed;
        _rb.velocity += direction.normalized * (movementSettings.accleration * Time.deltaTime);
        _rb.velocity = _rb.velocity.normalized * Mathf.Clamp(_rb.velocity.magnitude, 0, movementSettings.moveSpeed);

    }

    public void RotateTowards(Vector2 target)
    {
        RotateHelper.SmoothRotateTowards(_rb,target,transform.up,movementSettings.rotationSpeed);
    }
}