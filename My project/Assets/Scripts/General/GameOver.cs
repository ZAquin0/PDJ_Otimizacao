using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   [SerializeField] private Animator transition;
   [SerializeField] private float animationTime;
   [SerializeField] private RectTransform gameOverAnimationRect;
   [SerializeField] private RectTransform gameOverHUD;
    public IEnumerator ActivateGameOver(GameObject disable)
    {
        gameOverAnimationRect.gameObject.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(animationTime);
        Cursor.lockState = CursorLockMode.None;
        disable.SetActive(false);
        gameOverHUD.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
