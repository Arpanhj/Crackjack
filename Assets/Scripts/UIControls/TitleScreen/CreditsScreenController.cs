using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreditsScreenController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject creditsScreen;

    [SerializeField] private GameObject back;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button backButton = back.GetComponent<Button>();

        backButton.onClick.AddListener(BackButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButtonPressed()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }
}
