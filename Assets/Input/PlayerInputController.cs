using UnityEngine;
using UnityEngine.InputSystem;

namespace NowakArtur97.IntergalacticRacing.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputController : MonoBehaviour
    {
        private PlayerInput _playerInput;

        public Vector2 MovementInput { get; private set; }

        private Vector2 _workspace;

        private void Awake() => _playerInput = GetComponent<PlayerInput>();

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            _workspace = context.ReadValue<Vector2>();
            _workspace.Set(Mathf.RoundToInt(_workspace.x), Mathf.RoundToInt(_workspace.y));
            MovementInput = _workspace;
        }
    }
}
