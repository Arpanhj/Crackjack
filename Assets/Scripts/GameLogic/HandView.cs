using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour
{
    [Tooltip("Center point of the hand")]
    public Transform anchor;

    [Tooltip("Horizontal spacing between cards")]
    public float xSpacing = 0.8f;

    [Tooltip("Vertical spacing between cards")]
    public float ySpacing = 0f;

    [Tooltip("Depth offset per card (prevents z-fighting)")]
    public float zStep = 0.01f;

    /// <summary>
    /// Layouts the cards relative to the anchor with configurable x/y spacing.
    /// </summary>
    public void Layout(Card[] cards)
    {
        if (cards == null || cards.Length == 0)
            return;

        int count = cards.Length;
        float startX = -(count - 1) * xSpacing * 0.5f;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = anchor.position +
                          new Vector3(startX + i * xSpacing, i * ySpacing, -i * zStep);

            cards[i].transform.position = pos;
            cards[i].transform.rotation = anchor.rotation;
        }
    }
}
