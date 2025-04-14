using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] musicClips; // Array para armazenar as tr�s m�sicas
    public float delayBeforeStart = 0.5f; // Delay inicial antes de come�ar a tocar as m�sicas
    public float delayBetweenTracks = 2f; // Tempo entre cada m�sica

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(PlayMusicSequence());
    }

    IEnumerator PlayMusicSequence()
    {
        yield return new WaitForSeconds(delayBeforeStart); // Espera pelo delay inicial

        foreach (AudioClip clip in musicClips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(clip.length + delayBetweenTracks); // Espera at� o fim da m�sica mais o delay entre as faixas
        }
    }
}
