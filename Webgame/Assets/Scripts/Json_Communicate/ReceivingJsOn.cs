using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReceivingJsOn : MonoBehaviour
{
    private const string serverEndpoint =   "http://your-server-url/api/getGameData";
    public Text                             text;
    public string                           recievedData;



    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(GetGameData());
    }

    IEnumerator GetGameData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(serverEndpoint))
        {
            // 요청 보내기
            yield return www.SendWebRequest();

            // 응답 처리
            if (www.result == UnityWebRequest.Result.Success)
            {
                // JSON 응답 파싱
                string jsonData = www.downloadHandler.text;
                RecievedGameData gameData = JsonUtility.FromJson<RecievedGameData>(jsonData);

                // 게임에서 사용
                recievedData = $"Received GameData - first: {gameData.first} \n second: {gameData.second} \n third: {gameData.third}";
                text.text = recievedData;
            }
            else
            {
                recievedData = "Error getting GameData: " + www.error;
                text.text = recievedData;
            }
        }
    }
}

[System.Serializable]
public class RecievedGameData
{
    public RecievedPartyMem first;
    public RecievedPartyMem second;
    public RecievedPartyMem third;

    public string partyName;
}

[System.Serializable]
public class RecievedPartyMem
{
    public CharacterType charaType;
    public int hp, atk, def, agl;
}