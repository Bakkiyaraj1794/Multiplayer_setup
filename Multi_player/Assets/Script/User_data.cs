using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="UserProfile",menuName ="ScriptableObject/Createprofile",order =1)]
public class User_data : ScriptableObject
{
    public List<Profile> UserProfiles = new List<Profile>();

    [Serializable]
    public class Profile
    {
        public string Username;
        public string name;
        public string password;
        public string emailID;
    }
}
