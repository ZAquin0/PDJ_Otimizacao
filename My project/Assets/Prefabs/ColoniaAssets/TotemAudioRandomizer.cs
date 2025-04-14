using System.Collections;
using UnityEngine;

public class TotemAudioRandomizer : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlayRandomAudioWithDelay());
    }

    IEnumerator PlayRandomAudioWithDelay()
    {
        while (true)
        {
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

            if (!audioSource.isPlaying)
            {
                audioSource.clip = randomClip;

                audioSource.Play();

                yield return new WaitForSeconds(30f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }
}


