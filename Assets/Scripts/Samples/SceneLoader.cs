using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField]
    private int nextScene;

    private void OnTriggerEnter(Collider player) {

        if (player.name == "Player") {

            SceneManager.LoadScene(nextScene);

        }

    }

}
