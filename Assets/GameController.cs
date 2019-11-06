using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int numEnemies;
    private bool endGame;
    private static GameObject princess;
    private static Texture princessSkin;
    public enum Scenes
	{
		Title = 0,
		LevelOne = 1,
        LevelTwo = 2,
        LevelThree = 3,
		GameVictory = 4,
		GameOver = 5
	}
    [HideInInspector]
	public static int currentLevel; // 1, 2 or 3 (transition scenes not included)

    // Start is called before the first frame update
    void Start()
    {
        princess = GameObject.FindWithTag("Player");
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        endGame = false;
        // This is called everytime a scene is loaded
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        if (activeScene >= 1 && activeScene <= 3) {
			currentLevel = activeScene;
		}
    }

    // Update is called once per frame
    void Update()
    {
        // Kill all enemies: WIN
        if ((currentLevel >= 1 && currentLevel <= 3) &&
            numEnemies == 0 &&
            !endGame)
        {
            endGame = true;
            // Load title for now, update to GameVictory scene later
            StartCoroutine(WaitForSceneTransition((int)Scenes.Title));
        }

        if (princess != null) {
            Renderer[] Component = princess.GetComponentsInChildren<Renderer>();
            if (Component[0].material.mainTexture != princessSkin) {
                Component[0].material.mainTexture = princessSkin;
            }

            // Princess died: GAME OVER
            if (princess.GetComponent<PRINCESS.Core.Health>().IsDead()) {
                endGame = true;
                // Load title for now, update to GameOver scene later
                StartCoroutine(WaitForSceneTransition((int)Scenes.Title));
            }
        }
    }

    public static void SavePrincessSkin(Texture texture)
    {
        princessSkin = texture;
    }

     IEnumerator WaitForSceneTransition(int scene)
	{
		yield return new WaitForSeconds(3);
		AsyncOperation asyncScene = SceneManager.LoadSceneAsync(scene);
		while (!asyncScene.isDone)
		{
			yield return null;
		}
	}
}
