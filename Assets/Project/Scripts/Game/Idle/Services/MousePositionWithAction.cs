using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.Game.Idle.Services{
    public class MousePositionWithAction : MonoBehaviour{
        private InputSystem_Actions _actions;
        private Vector2 _mousePosition;
        private Camera _mainCamera;
        private Vector2 _mouseScreenPosition;
        private Vector3 _mouseWorldPosition;

        private void Awake(){
            _actions = new InputSystem_Actions();
            _actions.Player.Enable();
            _mainCamera = Camera.main;
        }

        //public void OnMousePosition(InputAction.CallbackContext context)
       // {
        //    _mousePosition = context.ReadValue<Vector2>();
        //    Debug.Log("Action Mouse Position: " + _mousePosition);
       // }

       private void Update(){
           if (Mouse.current != null)
           {
               _mouseScreenPosition = _actions.Player.MousePosition.ReadValue<Vector2>();

               Vector3 screenPosWithDepth = new Vector3(_mouseScreenPosition.x, _mouseScreenPosition.y, Mathf.Abs(_mainCamera.transform.position.z));
               _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(screenPosWithDepth);
            
               //Debug.Log("Action Mouse Position: " + _mouseWorldPosition);
           }
       }

       private void OnDisable()
       {
           _actions.Player.Disable();
       }
    }
}