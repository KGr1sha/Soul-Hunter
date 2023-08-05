using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;

    [SerializeField] private TextMeshProUGUI speedText;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MeasureSpeed();
    }

    public void Move(Vector2 inputVector)
    {
        float xVel = inputVector.x;
        float zVel = inputVector.y;
        Vector3 moveDirection = new Vector3(xVel, 0, zVel);

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
}
