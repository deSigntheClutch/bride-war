using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Level2Timer : MonoBehaviour
{
    public float timer = 1.0f;
    public Text timerText;
    public Text coin_text;
    private int roundTime = 40;
    private int index;
    private Camera came;
    private float pos_y = 0;
    private float pos_x = 0;
    //private Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        //m_Renderer = GetComponent<Renderer>();
        pos_y = timerText.rectTransform.position.y;
        pos_x = timerText.rectTransform.position.x;
        came = Camera.main;
        index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
       // Debug.Log(index);
    }

    // Update is called once per frame
    void Update()
    {
 //Debug.Log(GameObject.Find("Player_Prefab").GetComponent<PlayerManager>().coins);
        if (GameObject.Find("Player_Prefab").GetComponent<CharacterMove>().isTouched == true)
        {
            Debug.Log("das");
            roundTime = -1;
            //m_Renderer.material.color = Color.gray
            //Time.timeScale = 0;

            //GameObject.Find("Player_Prefab").GetComponent<CharacterMove>().isTouched = false;
        }
        var lerpedColor = Color.Lerp(Color.grey, Color.blue, Time.time);
        var playerposition_x = GameObject.Find("Player_Prefab").transform.position.x;
        //came.backgroundColor = lerpedColor;
        if (roundTime >= 0) { 
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Debug.Log(Time.deltaTime);
                timer = 1.0f;
                roundTime--;
            }
            timerText.text = string.Format("{0}", roundTime);
        }
        // failed, either time goes out or gets hit by monster.
        if (roundTime < 0)
        {
            Time.timeScale = 0;
            //m_Renderer.material.color = Color.gray;
            timerText.text = "Failed";
            timerText.fontSize = 50;
            timerText.rectTransform.position = new Vector3(pos_x, pos_y - 250, 0);
        }
        // succeed
        if (playerposition_x >= 225)
        {
            Time.timeScale = 0;
            timerText.text = "You Win";
            timerText.fontSize = 50;
            timerText.color = Color.yellow;
            timerText.rectTransform.position = new Vector3(pos_x, pos_y - 250, 0);
        }
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            ReplayGame();
        }

    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        EditorSceneManager.LoadScene(6);
        timerText.rectTransform.position = new Vector3(pos_x, pos_y, 0);
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        GameObject.Find("Player_Prefab").GetComponent<CharacterMove>().isTouched = false;
        timer = 1.0f;
        roundTime = 40;                     
    }
}

// Update is called once per frame
