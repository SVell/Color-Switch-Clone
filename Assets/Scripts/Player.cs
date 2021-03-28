using UnityEngine;

namespace ColorSwitch.Player
{
   public class Player : MonoBehaviour
   {
      [SerializeField] private float jumpForce = 10f;
      
      private Rigidbody2D _rb;

      private void Awake()
      {
         _rb = GetComponent<Rigidbody2D>();
      }

      private void Update()
      {
         if (Input.GetButton("Jump") || Input.GetMouseButtonDown(0))
         {
            _rb.velocity = Vector2.up * jumpForce;
         }
      }
   }
}
