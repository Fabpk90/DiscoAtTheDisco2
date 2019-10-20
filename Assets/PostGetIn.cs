using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGetIn : MonoBehaviour
{

    public AK.Wwise.Event getInSound;

    public void PostGetInSound()
    {
        getInSound.Post(gameObject);
    }
}
