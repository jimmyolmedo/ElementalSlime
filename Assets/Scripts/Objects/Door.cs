using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] elements element;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out SlimeController controller))
        {
            if(controller.CurrentElement == element)
            {
                ZoneManager.instance.switchZone();
            }
        }
    }
}
