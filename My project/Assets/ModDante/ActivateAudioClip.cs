using UnityEngine;

public class ActivateAudioClip: MonoBehaviour
{
    // Referência ao AudioSource
    private AudioSource audioSource;

    // Tempo de ativação em segundos
    public float activationTime = 45f;
    private float timer;

    void Start()
    {
        // Obtém o componente AudioSource do GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Inicialmente, desativa o AudioSource
        audioSource.enabled = false;

        // Inicializa o timer
        timer = 0f;
    }

    void Update()
    {
        // Incrementa o timer com o tempo passado desde o último frame
        timer += Time.deltaTime;

        // Verifica se o tempo de ativação foi alcançado
        if (timer >= activationTime)
        {
            // Ativa o AudioSource
            audioSource.enabled = true;

            // Opcional: Toca o áudio imediatamente após ativar o AudioSource
            audioSource.Play();

            // Opcional: Desativa este script para evitar reativação
            this.enabled = false;
        }
    }
}


