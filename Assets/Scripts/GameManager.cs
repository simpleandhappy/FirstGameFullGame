using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //UI
    public Image inventoryItemImage;
    public Sprite emptyInventory;
    public TMP_Text coinsText;
    public GameObject winText;
    public Image healthBar;
    public Vector2 healthBarOrigSize;

    //Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<GameManager>();
            return instance;
        }
    }

    private void Awake(){
        if (GameObject.Find("NewGameManager")){
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "NewGameManager";   
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Win"){
            Debug.Log(SceneManager.GetActiveScene().name);
            Destroy(NewPlayer.Instance.gameObject);
        }
    }
}