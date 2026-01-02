using UnityEngine;

public class Test : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(gameObject.name + "Awake");
    }
    void OnEnable()
    {
        Debug.Log(gameObject.name + " On Enable");
    }
    void Start()
    {
        Debug.Log(gameObject.name + "Start");
    }

}
