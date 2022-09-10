using Assets.Script.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI {
    public class RoomNameField : MonoBehaviour {
        // Start is called before the first frame update
        void Start() {
            GetComponent<InputField>().text = LocalStorer.GetRoomName();
        }

        // Update is called once per frame
        void Update() {
            // NOOP
        }
    }
}
