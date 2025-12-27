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

    public int CalculateHandValue()
    {
        int value = 0;
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null)
            {
                value += (int) cards[i].value;
            }
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
