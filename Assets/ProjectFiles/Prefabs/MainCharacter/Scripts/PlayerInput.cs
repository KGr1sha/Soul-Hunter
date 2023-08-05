using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IMovable movableScript;
    private Vector2 inputVector;

    private void Start()
    {
        movableScript = GetComponent<IMovable>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        inputVector = new Vector2(xInput, yInput).normalized;

        if (movableScript != null && Input.GetKeyDown(KeyCode.Space))
            movableScript.Jump();
    }

    private void FixedUpdate()
    {
        if (movableScript != null)
        {
            if (inputVector != Vector2.zero)
                movableScript.Move(inputVector);
        }
    }
}
