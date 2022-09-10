using Assets.Script.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script.CreateRoomScene {
    public class MainWindow : MonoBehaviour {

        /// <summary>ルーム名設定欄のオブジェクトのパス</summary>
        public static readonly string ROOM_NAME_FIELD_PATH = "/Canvas/RoomNameField";
        /// <summary>プレイヤー名設定欄のオブジェクトのパス</summary>
        private static readonly string PLAYER_NAME_FIELD_PATH = "/Canvas/PlayerNameField";
        /// <summary>対戦モード設定用ドロップダウンのオブジェクトのパス</summary>
        private static readonly string BATTLE_MODE_DROPDOWN_PATH = "/Canvas/BattleModeDropdown";
        /// <summary>「待った」設定用ドロップダウンのオブジェクトのパス</summary>
        private static readonly string WAIT_CHANCE_DROPDOWN_PATH = "/Canvas/WaitChanceDropdown";
        /// <summary>作成ボタンのオブジェクトのパス</summary>
        private static readonly string CREATE_BUTTON_PATH = "/Canvas/CreateButton";

        /// <summary>ルーム名</summary>
        private InputField roomNameField;
        /// <summary>プレイヤー名</summary>
        private InputField playerNameField;
        /// <summary>対戦モード</summary>
        private Dropdown battleModeDropdown;
        /// <summary>待った</summary>
        private Dropdown waitChanceDropdown;
        /// <summary>作成ボタン</summary>
        private Button createButton;


        // Start is called before the first frame update
        void Start() {
            if (!SetReferenceUIObject()) {
                Debug.LogError("Reference failed to child input GameObject.");
                SceneManager.LoadScene(0); // 0: TopScene
            }
        }

        /// <summary>UIオブジェクトの参照を設定する</summary>
        /// <returns>true: 参照成功, false: 参照失敗</returns>
        private bool SetReferenceUIObject() {
            roomNameField = GameObject.Find(ROOM_NAME_FIELD_PATH).GetComponent<InputField>();
            playerNameField = GameObject.Find(PLAYER_NAME_FIELD_PATH).GetComponent<InputField>();
            battleModeDropdown = GameObject.Find(BATTLE_MODE_DROPDOWN_PATH).GetComponent<Dropdown>();
            waitChanceDropdown = GameObject.Find(WAIT_CHANCE_DROPDOWN_PATH).GetComponent<Dropdown>();
            createButton = GameObject.Find(CREATE_BUTTON_PATH).GetComponent<Button>();
            return roomNameField && playerNameField && battleModeDropdown && waitChanceDropdown && createButton;
        }

        // Update is called once per frame
        void Update() {
            UpdateCreateButtonValidity();
        }

        /// <summary>作成ボタンのバリディティ更新</summary>
        private void UpdateCreateButtonValidity() {
            createButton.enabled = (1 <= roomNameField.text.Length) && (1 <= playerNameField.text.Length);
        }

        /// <summary>作成ボタン押下時処理</summary>
        public void OnClickCreateButton() {
            StorePrevValue();
            // TODO: 部屋を作る
        }

        /// <summary>入力内容を前回値としてローカルに保存する</summary>
        private void StorePrevValue() {
            LocalStorer.SetRoomName(roomNameField.text);
            LocalStorer.SetPlayerName(playerNameField.text);
            LocalStorer.SetBattleMode(battleModeDropdown.value);
            LocalStorer.SetWaitChance(waitChanceDropdown.value);
        }
    }
}