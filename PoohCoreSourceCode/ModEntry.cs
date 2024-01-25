using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Buildings;
using StardewValley.Characters;
using StardewValley.GameData.Movies;
using StardewValley.Locations;
using StardewValley.Menus;
using StardewValley.Minigames;
using StardewValley.Monsters;
using StardewValley.Network;
using StardewValley.Objects;
using StardewValley.Projectiles;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;
using StardewValley.Util;
using xTile;
using xTile.Dimensions;
using System.Collections.Generic;
using Netcode;
using Microsoft.Xna.Framework.Graphics;
using HarmonyLib;
using System.Security.Cryptography.X509Certificates;
using ContentPatcher;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using StardewValley.Delegates;
// using SpaceCore;
// using SpaceCore.Events;
using StardewValley.TokenizableStrings;
using static System.Net.Mime.MediaTypeNames;
using StardewValley.Extensions;
using StardewValley.GameData.Characters;

namespace PoohCore
{
    public partial class ModEntry : Mod
    {
        static List<string> ListOfMailFlag = new List<string> { };
        // numbers.Add(1);

        public static IModHelper Mhelper;
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
            helper.Events.GameLoop.DayEnding += this.OnDayEnding;
            /*TokenParser.RegisterParser("GetRandomItemIDForGiftTaste", GetRandomItemIDForGiftTaste);
            TokenParser.RegisterParser("GetRelativeNameForGiftTaste", GetRelativeNameForGiftTaste);*/
        }
        public void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
            api.RegisterToken(this.ModManifest, "GetMailFlagProgressNumber", new GetMailFlagProgressNumberToken());
            api.RegisterToken(this.ModManifest, "GetRandomItemIDForGiftTaste", new GetGiftToken());
            api.RegisterToken(this.ModManifest, "GetRelativeNameForGiftTaste", new GetRelativeNameToken());
            api.RegisterToken(this.ModManifest, "GetRelativeDisplayNameForGiftTaste", new GetRelativeDisplayNameToken());
            api.RegisterToken(this.ModManifest, "GetItemNameForGiftTaste", new GetItemNameToken());
        }
        public void OnDayStarted(object sender, DayStartedEventArgs e)
        {
        }
        public void OnDayEnding(object sender, DayEndingEventArgs e)
        {
            foreach (var todayMailFlag in ListOfMailFlag)
            {
                if (Game1.player.mailReceived.Contains(todayMailFlag))
                {
                    Game1.player.mailReceived.Remove(todayMailFlag);
                    string todayMailFlagNumber = GetMailFlagProgressNumberFromMailFlag(todayMailFlag);
                    string seenFlag = todayMailFlag + todayMailFlagNumber;
                    string nextFlag = todayMailFlag + GetNextNumberFromString(todayMailFlagNumber);
                    Game1.player.mailReceived.Remove(seenFlag);
                    Game1.player.mailReceived.Add(nextFlag);
                }
            }
            ListOfMailFlag = new List<string> { };
        }
    }
}
