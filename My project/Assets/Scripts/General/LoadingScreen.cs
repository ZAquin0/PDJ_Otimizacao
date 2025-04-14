using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreen : MonoBehaviour
{
   [Header("Scene Transition")]
   [SerializeField] private Animator transition;
   [SerializeField] private float animationTime;
   [SerializeField] private GameObject transitionImageReference;
   public IEnumerator LoadLevel(string levelName, Color color)
   {
      transitionImageReference.GetComponent<Image>().color = color;
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(animationTime);
      Time.timeScale = 1;
      SceneManager.LoadScene(levelName);
   }
}
