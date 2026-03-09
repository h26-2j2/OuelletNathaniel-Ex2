using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Skieur : MonoBehaviour
{
    public float vitesseDeplacementHorizontal = 1f;
    public float vitesseDeplacementVertical = 1f;
    public InputAction actionMovementHorizontal;
    public InputAction actionMovementVertical;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Un peu de magie noire avec l'inertie du joueur.
    void Update()
    {
        float vitesseHorizontale = actionMovementHorizontal.ReadValue<float>();
        float vitesseVerticale = actionMovementVertical.ReadValue<float>();
        rb.AddForceY(0f - (vitesseVerticale * vitesseDeplacementVertical * Time.deltaTime));
        transform.Translate(vitesseDeplacementHorizontal * vitesseHorizontale * Time.deltaTime * (((0f - rb.linearVelocityY) / 5f) + 1f), 0f, 0f, Space.Self);
    }

    private void OnEnable()
    {
        actionMovementHorizontal.Enable();
        actionMovementVertical.Enable();
    }

    private void OnDisable()
    {
        actionMovementHorizontal.Disable();
        actionMovementVertical.Disable();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    // Il faut appeller cette fonction dans la collision avec le yéti.
    public void DeconnecterCamera()
    {
        Camera.main.GetComponent<PositionConstraint>().enabled = false;
    }
}
