using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private string nextScene = "SecondLevel";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject == NewPlayer.Instance.gameObject){
            SceneManager.LoadScene(nextScene);
            NewPlayer.Instance.transform.position = GameObject.Find("SpawnPoint").transform.position;
        }
    }
}
