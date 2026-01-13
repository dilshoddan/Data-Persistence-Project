using TMPro;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField playerNameInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuManager.Instance.LoadUserData();
        bestScoreText.text = $"Best Score: {MenuManager.Instance.bestPlayerName} : {MenuManager.Instance.bestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        MenuManager.Instance.currentPlayerName = playerNameInput.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
