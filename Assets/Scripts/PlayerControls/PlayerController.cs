using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 2.0f;

    private PlayerInput playerInput;

    private void Awake() {
        playerInput = new PlayerInput();
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 moveInput = playerInput.PlayerAction.Move.ReadValue<Vector2>();
        transform.Translate(moveInput * _playerSpeed * Time.fixedDeltaTime);
    }
}
