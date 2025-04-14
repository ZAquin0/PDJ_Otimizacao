using UnityEngine;
public class MainMenu : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private RectTransform settingsHUD;
    [SerializeField] private RectTransform creditsHUD;
    [SerializeField] private RectTransform quitHUD;
    [SerializeField] private RectTransform tutorialHUD;
    [Header("Scene Transition Settings")]
    [SerializeField] private Color transitionColor;
    [Header("Dependency")]
    [SerializeField] private LoadingScreen loadingScreen;
    private void Start() => Cursor.lockState = CursorLockMode.None;
    public void LoadSpace()
    {
        PlanetScene.ResetValues();
        StartCoroutine(loadingScreen.LoadLevel("Space", transitionColor));
    }
    public void Tutorial() => tutorialHUD.gameObject.SetActive(true);
    public void TutorialReturn() => tutorialHUD.gameObject.SetActive(false);
    public void Settings() => settingsHUD.gameObject.SetActive(true);
    public void SettingsReturn() => settingsHUD.gameObject.SetActive(false);
    public void Credits() => creditsHUD.gameObject.SetActive(true);
    public void CreditsReturn() => creditsHUD.gameObject.SetActive(false);
    public void Quit() => quitHUD.gameObject.SetActive(true);
    public void CancelQuitting() => quitHUD.gameObject.SetActive(false);
    public void ConfirmQuitting() => Application.Quit();
}
