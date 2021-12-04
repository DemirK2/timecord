using Discord;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public GameController game;
    public Discord.Discord discord;
    public bool connected;

    void Start()
    {
        discord = new Discord.Discord(916744715192377395, (ulong)CreateFlags.Default);
        connected = true;
    }

    void Update()
    {
        if (connected)
        {
            discord.RunCallbacks();
        }
    }

    public void UpdateActivity(Activity activity)
    {
        var activityManager = discord.GetActivityManager();
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Result.Ok)
            {
                Debug.Log("[Discord] Updated.");
            }
            else
            {
                Debug.LogWarning("[Discord] Couldn't update!");
            }
        });
    }

    public void Connect()
    {
        discord = new Discord.Discord(916744715192377395, (ulong)CreateFlags.Default);
        connected = true;
    }

    public void Dispose()
    {
        discord.Dispose();
        connected = false;
    }
}
