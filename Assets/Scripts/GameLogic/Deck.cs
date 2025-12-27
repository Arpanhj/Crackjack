using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cards;

    public GameObject cardPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cards = new List<GameObject>();
        PopulateDeck();
        ShuffleDeck();
        for (int i = 0; i < cards.Count; i++)
        {
            Debug.Log(DrawCard().name);
        }
    }

    void PopulateDeck()
    {
        GameObject throwawayCardGameObject;
        Card throwawayCardCard;
        for (int iterSuits = 0; iterSuits < 4; iterSuits++)
        {
            for (int iterValues = 1; iterValues < 14; iterValues++)
            {
                Debug.Log($"{iterValues} of {iterSuits}");
                throwawayCardGameObject = Instantiate(cardPrefab, transform);
                throwawayCardCard = throwawayCardGameObject.GetComponent<Card>();
                throwawayCardCard.suite = (Card.SUITES)iterSuits;
                throwawayCardCard.value = (Card.VALUES)iterValues;
                throwawayCardGameObject.name = $"Card: {Enum.GetName(typeof(Card.VALUES), throwawayCardCard.value)} of {Enum.GetName(typeof(Card.SUITES), throwawayCardCard.suite)}";
                throwawayCardCard.ReloadTexture();
                cards.Add(throwawayCardGameObject);
            }
        }
    }

    void ShuffleDeck()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            GameObject temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
    public Card DrawCard()
    {
        Card drawnCard = cards.Last<GameObject>().GetComponent<Card>();
        cards.Remove(cards.Last<GameObject>());
        return drawnCard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
