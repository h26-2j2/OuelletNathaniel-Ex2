using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Un peu compliqué mais pour résumer, c'est le coeur du jeu. On envoie des infos ici et on gère les trucs plus lourds.

    public static GameManager instance;
    public bool jeuActif = true;
    public float timer = 0f;
    public float points = 0f;
    public float endDelay = 0f;

    public InputAction recommencerAction;

    public GameObject jeuOriginal;
    public GameObject uiVictoire;
    public GameObject uiDefaite;
    GameObject jeuCopie;
    AudioSource musique;
    public AudioSource sonPoint;

    // On fait une copie du jeu "actif" (le joueur, la caméra, le yéti, les bonhommes) puis on fait jouer le joueur dans cette copie.
    private void Start()
    {
        instance = this;
        jeuCopie = Instantiate(jeuOriginal);
        jeuOriginal.SetActive(false);
        recommencerAction.Enable();
        musique = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (jeuActif)
        {
            timer += Time.deltaTime;
        }
        else
        {
            endDelay += Time.deltaTime;
        }

        if (recommencerAction.IsPressed() && endDelay >= 3f)
        {
            Redemarrer();
        }
    }

    // Bypass du fait que les bonhommes de neige soit désactivé après être touchés, donc il faut jouer le son de collecte ici.
    public void JouerSon(AudioClip clip)
    {
        sonPoint.PlayOneShot(clip);
    }

    public void Victoire()
    {
        jeuActif = false;
        uiVictoire.SetActive(true);
        musique.Stop();
    }
    public void Defaite()
    {
        jeuActif = false;
        uiDefaite.SetActive(true);
        musique.Stop();
    }

    // Pour redémarrer, on détruit la copie actuelle et on en fait une nouvelle. Tout est remis à zéro!
    public void Redemarrer()
    {
        Destroy(jeuCopie);
        jeuCopie = Instantiate(jeuOriginal);
        jeuCopie.SetActive(true);
        uiDefaite.SetActive(false);
        uiVictoire.SetActive(false);
        jeuActif = true;
        musique.Play();

        timer = 0f;
        points = 0f;
        endDelay = 0f;
    }
}
