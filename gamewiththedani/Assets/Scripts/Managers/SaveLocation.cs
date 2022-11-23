
using UnityEngine;



public class SaveLocation : MonoBehaviour
{
    private string X = "PositionX";
        private string Y = "PositionY";
        private string Z = "PositionZ";
    void Start()
    {
        

        transform.position = new Vector3(PlayerPrefs.GetFloat(X), PlayerPrefs.GetFloat(Y), PlayerPrefs.GetFloat(Z));


        
    }


    void Update()
    {
    
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat(X, transform.position.x);
        PlayerPrefs.SetFloat(Y, transform.position.y);
        PlayerPrefs.SetFloat(Z, transform.position.z);
    }
}
