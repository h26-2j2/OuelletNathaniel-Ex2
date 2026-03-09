using UnityEngine;

public class TuerJoueur : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Skieur>().DeconnecterCamera();
            GameManager.instance.jeuActif = false;
            // GameManager.instance.Redemarrer();
        }
    }    
}
