public static class PlayerPrefs
{

    //Save the state of the item
    public static void SetItemState(string key, bool value)
    {
        UnityEngine.PlayerPrefs.SetInt(key, value ? 1 : 0);
        UnityEngine.PlayerPrefs.Save();
    }

    //Get the state of the item
    public static bool GetItemState(string key)
    {
        int value = UnityEngine.PlayerPrefs.GetInt(key);
        return value == 1 ? true : false;
    }

}
