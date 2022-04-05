using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBmanagerTeach {
    public static string usernameTeach;
    

    public static bool LoggedInTeach { get { return usernameTeach != null;}}

    public static void LogOut() {
        usernameTeach = null;
    }
}
