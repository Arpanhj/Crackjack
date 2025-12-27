using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum SUITES
    {
        DIAMONDS,
        HEARTS,
        CLUBS,
        SPADES
    }
    public enum VALUES
    {
        JOKER,
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING
    }

    public SUITES suite;
    public VALUES value;
    [SerializeField] private Sprite cardSprite;
    [SerializeField] public Texture2D cardTexture; // this will be applied to the cardSprite of this GameObject

    [SerializeField, SerializeAs("Texture pack directory")] private string texturePackDir = "Assets/AssetPacks/Default/";
    [SerializeField] private string textureName;


    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ReloadTexture()
    {
        textureName = $"{value}_of_{suite}".ToLower();
        Debug.Log($"Texture name: {textureName}");
        cardTexture = (Texture2D)AssetDatabase.LoadAssetAtPath($"{texturePackDir}{textureName}.png", typeof(Texture2D));
        spriteRenderer.sprite = Sprite.Create(cardTexture, new Rect(0, 0, cardTexture.width, cardTexture.height), new Vector2(.5f, .5f), 100); ;
        Debug.Log("CardTexture reloaded!");
    }

    public void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
