using UnityEngine;

public enum HandState
{
    Playing,
    Stood,
    Bust
}

public class Hand : MonoBehaviour
{
    public Card[] cards;
    public HandState state = HandState.Playing;

    public SpriteRenderer cross;
    public SpriteRenderer standLock;

    private void Start()
    {
        cross = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Adds a card to the hand
    /// </summary>
    public void Hit(Card newCard)
    {
        if (state != HandState.Playing) return;
        if (newCard == null)
        {
            Debug.LogError("Attempted to hit with null card!");
            return;
        }

        int oldLength = cards.Length;
        System.Array.Resize(ref cards, oldLength + 1);
        cards[oldLength] = newCard;

        int value = CalculateHandValue();
        if (value > 21)
        {
            Bust();
        }
    }
    /// <summary>
    /// did you even bust, bro
    /// </summary>
    public void Bust()
    {
        state = HandState.Bust;

        cross.sortingOrder = 100; //that shit needs to go on top dawg

        cross.enabled = true;
        Debug.Log("Hand busted!");
    }

    /// <summary>
    /// Player stands on this hand
    /// </summary>
    public void Stand()
    {
        if (state != HandState.Playing) return;

        standLock.sortingOrder = 100;
        standLock.enabled = true;

        state = HandState.Stood;
        Debug.Log("Hand stood.");
    }

    /// <summary>
    /// Calculates the hand value
    /// </summary>
    public int CalculateHandValue()
    {
        int value = 0;
        int aceCount = 0;

        if (cards == null || cards.Length == 0) return 0;

        System.Array.Sort(cards, (a, b) => b.worth.CompareTo(a.worth));

        foreach (Card card in cards)
        {
            if (card.value == Card.VALUES.JOKER)
            {
                Debug.Log("Joker encountered in hand. Currently ignored.");
                continue;
            }

            if (card.value == Card.VALUES.ACE)
                aceCount++;
            else
                value += card.worth;
        }

        for (int i = 0; i < aceCount; i++)
            value += (value + 11 <= 21) ? 11 : 1;

        return value;
    }
}
