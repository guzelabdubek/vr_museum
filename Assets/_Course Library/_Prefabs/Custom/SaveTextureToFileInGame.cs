using UnityEngine;
using UnityEngine.UI;

public class SaveTextureToFileInGame : MonoBehaviour
{
    public Texture texture;
    public string filePath = "Assets/texture.png";
    public Vector2Int size = new Vector2Int(-1, -1);
    public NewBehaviourScript.SaveTextureFileFormat format = NewBehaviourScript.SaveTextureFileFormat.PNG;
    public Button saveButton;

    private string uniqueFilePath;

    void Start()
    {
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(Save);
        }
    }

    private void Save()
    {
        uniqueFilePath = System.IO.Path.Combine(Application.dataPath, filePath);
        NewBehaviourScript.SaveTextureToFile(
            texture,
            uniqueFilePath,
            size.x,
            size.y,
            format,
            done: DebugResult);
    }

    private void DebugResult(bool success)
    {
        if (success)
        {
            Debug.Log($"Texture saved to [{uniqueFilePath}]");
        }
        else
        {
            Debug.LogError($"Failed to save texture.");
        }
    }
}
