using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Card[] cards;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Calculates the value of the hand by sorting the hand by value, and iterating through the cards from highest to lowest. 
    /// This causes aces, which have specific rules for their values, are handled at the end.
    /// </summary>
    /// <returns></returns>
    public int CalculateHandValue()
    {
        int value = 0;
        int aceCount = 0;

        if (cards == null || cards.Length == 0)
            return 0;

        // Sort so aces (worth = -1) are handled last
        System.Array.Sort(cards, (a, b) => b.worth.CompareTo(a.worth));

        foreach (Card card in cards)
        {
            if (card.value == Card.VALUES.JOKER)
            {
                Debug.Log("Joker encountered in hand. Currently ignored.");
                continue;
            }

            if (card.value == Card.VALUES.ACE)
            {
                aceCount++;
            }
            else
            {
                value += card.worth;
            }
        }

        // Resolve aces last
        for (int i = 0; i < aceCount; i++)
        {
            value += (value + 11 <= 21) ? 11 : 1;
        }

        return value;
    }
}

[CustomEditor(typeof(Hand))]
public class HandEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw normal inspector
        DrawDefaultInspector();

        Hand script = (Hand)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Calc hand vals and log them"))
        {
            Debug.Log(script.CalculateHandValue());
        }
    }
}
