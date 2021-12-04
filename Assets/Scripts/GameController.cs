using Discord;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public DiscordController discord;
    public long time = 0;
    public GameObject status;

    void Start()
    {
        var activity = new Activity { };
        activity.Details = $"Time: {DateTime.Now.ToString("HH:mm")}";
        if (status.GetComponent<Text>().text == "Status: AFK" || status.GetComponent<Text>().text == "Status: Sleeping")
        {
            activity.State = status.GetComponent<Text>().text;
        }
        discord.UpdateActivity(activity);
    }

    void Update()
    {
        if (time == 0) time = DateTimeOffset.Now.ToUnixTimeSeconds() + 60;
        if (DateTimeOffset.Now.ToUnixTimeSeconds() >= time)
        {
            time = time + 60;
            var activity = new Activity { };
            activity.Details = $"Time: {DateTime.Now.ToString("HH:mm")}";
            if (status.GetComponent<Text>().text == "Status: AFK" || status.GetComponent<Text>().text == "Status: Sleeping")
            {
                activity.State = status.GetComponent<Text>().text;
            }
            discord.UpdateActivity(activity);
        }
    }

    private void OnApplicationQuit()
    {
        discord.Dispose();
    }

    public void ChangeStatus()
    {
        int currentStatus = 0;
        switch (status.GetComponent<Text>().text)
        {
            case "Status: Normal":
                currentStatus = 1;
                break;
            case "Status: AFK":
                currentStatus = 2;
                break;
            case "Status: Sleeping":
                currentStatus = 3;
                break;
        }
        if (currentStatus == 1) status.GetComponent<Text>().text = "Status: AFK";
        if (currentStatus == 2) status.GetComponent<Text>().text = "Status: Sleeping";
        if (currentStatus == 3) status.GetComponent<Text>().text = "Status: Normal";
        var activity = new Activity { };
        activity.Details = $"Time: {DateTime.Now.ToString("HH:mm")}";
        if (status.GetComponent<Text>().text == "Status: AFK" || status.GetComponent<Text>().text == "Status: Sleeping")
        {
            activity.State = status.GetComponent<Text>().text;
        }
        discord.UpdateActivity(activity);
    }

    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
