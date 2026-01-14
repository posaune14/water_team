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

        var button = uiDocument.rootVisualElement.Q<Button>("exit");
        button.RegisterCallback<PointerEnterEvent>(e =>
        {
            audioSource.Play();
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
