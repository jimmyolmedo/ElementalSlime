using UnityEngine;

public class ChangeElement : MonoBehaviour
{
    [SerializeField] elements elementChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out SlimeController player))
        {
            player.SwitchElement(elementChange);
        }
    }
}
