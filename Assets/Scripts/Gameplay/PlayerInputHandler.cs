using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private TurnManager turnManager;

    private CrackjackInputActions inputActions;

    private void Awake()
    {
        inputActions = new CrackjackInputActions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();

        inputActions.Gameplay.HitHand1.performed += ctx => HitHand(1);
        inputActions.Gameplay.StandHand1.performed += ctx => StandHand(1);

        inputActions.Gameplay.HitHand2.performed += ctx => HitHand(2);
        inputActions.Gameplay.StandHand2.performed += ctx => StandHand(2);

        inputActions.Gameplay.HitHand3.performed += ctx => HitHand(3);
        inputActions.Gameplay.StandHand3.performed += ctx => StandHand(3);  // C key
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    private void HitHand(int handIndex)
    {
        if (turnManager.CurrentPlayer != player)
            return;
        Card newCard = DrawCardForPlayer();
        player.HitHand(handIndex, newCard);
    }

    private void StandHand(int handIndex)
    {
        if (turnManager.CurrentPlayer != player)
            return;
        player.StandHand(handIndex);
    }

    private Card DrawCardForPlayer()
    {
        Dealer dealer = GameObject.Find("GameController/Dealer").GetComponent<Dealer>();
        return dealer.deck.DrawCard();
    }
}
