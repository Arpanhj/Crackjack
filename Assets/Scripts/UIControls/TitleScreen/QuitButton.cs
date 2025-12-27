using UnityEngine;

public class QuitButton : MonoBehaviour
{
    [SerializeField] private GameObject gameController;

    void OnPress()
    {
        gameController.SendMessage("QuitKeyPressed");
    }
}
