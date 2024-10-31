using UnityEngine;

public class ActivateEvent : MonoBehaviour
{
    // El objeto que queremos activar
    public GameObject objectToActivate;

    // Etiqueta del jugador para identificarlo
    public string playerTag = "Player";

    private void Start()
    {
        // Asegurarse de que el objeto esté inactivo al inicio
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se ha asignado ningún objeto para activar.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que ha colisionado tiene la etiqueta del jugador
        if (other.CompareTag(playerTag))
        {
            // Activa el objeto especificado
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log("Objeto activado por la interacción del jugador.");
            }
        }
    }
}
