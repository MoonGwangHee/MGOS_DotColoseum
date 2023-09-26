using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPopUp : MonoBehaviour
{
    public CharacterType    type;
    public GameObject       DetailPopUp;
    public AudioSource      audioSource;

    private void OnMouseUpAsButton()
    {
        if (type == CharacterType.Archer)
        {
            if (DetailPopUp != null)
            {
                DetailPopUp.SetActive(true);
                audioSource.Play();
            }
        }
        else if (type == CharacterType.Knight)
        {
            if (DetailPopUp != null)
            {
                DetailPopUp.SetActive(true);
                audioSource.Play();
            }
        }
        else if (type == CharacterType.Rog)
        {
            if (DetailPopUp != null)
            {
                DetailPopUp.SetActive(true);
                audioSource.Play();
            }
        }    
        else if (type == CharacterType.Mage)
        {
            if (DetailPopUp != null)
            {
                DetailPopUp.SetActive(true);
                audioSource.Play();
            }
        }   
        else if (type == CharacterType.Mercenary)
        {
            if (DetailPopUp != null)
            {
                DetailPopUp.SetActive(true);
                audioSource.Play();
            }
        }

    }
}
