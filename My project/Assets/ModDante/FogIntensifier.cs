using UnityEngine;
using System.Collections;

public class FogIntensityTrigger : MonoBehaviour
{
    public float intensifiedFogDensity = 0.05f; // Densidade da névoa intensificada
    public GameObject[] objectsToActivate; // Array de GameObjects a serem ativados

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCharacter") && !triggered) // Verifica se o objeto que colidiu é o jogador e se o trigger não foi acionado ainda
        {
            triggered = true;
            StartCoroutine(IntensifyFogAndActivateObjects());
        }
    }

    private IEnumerator IntensifyFogAndActivateObjects()
    {
        RenderSettings.fogDensity = intensifiedFogDensity; // Define a nova densidade da névoa

        // Ativa os GameObjects
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        // Espera 30 segundos
        yield return new WaitForSeconds(30f);

        // Volta a névoa para a densidade padrão
        RenderSettings.fogDensity = 0.01f; // Ajuste para a densidade padrão que você deseja

        // Desativa os GameObjects
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }

        triggered = false; // Reinicia o trigger para poder ser acionado novamente
    }
}


