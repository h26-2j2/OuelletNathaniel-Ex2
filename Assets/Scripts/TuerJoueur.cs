using UnityEngine;

public class TuerJoueur : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Skieur>().DeconnecterCamera();
            collision.gameObject.GetComponent<Skieur>().enabled = false;
            collision.rigidbody.bodyType = RigidbodyType2D.Static;
            GameManager.instance.Defaite();
        }
    }    
}
