using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    private void Start()
    {
        instance = this;
        jeuCopie = Instantiate(jeuOriginal);
        jeuOriginal.SetActive(false);
        recommencerAction.Enable();
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

    public void Victoire()
    {
        jeuActif = false;
        uiVictoire.SetActive(true);
    }
    public void Defaite()
    {
        jeuActif = false;
        uiDefaite.SetActive(true);
    }

    public void Redemarrer()
    {
        Destroy(jeuCopie);
        jeuCopie = Instantiate(jeuOriginal);
        jeuCopie.SetActive(true);
        uiDefaite.SetActive(false);
        uiVictoire.SetActive(false);
        jeuActif = true;

        timer = 0f;
        points = 0f;
        endDelay = 0f;
    }
}
