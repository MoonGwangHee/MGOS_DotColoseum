using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class ChangetoJson : MonoBehaviour
{
    private const string serverEndpoint = "http://localhost:8080/api/getAllGameData";

    CharacterStat   _first, _second, _third;
    GameObject      partyBox;
    string          _partyName;

    private void Start()
    {
        //세 파티원의 속성값 가져오기
        _first = CharaManager.instance.first.GetComponent<CharacterStat>();
        _second = CharaManager.instance.second.GetComponent<CharacterStat>();
        _third = CharaManager.instance.third.GetComponent<CharacterStat>();

        //게임오브젝트의 컴포넌트를 가져와서 그 컴포넌트 안의 파티 이름 가져오기
        partyBox = GameObject.Find("SavingPartyName");
        _partyName = partyBox.GetComponent<SavePartyName>().partyName;

            PartyType partyType = new PartyType()
            {
            first = new PartyMem
            {
                charaType = CharaManager.instance.PlayerParty[0],
                hp = _first.hp,
                atk = _first.atk,
                def = _first.def,
                agl = _first.agl
            },
            second = new PartyMem
            {
                charaType = CharaManager.instance.PlayerParty[1],
                hp = _second.hp,
                atk = _second.atk,
                def = _second.def,
                agl = _second.agl
            },
            third = new PartyMem
            {
                charaType = CharaManager.instance.PlayerParty[2],
                hp = _third.hp,
                atk = _third.atk,
                def = _third.def,
                agl = _third.agl
            },
            partyName = _partyName

            };

        string jsonData = JsonUtility.ToJson(partyType);
        //print(jsonData);
        StartCoroutine(SendingJson(jsonData));
    }
    IEnumerator SendingJson(string jsonData)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(serverEndpoint, "POST"))
        {
                byte[] jsonToSend =     new System.Text.UTF8Encoding().GetBytes(jsonData);
                www.uploadHandler =     (UploadHandler)new UploadHandlerRaw(jsonToSend);
                www.downloadHandler =   (DownloadHandler)new DownloadHandlerBuffer();

                www.SetRequestHeader("Content-Type", "application/json");

                // 요청 보내기
                yield return www.SendWebRequest();

                // 응답 처리
                if (www.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("GameData sent successfully");
                }
                else
                {
                    Debug.LogError("Error sending GameData: " + www.error);
                }
        }
    }
}

[System.Serializable]
public class PartyType
{
    public PartyMem first;
    public PartyMem second;
    public PartyMem third;

    public string partyName;
}

[System.Serializable]
public class PartyMem
{
    public CharacterType charaType;
    public int hp, atk, def, agl;
}