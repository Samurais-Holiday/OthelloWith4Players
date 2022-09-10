using Assets.Script.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script.CreateRoomScene {
    public class MainWindow : MonoBehaviour {

        /// <summary>���[�����ݒ藓�̃I�u�W�F�N�g�̃p�X</summary>
        public static readonly string ROOM_NAME_FIELD_PATH = "/Canvas/RoomNameField";
        /// <summary>�v���C���[���ݒ藓�̃I�u�W�F�N�g�̃p�X</summary>
        private static readonly string PLAYER_NAME_FIELD_PATH = "/Canvas/PlayerNameField";
        /// <summary>�ΐ탂�[�h�ݒ�p�h���b�v�_�E���̃I�u�W�F�N�g�̃p�X</summary>
        private static readonly string BATTLE_MODE_DROPDOWN_PATH = "/Canvas/BattleModeDropdown";
        /// <summary>�u�҂����v�ݒ�p�h���b�v�_�E���̃I�u�W�F�N�g�̃p�X</summary>
        private static readonly string WAIT_CHANCE_DROPDOWN_PATH = "/Canvas/WaitChanceDropdown";
        /// <summary>�쐬�{�^���̃I�u�W�F�N�g�̃p�X</summary>
        private static readonly string CREATE_BUTTON_PATH = "/Canvas/CreateButton";

        /// <summary>���[����</summary>
        private InputField roomNameField;
        /// <summary>�v���C���[��</summary>
        private InputField playerNameField;
        /// <summary>�ΐ탂�[�h</summary>
        private Dropdown battleModeDropdown;
        /// <summary>�҂���</summary>
        private Dropdown waitChanceDropdown;
        /// <summary>�쐬�{�^��</summary>
        private Button createButton;


        // Start is called before the first frame update
        void Start() {
            if (!SetReferenceUIObject()) {
                Debug.LogError("Reference failed to child input GameObject.");
                SceneManager.LoadScene(0); // 0: TopScene
            }
        }

        /// <summary>UI�I�u�W�F�N�g�̎Q�Ƃ�ݒ肷��</summary>
        /// <returns>true: �Q�Ɛ���, false: �Q�Ǝ��s</returns>
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

        /// <summary>�쐬�{�^���̃o���f�B�e�B�X�V</summary>
        private void UpdateCreateButtonValidity() {
            createButton.enabled = (1 <= roomNameField.text.Length) && (1 <= playerNameField.text.Length);
        }

        /// <summary>�쐬�{�^������������</summary>
        public void OnClickCreateButton() {
            StorePrevValue();
            // TODO: ���������
        }

        /// <summary>���͓��e��O��l�Ƃ��ă��[�J���ɕۑ�����</summary>
        private void StorePrevValue() {
            LocalStorer.SetRoomName(roomNameField.text);
            LocalStorer.SetPlayerName(playerNameField.text);
            LocalStorer.SetBattleMode(battleModeDropdown.value);
            LocalStorer.SetWaitChance(waitChanceDropdown.value);
        }
    }
}