using UnityEngine;

public class Dealer : MonoBehaviour
{
    public Deck deck;

    [SerializeField] private Player[] players;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitialCardDeal(Player player)
    {
        player.hand_1.cards[0] = deck.DrawCard();
        player.hand_1.cards[1] = deck.DrawCard();
        player.hand_2.cards[0] = deck.DrawCard();
        player.hand_2.cards[1] = deck.DrawCard();
        player.hand_3.cards[0] = deck.DrawCard();
        player.hand_3.cards[1] = deck.DrawCard();
    }
}
