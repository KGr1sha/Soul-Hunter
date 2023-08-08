using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MeasureSpeed();
        CalculateLookDirection();
    }

    public void Move(Vector2 inputVector)
    {
        float xVel = inputVector.x;
        float zVel = inputVector.y;
        Vector3 moveDirection = orientation.right * xVel + orientation.forward * zVel;

        rigidbody.AddForce(moveDirection * moveSpeed, ForceMode.Force);
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void MeasureSpeed()
    {
        speedText.text = rigidbody.velocity.magnitude.ToString();
    }

    private void CalculateLookDirection()
    {
        Vector3 lookDirection = this.transform.position - cameraTransform.position;
        lookDirection = new Vector3(lookDirection.x, 0f, lookDirection.z);
        orientation.forward = lookDirection.normalized;

        Debug.DrawRay(transform.position + Vector3.up * 2, orientation.forward, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * 2, orientation.right, Color.red);
    }
}
