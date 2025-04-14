using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeMusica : MonoBehaviour
{
    public AudioClip minhaMusica; // A m�sica que voc� deseja reproduzir
    private AudioSource audioSource;

    public float intervaloDeReproducao = 300f; // Intervalo em segundos (5 minutos)

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ReproduzirMusicaPeriodicamente();
    }

    private void ReproduzirMusicaPeriodicamente()
    {
        InvokeRepeating("ReproduzirMusica", 0f, intervaloDeReproducao);
    }

    private void ReproduzirMusica()
    {
        if (minhaMusica != null)
        {
            audioSource.clip = minhaMusica;
            audioSource.Play();
        }
    }
}
