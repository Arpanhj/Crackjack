using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject playGameScreen;

    [SerializeField] private GameObject singlePlayer;
    [SerializeField] private GameObject back;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button singlePlayerButton = singlePlayer.GetComponent<Button>();
        Button backButton = back.GetComponent<Button>();

        singlePlayerButton.onClick.AddListener(SinglePlayerButtonPressed);
        backButton.onClick.AddListener(BackButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePlayerButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void BackButtonPressed()
    {
        playGameScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

}
