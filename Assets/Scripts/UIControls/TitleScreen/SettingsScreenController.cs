using UnityEngine;
using UnityEngine.UI;

public class SettingsScreenController : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject settingsScreen;

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
        settingsScreen.SetActive(false);
        titleScreen.SetActive(true);
    }
}
