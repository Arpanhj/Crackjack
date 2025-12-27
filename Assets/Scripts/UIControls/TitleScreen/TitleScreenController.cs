using System.Runtime.CompilerServices;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject playGameScreen;
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject settingsScreen;

    // Button GameObjects
    [SerializeField] private GameObject playGame;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject quit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        playGameScreen.SetActive(false);
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        Button PlayGameButton = playGame.GetComponent<Button>();
        Button SettingsButton = settings.GetComponent<Button>();
        Button CreditsButton = credits.GetComponent<Button>();
        Button ExitButton = quit.GetComponent<Button>();

        PlayGameButton.onClick.AddListener(PlayGameButtonPressed);
        CreditsButton.onClick.AddListener(CreditsButtonPressed);
        SettingsButton.onClick.AddListener(SettingsButtonPressed);
        ExitButton.onClick.AddListener(QuitButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameButtonPressed()
    {
        // Loads PlayGameMenu
        Debug.Log("Moving to PlayGame menu.");
        titleScreen.SetActive(false);
        playGameScreen.SetActive(true);
    }
    public void CreditsButtonPressed()
    {
        // Loads Credits
        Debug.Log("Moving to Credits menu.");
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }
    public void SettingsButtonPressed()
    {
        // Loads settings
        Debug.Log("Moving to Settings menu.");
        titleScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void QuitButtonPressed()
    {
        Debug.Log("Quitting, quit key pressed.");
        Application.Quit(0);
        EditorApplication.isPlaying = false;
    }
}
