using UnityEngine;
using Cinemachine;

public class SceneCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("NewPlayer")){
            vcam.Follow = NewPlayer.Instance.transform;
            vcam.LookAt = NewPlayer.Instance.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
