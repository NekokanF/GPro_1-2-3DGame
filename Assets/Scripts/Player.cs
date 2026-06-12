using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    PlayerInput playerInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        var move = playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(move);
        var cameraDir = playerInput.camera.transform.forward;

        cameraDir.y = 0;
        cameraDir = cameraDir.normalized;

        var cameraRight = playerInput.camera.transform.right;

        var moveVec = cameraDir * move.y * speed + cameraRight * move.x * speed;

        transform.position = transform.position + moveVec * Time.deltaTime;
    }
}
