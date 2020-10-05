using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ATG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Main Scene");
    }
}
