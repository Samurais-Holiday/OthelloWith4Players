using Assets.Script.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script.EnterRoomScene {
    public class MainWindow : MonoBehaviour {
        /// <summary>���[�����ݒ藓�̃I�u�W�F�N�g�̃p�X</summary>
        public static readonly string ROOM_NAME_FIELD_PATH = "/Canvas/RoomNameField";
        /// <summary>�v���C���[���ݒ藓�̃I�u�W�F�N�g�̃p�X</summary>
        private static readonly string PLAYER_NAME_FIELD_PATH = "/Canvas/PlayerNameField";
        /// <summary>�Q���{�^���̃I�u�W�F�N�g�̃p�X</summary>
        private static readonly string ENTER_BUTTON_PATH = "/Canvas/EnterButton";

        /// <summary>���[����</summary>
        private InputField roomNameField;
        /// <summary>�v���C���[��</summary>
        private InputField playerNameField;
        /// <summary>�Q���{�^��</summary>
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

        /// <summary>�Q���{�^���̃o���f�B�e�B�̍X�V</summary>
        private void UpdateEnterButtonValidity() {
            enterButton.enabled = (1 <= roomNameField.text.Length) && (1 <= playerNameField.text.Length);
        }

        /// <summary>�Q���{�^������������</summary>
        public void OnClickEnterButton() {
            StorePrevValue();
            // TODO: ���[���Q��
        }

        /// <summary>���͒l��O��l�Ƃ��ă��[�J���ɕۑ�</summary>
        private void StorePrevValue() {
            LocalStorer.SetRoomName(roomNameField.text);
            LocalStorer.SetPlayerName(playerNameField.text);
        }
    }
}