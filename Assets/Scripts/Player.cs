using UnityEngine;
using UnityEngine.EventSystems;

namespace ColorSwitch.Player
{
   public class Player : MonoBehaviour
   {
      [SerializeField] private float jumpForce = 10f;
      
      private Rigidbody2D _rb;
      private float _gravityScale;

      private void Awake()
      {
         _rb = GetComponent<Rigidbody2D>();
         _gravityScale = _rb.gravityScale;
         _rb.gravityScale = 0;
      }

      private void Update()
      {
         HandleInput();
      }

      public void HandleInput()
      {
         // Prevent jumping by pressing UI elements
         if ((Input.GetButton("Jump") || Input.GetMouseButtonDown(0)) && !EventSystem.current.IsPointerOverGameObject())
         {
            if (_rb.gravityScale == 0)
            {
               _rb.gravityScale = _gravityScale;
            }
            
            _rb.velocity = Vector2.up * jumpForce;
         } 
      }
   }
}
