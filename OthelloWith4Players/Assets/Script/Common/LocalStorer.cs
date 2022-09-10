using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Common {
    class LocalStorer {

        /// <summary>ルーム名タグ</summary>
        private static readonly string ROOM_NAME_TAG = "ROOM_NAME";
        /// <summary>プレイヤー名タグ</summary>
        private static readonly string PLAYER_NAME_TAG = "PLAYER_NAME";
        /// <summary>対戦モードタグ</summary>
        private static readonly string BATTLE_MODE_TAG = "BATTLE_MODE";
        /// <summary>待った可能回数のタグ</summary>
        private static readonly string WAIT_CHANCE_TAG = "WIAT_CHANCE";


        /// <summary>ルーム名保存</summary>
        /// <param name="name">ルーム名</param>
        public static void SetRoomName(string name) => PlayerPrefs.SetString(ROOM_NAME_TAG, name);
        /// <summary>ルーム名取得</summary>
        /// <returns>ルーム名</returns>
        public static string GetRoomName() => PlayerPrefs.GetString(ROOM_NAME_TAG, "");

        /// <summary>プレイヤー名保存</summary>
        /// <param name="name">プレイヤー名</param>
        public static void SetPlayerName(string name) => PlayerPrefs.SetString(PLAYER_NAME_TAG, name);
        /// <summary>プレイヤー名取得</summary>
        /// <returns>プレイヤー名</returns>
        public static string GetPlayerName() => PlayerPrefs.GetString(PLAYER_NAME_TAG, "");

        /// <summary>対戦モード保存</summary>
        /// <param name="value">対戦モード(Dropdown.value)</param>
        public static void SetBattleMode(int value) => PlayerPrefs.SetInt(BATTLE_MODE_TAG, value);
        /// <summary>対戦モード取得</summary>
        /// <returns>対戦モード(Dropdonw.value)</returns>
        public static int GetBattleMode() => PlayerPrefs.GetInt(BATTLE_MODE_TAG, 0);

        /// <summary>待った可能回数保存</summary>
        /// <param name="value">待った可能回数(Dropdown.value)</param>
        public static void SetWaitChance(int value) => PlayerPrefs.SetInt(WAIT_CHANCE_TAG, value);
        /// <summary>待った可能回数取得</summary>
        /// <returns>待った可能回数(Dropdown.value)</returns>
        public static int GetWaitChance() => PlayerPrefs.GetInt(WAIT_CHANCE_TAG, 0);
    }
}
