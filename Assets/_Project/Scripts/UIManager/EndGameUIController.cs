using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGameUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UIDocument>().rootVisualElement.Q<Button>("ReturnToMainMenuButton").clicked += ReturnToMainMenuButton_clicked;
    }

    private void ReturnToMainMenuButton_clicked()
    {
        // Load back to main scene
        SceneManager.LoadScene(1);
    }
}
