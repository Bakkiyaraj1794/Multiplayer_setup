using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    public User_data User_profile;

    public GameObject Loginpage, registerpage,UI_Panel;
    bool switch_page = true;

    [Header("Login Variable")]
    public InputField L_username;
    public InputField  L_password;
    public Text L_message;
    [Space(10)]
    [Header("Register Variable")]
    public InputField R_Name;
    public InputField R_Username;
    public InputField R_password;
    public InputField R_CheckPassword;
    public InputField R_email;
    public Text R_message;



    public void login()
    {
        if (User_profile.UserProfiles.Count > 0)
        {
            if (!string.IsNullOrEmpty(L_username.text) && !string.IsNullOrEmpty(L_username.text))
            {
                bool isUsernameExist = false;
                foreach (var item in User_profile.UserProfiles)
                {
                    if (item.Username == L_username.text)
                    {
                        isUsernameExist = true;
                        if (item.password == L_password.text)
                        {
                            Debug.Log("login  successfully");
                            Loginpage.SetActive(false);
                            registerpage.SetActive(false);
                            UI_Panel.SetActive(false);
                            gameObject.GetComponent<Launcher>().ConnectNetwork();
                            gameObject.GetComponent<Launcher>().Playername = item.name;
                        }
                        else
                        {
                            L_message.text = "Incorrect password";
                        }
                    }
                }
                if (isUsernameExist == false)
                {
                    L_message.text = "User name not exist";
                }
            }
            else
            {
                L_message.text = "Dont leave Unsername/Password empty";
            }
        }
        else
        {
            L_message.text = "No user found please regiter";
        }
    }
    public void register()
    {
        if (!string.IsNullOrEmpty(R_Name.text) && !string.IsNullOrEmpty(R_Username.text) && !string.IsNullOrEmpty(R_password.text) && !string.IsNullOrEmpty(R_CheckPassword.text) && !string.IsNullOrEmpty(R_email.text))
        {
            User_data.Profile prof = new User_data.Profile();
            prof.name = R_Name.text;
            prof.Username = R_Username.text;
            prof.password = R_password.text;
            prof.emailID = R_email.text;

            User_profile.UserProfiles.Add(prof);
            Loginpage.SetActive(true);
            registerpage.SetActive(false);
            switch_page = true;

            R_Name.text = "";
            R_Username.text = "";
            R_password.text = "";
            R_email.text = "";
            R_CheckPassword.text = "";
        }
        else
        {
            R_message.text = "Please fill all the field";
        }
    }

    #region
    //small methods
    public void CheckUsername()
    {
        foreach (var item in User_profile.UserProfiles)
        {
            if (item.Username == R_Username.text)
            {
                R_message.text = "Username already exist";
            }

        }
    }
    public void checkPassword()
    {
        if (string.IsNullOrEmpty(R_password.text))
        {
            R_message.text = "Don't leave password field empty";
        }
        else 
        {
            if (R_password.text!=R_CheckPassword.text)
            {
                R_message.text = "Password not match";
                R_CheckPassword.text = "";
            }
        }
    }
    #endregion
    public void open_registerwindow()
    {
        if (switch_page)
        {
            Loginpage.SetActive(false);
            registerpage.SetActive(true);
            switch_page = false;
        }
        else
        {
            Loginpage.SetActive(true);
            registerpage.SetActive(false);
            switch_page = true;
        }
       
    }
}
