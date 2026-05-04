using UnityEngine;
using UnityEditor;

public class Dealer : MonoBehaviour
{
    public Deck deck;


    // [SerializeField] public Player[] players;
    // nuh: we use the Player[] players in RoundManager instead.
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialCardDeal(Player player)
    {
        Debug.Log($"Initial Card Deal for player {player.name}");
        if (player.hand_1.cards[0] != null) { Debug.LogWarning("Confused Screaming: cards were dealt before the beginning of time."); return; }
        player.hand_1.cards[0] = deck.DrawCard();
        player.hand_1.cards[1] = deck.DrawCard();
        player.hand_2.cards[0] = deck.DrawCard();
        player.hand_2.cards[1] = deck.DrawCard();
        player.hand_3.cards[0] = deck.DrawCard();
        player.hand_3.cards[1] = deck.DrawCard();
    }

    public Card[,] NetworkedInitialCardDeal()
    {
        Card[,] deal = new Card[2,1];
        deal[0, 0] = deck.DrawCard();
        deal[0, 1] = deck.DrawCard();
        deal[1, 0] = deck.DrawCard();
        deal[1, 1] = deck.DrawCard();
        deal[2, 0] = deck.DrawCard();
        deal[2, 1] = deck.DrawCard();
        return deal;
    }
}