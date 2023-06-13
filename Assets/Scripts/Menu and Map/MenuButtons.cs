using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public void GoToMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
