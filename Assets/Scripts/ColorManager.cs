using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace ColorSwitch.Player
{
   public class ColorManager : MonoBehaviour
   {
      [SerializeField] private LayerMask whatIsColorCollision;
      [SerializeField] private Color colorCyan;
      [SerializeField] private Color colorYellow;
      [SerializeField] private Color colorMagenta;
      [SerializeField] private Color colorPink;

      [SerializeField] private UnityEvent onDifferentColorEnter;
      
      private Colors.Color _color;
      private SpriteRenderer _sr;

      private void Awake()
      {
         _sr = GetComponent<SpriteRenderer>();
      }

      private void Start()
      {
         SetRandomColor();
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.CompareTag("ColorChanger"))
         {
            Destroy(other.gameObject);
            SetRandomColor();
            return;
         }

         // Checks if object is in Color Collision layer
         if (whatIsColorCollision == (whatIsColorCollision | (1 << other.gameObject.layer)) && !other.CompareTag(_color.ToString()))
         {
            onDifferentColorEnter?.Invoke();
         }
      }

      private void SetRandomColor()
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
