using UnityEngine;
using UnityEngine.SceneManagement;

namespace ColorSwitch.Player
{
   public class Player : MonoBehaviour
   {
      [SerializeField] private float jumpForce = 10f;
      [SerializeField] private Color colorCyan;
      [SerializeField] private Color colorYellow;
      [SerializeField] private Color colorMagenta;
      [SerializeField] private Color colorPink;

      private Colors.Color _color;
      private Rigidbody2D _rb;
      private SpriteRenderer _sr;

      private void Awake()
      {
         _rb = GetComponent<Rigidbody2D>();
         _sr = GetComponent<SpriteRenderer>();
      }

      private void Start()
      {
         SetRandomColor();
      }

      private void Update()
      {
         if (Input.GetButton("Jump") || Input.GetMouseButtonDown(0))
         {
            _rb.velocity = Vector2.up * jumpForce;
         }
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.CompareTag("ColorChanger"))
         {
            Destroy(other.gameObject);
            SetRandomColor();
            return;
         }
         
         if (!other.CompareTag(_color.ToString()))
         {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
      }

      void SetRandomColor()
      {
         int index = Random.Range(0, 4);

         while (_color == (Colors.Color) index)
         {
            index = Random.Range(0, 4);
         }

         _color = (Colors.Color) index;

         switch (_color)
         {
            case Colors.Color.Cyan:
               _sr.color = colorCyan;
               break;
            case Colors.Color.Yellow:
               _sr.color = colorYellow;
               break;
            case Colors.Color.Magenta:
               _sr.color = colorMagenta;
               break;
            case Colors.Color.Pink:
               _sr.color = colorPink;
               break;
         }
      }
   }
}
