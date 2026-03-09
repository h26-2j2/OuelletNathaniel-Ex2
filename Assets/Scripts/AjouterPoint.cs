using UnityEngine;
using UnityEngine.Audio;

public class AjouterPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.points++;
            AudioSource audioSource = GetComponent<AudioSource>();
            GameManager.instance.JouerSon(audioSource.clip);
        }
    }
}
