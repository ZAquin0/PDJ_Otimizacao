using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] musicClips; // Array para armazenar as três músicas
    public float delayBeforeStart = 0.5f; // Delay inicial antes de começar a tocar as músicas
    public float delayBetweenTracks = 2f; // Tempo entre cada música

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
            yield return new WaitForSeconds(clip.length + delayBetweenTracks); // Espera até o fim da música mais o delay entre as faixas
        }
    }
}
