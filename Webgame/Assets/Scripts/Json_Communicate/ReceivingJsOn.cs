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
            // ��û ������
            yield return www.SendWebRequest();

            // ���� ó��
            if (www.result == UnityWebRequest.Result.Success)
            {
                // JSON ���� �Ľ�
                string jsonData = www.downloadHandler.text;
                RecievedGameData gameData = JsonUtility.FromJson<RecievedGameData>(jsonData);

                // ���ӿ��� ���
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