using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform Player;

    public GameObject Cam;

    public Transform ExitPoint;

    public GameObject Congo;

    public GameObject[] Enemies;

    private void Awake() {
        
        if(instance == null)
        {
            instance = this;
        }
        else{
            Destroy(this);
        }

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<UIManager>().Quit();
        }
        if(!Player)
            return;
        if(ExitPoint.position.x > Player.position.x )
        {
            Congo.SetActive(true);
            AudioManager.instance.Play("Vict");
            foreach (GameObject E in Enemies)
            {
                Destroy(E);
            }
            Player.GetComponent<PlayerAttack>().enabled = false;
            Player.GetComponent<PlayerMove>().enabled = false;

        }
    }

    public void RestartLevel()
    {
        Cam.SetActive(true);
        Invoke("Restart",3f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
