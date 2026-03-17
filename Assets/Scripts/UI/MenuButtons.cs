using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public UIDocument uiDocument;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        audioSource = GetComponent<AudioSource>();
        
        var button = uiDocument.rootVisualElement.Q<Button>("start"); // grab start button
        button.RegisterCallback<ClickEvent>(e => { SceneManager.LoadScene("LevelOne"); }); // load level 1 on click
        button.RegisterCallback<PointerEnterEvent>(e=>{audioSource.Play();}); // play sound on mouse hover
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
