using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ExitGameButton : MonoBehaviour
{
    private AudioSource audioSource;
    private UIDocument uiDocument;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        audioSource = GetComponent<AudioSource>();

        var button = uiDocument.rootVisualElement.Q<Button>("exit"); //grab exit button
        button.RegisterCallback<PointerEnterEvent>(e =>
        {
            audioSource.Play();
        }); // play sound effect on hover
        button.RegisterCallback<ClickEvent>(e=>{QuitGame();}); // quit game on exit button click
    }

    private void QuitGame()
    {
        Application.Quit(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
