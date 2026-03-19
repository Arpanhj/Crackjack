using System.IO;
using UnityEngine;

public class TexturePackManager : MonoBehaviour
{
    public static TexturePackManager Instance;

    public string activePack = "Default";

    private string basePath;

    void Awake()
    {
        Instance = this;

        basePath = Path.Combine(Application.streamingAssetsPath, "AssetPacks");

        Debug.Log("Texture pack base path: " + basePath);
    }

    public Texture2D LoadCardTexture(string textureName)
    {
        string path = Path.Combine(basePath, activePack, "cards", textureName + ".png");

        if (!File.Exists(path))
        {
            Debug.LogError("Texture not found: " + path);
            return null;
        }

        byte[] bytes = File.ReadAllBytes(path);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(bytes);

        return tex;
    }
}
