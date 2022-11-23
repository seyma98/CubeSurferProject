using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class CubeDetector : MonoBehaviour
{
    public GameObject MainMenuButton;
    public GameObject NextLevelButton;


    public Text score;
    int PlayerCoin=0;

    AudioSource Voice;
    public AudioClip getCoin;

    public AudioClip success;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static CubeDetector Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    #endregion




    void Start()
    {
        Voice = GetComponent<AudioSource>();
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log($"Cube {collision.gameObject.name}");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();

            if (!cubeBehaviour.isStacked)
            {
                PlayerCubeManager.Instance.GetCube(cubeBehaviour);
            }
        }

    }
   
    private void OnTriggerEnter(Collider collision) {


        if (collision.gameObject.tag=="Coin") {
          
          //  Debug.Log("COIN TOPLANDI");
      Destroy(collision.gameObject);
        Voice.PlayOneShot(getCoin);
           PlayerCoin++;
     //       string flag = ToString(PlayerCoin);
            score.text = "score:"+PlayerCoin;
        }


        if (collision.gameObject.tag == "Finish")
        {
            PlayerBehaviour.Instance.StopPlayer();
            
            Voice.PlayOneShot(success);

            MainMenuButton.SetActive(true);
            NextLevelButton.SetActive(true);


    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
}


    }
  

}
