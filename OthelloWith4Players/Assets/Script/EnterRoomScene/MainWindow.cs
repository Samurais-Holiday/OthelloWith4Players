using Assets.Script.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script.EnterRoomScene {
    public class MainWindow : MonoBehaviour {
        /// <summary>ルーム名設定欄のオブジェクトのパス</summary>
        public static readonly string ROOM_NAME_FIELD_PATH = "/Canvas/RoomNameField";
        /// <summary>プレイヤー名設定欄のオブジェクトのパス</summary>
        private static readonly string PLAYER_NAME_FIELD_PATH = "/Canvas/PlayerNameField";
        /// <summary>参加ボタンのオブジェクトのパス</summary>
        private static readonly string ENTER_BUTTON_PATH = "/Canvas/EnterButton";

        /// <summary>ルーム名</summary>
        private InputField roomNameField;
        /// <summary>プレイヤー名</summary>
        private InputField playerNameField;
        /// <summary>参加ボタン</summary>
        private Button enterButton;

        // Start is called before the first frame update
        void Start() {
            if (!SetReferenceUIObject()) {
                Debug.LogError("Reference failed to child input GameObject.");
                SceneManager.LoadScene(0); // 0: TopScene
            }
        }

        private bool SetReferenceUIObject() {
            roomNameField = GameObject.Find(ROOM_NAME_FIELD_PATH).GetComponent<InputField>();
            playerNameField = GameObject.Find(PLAYER_NAME_FIELD_PATH).GetComponent<InputField>();
            enterButton = GameObject.Find(ENTER_BUTTON_PATH).GetComponent<Button>();
            return roomNameField && playerNameField && enterButton;
        }

        // Update is called once per frame
        void Update() {
            UpdateEnterButtonValidity();
        }

        /// <summary>参加ボタンのバリディティの更新</summary>
        private void UpdateEnterButtonValidity() {
            enterButton.enabled = (1 <= roomNameField.text.Length) && (1 <= playerNameField.text.Length);
        }

        /// <summary>参加ボタン押下時処理</summary>
        public void OnClickEnterButton() {
            StorePrevValue();
            // TODO: ルーム参加
        }

        /// <summary>入力値を前回値としてローカルに保存</summary>
        private void StorePrevValue() {
            LocalStorer.SetRoomName(roomNameField.text);
            LocalStorer.SetPlayerName(playerNameField.text);
        }
    }
}