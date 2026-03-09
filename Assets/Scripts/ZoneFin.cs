using UnityEngine;

public class ZoneFin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.Victoire();
    }
}
