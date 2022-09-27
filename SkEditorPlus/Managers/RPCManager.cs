﻿using DiscordRPC;

namespace SkEditorPlus.Managers
{
    public class RPCManager
    {
        public static DiscordRpcClient client;

        public static void Initialize()
        {
            if (!Properties.Settings.Default.DiscordRPC) return;

            client = new DiscordRpcClient("926880446246187089");

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "Plik: brak",
                Timestamps = Timestamps.Now,
                Buttons = new Button[]
                {
                        new Button()
                        {
                            Label = "Pobierz SkEditor+",
                            Url = "https://skript.pl/temat/53624--"
                        }
                },
                Assets = new Assets()
                {
                    LargeImageKey = "large"
                }
            });
        }

        public static void Uninitialize()
        {
            if (!Properties.Settings.Default.DiscordRPC) return;
            client.Dispose();
        }

        public static void SetFile(string name)
        {
            if (!Properties.Settings.Default.DiscordRPC) return;
            client.UpdateDetails($"Plik: {name}");
        }
    }
}
