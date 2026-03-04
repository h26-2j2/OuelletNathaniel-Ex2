using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float temps = 0f;
    public float points = 0f;

    public GameObject jeuOriginal;
    GameObject jeuCopie;

    private void Start()
    {
        instance = this;
        jeuCopie = Instantiate(jeuOriginal);
        jeuOriginal.SetActive(false);
    }

    public void Redemarrer()
    {
        Destroy(jeuCopie);
        jeuCopie = Instantiate(jeuOriginal);
        jeuCopie.SetActive(true);

        temps = 0f;
        points = 0f;
    }
}
