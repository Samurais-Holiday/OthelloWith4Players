using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.TopScene {
    public class MainWindow : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            // NOOP
        }

        // Update is called once per frame
        void Update() {
            // NOOP
        }

        /// <summary>���[���쐬�{�^������������</summary>
        public void OnClickCreateRoomButton() => SceneManager.LoadScene(1); // 1: CreateRoomScene
        /// <summary>���[���Q���{�^������������0</summary>
        public void OnClickEnterRoomButton() => SceneManager.LoadScene(3); // 3: EnterRoomScene
    }
}