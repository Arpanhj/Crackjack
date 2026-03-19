using UnityEngine;

public class PlayerAIController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;

    [SerializeField] private float thinkDelay = 1.0f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < thinkDelay)
            return;

        timer = 0f;

        PlayHand(player.hand_1, 1);
        PlayHand(player.hand_2, 2);
        PlayHand(player.hand_3, 3);
    }

    void PlayHand(Hand hand, int index)
    {
        if (hand.state != HandState.Playing)
            return;

        int value = hand.CalculateHandValue();

        if (ShouldHit(value))
        {
            Card newCard = dealer.deck.DrawCard();
            player.HitHand(index, newCard);
        }
        else
        {
            player.StandHand(index);
        }
    }

    bool ShouldHit(int value)
    {
        if (value <= 11)
            return true;

        if (value >= 17)
            return false;

        return Random.value > 0.5f;
    }
}