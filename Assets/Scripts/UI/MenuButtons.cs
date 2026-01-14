using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public UIDocument uiDocument;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        var button = uiDocument.rootVisualElement.Q<Button>("start");
        button.clicked += StartLevelOne;
    }

    private static void StartLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
