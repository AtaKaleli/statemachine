using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGrounded { get; set; }

    [SerializeField] private BoxCollider2D groundCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 positionOffset;
    [SerializeField] private Vector2 sizeOffset;

    [SerializeField] private Color groundedGizmoColor = Color.green;
    [SerializeField] private Color airGizmoColor = Color.red;

    private void Update()
    {
        IsGrounded = Physics2D.BoxCast(groundCollider.bounds.center, groundCollider.bounds.size + new Vector3(sizeOffset.x, sizeOffset.y), 0, Vector2.zero, 0, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (IsGrounded)
            Gizmos.color = groundedGizmoColor;
        else
            Gizmos.color = airGizmoColor;

        Gizmos.DrawCube(groundCollider.bounds.center + new Vector3(positionOffset.x,positionOffset.y), groundCollider.bounds.size + new Vector3(sizeOffset.x, sizeOffset.y));
    }


}
