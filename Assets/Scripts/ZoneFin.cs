using UnityEngine;

public class ZoneFin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Skieur>().DeconnecterCamera();
        collision.gameObject.GetComponent<Skieur>().enabled = false;
        GameManager.instance.Victoire();
    }
}
