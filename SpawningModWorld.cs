using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace RandomSpawns
{
	internal class SpawningModWorld : ModSystem
	{
		static Mod calamity;
		bool calamEnabled = ModLoader.TryGetMod("CalamityMod", out calamity);
		static Mod thorium;
		bool thoriumEnabled = ModLoader.TryGetMod("ThoriumMod", out thorium);

		// Dictionary<npcType, ValueTuple<shouldSpawn, ValueTuple<spawnTimer, playerIndex>>
		public static Dictionary<int, ValueTuple<bool, ValueTuple<int, int>>> spawnDict = new Dictionary<int, ValueTuple<bool, ValueTuple<int, int>>>();

		private bool spawnKingSlime;
		private bool spawnEater;
		private bool spawnBrain;
		private bool spawnBee;
		private bool spawnSkeletron;
		private bool spawnDeerclops;
		private bool spawnWall;
		private bool spawnQueenSlime;
		private bool spawnDukeFishron;
		private bool spawnPlantera;
		private bool spawnGolem;
		private bool spawnEmpress;
		private bool spawnCultist;
		private bool spawnMoonLord;
		private int spawnCounter;

		//Calamity
		private bool spawnDesertScourge;
		private bool spawnCrabulon;
		private bool spawnHiveMind;
		private bool spawnPerforators;
		private bool spawnSlimeGod;
		private bool spawnCryogen;
		private bool spawnAquaticScourge;
		private bool spawnBrimstoneElemental;
		private bool spawnCalamitas;
		private bool spawnLeviathan;
		private bool spawnAureus;
		private bool spawnPlaguebringer;
		private bool spawnRavager;
		private bool spawnDeus;
		private bool spawnProfanedGuardians;
		private bool spawnDragonfolly;
		private bool spawnProvidence;
		private bool spawnSignus;
		private bool spawnStormWeaver;
		private bool spawnCeaselessVoid;
		private bool spawnPolterghast;
		private bool spawnOldDuke;
		private bool spawnDOG;
		private bool spawnYharon;
		private bool spawnExoMechs;
		private bool spawnSCal;

		//Thorium
		private bool spawnThunderbird;
		private bool spawnQueenJelly;
		private bool spawnViscount;
		private bool spawnEnergyStorm;
		private bool spawnBuriedChamp;
		private bool spawnStarScout;
		private bool spawnBeholder;
		private bool spawnLich;
		private bool spawnForgottenOne;
		private bool spawnPrimordials;

		SpawnConfig spawnConfig = ModContent.GetInstance<SpawnConfig>();

		// Called when the world loads
		public override void OnWorldLoad()
		{
			spawnDict.Clear();
			AddSpawn(NPCID.KingSlime);
			AddSpawn(NPCID.EaterofWorldsHead);
			AddSpawn(NPCID.BrainofCthulhu);
			AddSpawn(NPCID.QueenBee);
			AddSpawn(NPCID.SkeletronHead);
			AddSpawn(NPCID.Deerclops);
			AddSpawn(NPCID.WallofFlesh);
			AddSpawn(NPCID.QueenSlimeBoss);
			AddSpawn(NPCID.DukeFishron);
			AddSpawn(NPCID.Plantera);
			AddSpawn(NPCID.Golem);
			AddSpawn(NPCID.HallowBoss);
			AddSpawn(NPCID.CultistBoss);
			AddSpawn(NPCID.MoonLordCore);

			//Calamity
			if(calamity != null)
            {
				AddSpawn(calamity.Find<ModNPC>("DesertScourgeHead").Type);
				AddSpawn(calamity.Find<ModNPC>("Crabulon").Type);
				AddSpawn(calamity.Find<ModNPC>("HiveMind").Type);
				AddSpawn(calamity.Find<ModNPC>("PerforatorHive").Type);
				AddSpawn(calamity.Find<ModNPC>("SlimeGodCore").Type);
				AddSpawn(calamity.Find<ModNPC>("Cryogen").Type);
				AddSpawn(calamity.Find<ModNPC>("AquaticScourgeHead").Type);
				AddSpawn(calamity.Find<ModNPC>("BrimstoneElemental").Type);
				AddSpawn(calamity.Find<ModNPC>("CalamitasClone").Type);
				AddSpawn(calamity.Find<ModNPC>("Anahita").Type);
				AddSpawn(calamity.Find<ModNPC>("AstrumAureus").Type);
				AddSpawn(calamity.Find<ModNPC>("PlaguebringerGoliath").Type);
				AddSpawn(calamity.Find<ModNPC>("RavagerBody").Type);
				AddSpawn(calamity.Find<ModNPC>("AstrumDeusHead").Type);
				AddSpawn(calamity.Find<ModNPC>("ProfanedGuardianCommander").Type);
				AddSpawn(calamity.Find<ModNPC>("Bumblefuck").Type);
				AddSpawn(calamity.Find<ModNPC>("Providence").Type);
				AddSpawn(calamity.Find<ModNPC>("Signus").Type);
				AddSpawn(calamity.Find<ModNPC>("StormWeaverHead").Type);
				AddSpawn(calamity.Find<ModNPC>("CeaselessVoid").Type);
				AddSpawn(calamity.Find<ModNPC>("Polterghast").Type);
				AddSpawn(calamity.Find<ModNPC>("OldDuke").Type);
				AddSpawn(calamity.Find<ModNPC>("DevourerofGodsHead").Type);
				AddSpawn(calamity.Find<ModNPC>("Yharon").Type);
				AddSpawn(calamity.Find<ModNPC>("Draedon").Type);
				AddSpawn(calamity.Find<ModNPC>("SupremeCalamitas").Type);
			}

			//Thorium
			if(thorium != null)
            {
				AddSpawn(thorium.Find<ModNPC>("TheGrandThunderBird").Type);
				AddSpawn(thorium.Find<ModNPC>("QueenJellyfish").Type);
				AddSpawn(thorium.Find<ModNPC>("Viscount").Type);
				AddSpawn(thorium.Find<ModNPC>("GraniteEnergyStorm").Type);
				AddSpawn(thorium.Find<ModNPC>("BuriedChampion").Type);
				AddSpawn(thorium.Find<ModNPC>("StarScouter").Type);
				AddSpawn(thorium.Find<ModNPC>("FallenBeholder").Type);
				AddSpawn(thorium.Find<ModNPC>("Lich").Type);
				AddSpawn(thorium.Find<ModNPC>("ForgottenOne").Type);
				AddSpawn(thorium.Find<ModNPC>("SlagFury").Type);
			}
		}

		// Called after players are updated each frame
        public override void PostUpdatePlayers()
		{
			spawnCounter++;
			spawnKingSlime = SpawnBosses(NPCID.KingSlime, spawnKingSlime);
			spawnEater = SpawnBosses(NPCID.EaterofWorldsHead, spawnEater);
			spawnBrain = SpawnBosses(NPCID.BrainofCthulhu, spawnBrain);
			spawnBee = SpawnBosses(NPCID.QueenBee, spawnBee);
			spawnSkeletron = SpawnBosses(NPCID.SkeletronHead, spawnSkeletron);
			spawnDeerclops = SpawnBosses(NPCID.Deerclops, spawnDeerclops);
			spawnWall = SpawnBosses(NPCID.WallofFlesh, spawnWall);
			spawnQueenSlime = SpawnBosses(NPCID.QueenSlimeBoss, spawnQueenSlime);
			spawnDukeFishron = SpawnBosses(NPCID.DukeFishron, spawnDukeFishron);
			spawnPlantera = SpawnBosses(NPCID.Plantera, spawnPlantera);
			spawnGolem = SpawnBosses(NPCID.Golem, spawnGolem);
			spawnEmpress = SpawnBosses(NPCID.HallowBoss, spawnEmpress);
			spawnCultist = SpawnBosses(NPCID.CultistBoss, spawnCultist);
			spawnMoonLord = SpawnBosses(NPCID.MoonLordCore, spawnMoonLord);

			if (calamity != null)
			{
				spawnDesertScourge = SpawnBosses(calamity.Find<ModNPC>("DesertScourgeHead").Type, spawnDesertScourge);
				spawnCrabulon = SpawnBosses(calamity.Find<ModNPC>("Crabulon").Type, spawnCrabulon);
				spawnHiveMind = SpawnBosses(calamity.Find<ModNPC>("HiveMind").Type, spawnHiveMind);
				spawnPerforators = SpawnBosses(calamity.Find<ModNPC>("PerforatorHive").Type, spawnPerforators);
				spawnSlimeGod = SpawnBosses(calamity.Find<ModNPC>("SlimeGodCore").Type, spawnSlimeGod);
				spawnCryogen = SpawnBosses(calamity.Find<ModNPC>("Cryogen").Type, spawnCryogen);
				spawnAquaticScourge = SpawnBosses(calamity.Find<ModNPC>("AquaticScourgeHead").Type, spawnAquaticScourge);
				spawnBrimstoneElemental = SpawnBosses(calamity.Find<ModNPC>("BrimstoneElemental").Type, spawnBrimstoneElemental);
				spawnCalamitas = SpawnBosses(calamity.Find<ModNPC>("CalamitasClone").Type, spawnCalamitas);
				spawnLeviathan = SpawnBosses(calamity.Find<ModNPC>("Anahita").Type, spawnLeviathan);
				spawnAureus = SpawnBosses(calamity.Find<ModNPC>("AstrumAureus").Type, spawnAureus);
				spawnPlaguebringer = SpawnBosses(calamity.Find<ModNPC>("PlaguebringerGoliath").Type, spawnPlaguebringer);
				spawnRavager = SpawnBosses(calamity.Find<ModNPC>("RavagerBody").Type, spawnRavager);
				spawnDeus = SpawnBosses(calamity.Find<ModNPC>("AstrumDeusHead").Type, spawnDeus);
				spawnProfanedGuardians = SpawnBosses(calamity.Find<ModNPC>("ProfanedGuardianCommander").Type, spawnProfanedGuardians);
				spawnDragonfolly = SpawnBosses(calamity.Find<ModNPC>("Bumblefuck").Type, spawnDragonfolly);
				spawnProvidence = SpawnBosses(calamity.Find<ModNPC>("Providence").Type, spawnProvidence);
				spawnSignus = SpawnBosses(calamity.Find<ModNPC>("Signus").Type, spawnSignus);
				spawnStormWeaver = SpawnBosses(calamity.Find<ModNPC>("StormWeaverHead").Type, spawnStormWeaver);
				spawnCeaselessVoid = SpawnBosses(calamity.Find<ModNPC>("CeaselessVoid").Type, spawnCeaselessVoid);
				spawnPolterghast = SpawnBosses(calamity.Find<ModNPC>("Polterghast").Type, spawnPolterghast);
				spawnOldDuke = SpawnBosses(calamity.Find<ModNPC>("OldDuke").Type, spawnOldDuke);
				spawnDOG = SpawnBosses(calamity.Find<ModNPC>("DevourerofGodsHead").Type, spawnDOG);
				spawnYharon = SpawnBosses(calamity.Find<ModNPC>("Yharon").Type, spawnYharon);
				spawnExoMechs = SpawnBosses(calamity.Find<ModNPC>("Draedon").Type, spawnExoMechs);
				spawnSCal = SpawnBosses(calamity.Find<ModNPC>("SupremeCalamitas").Type, spawnSCal);
			}

			if (thorium != null)
			{
				spawnThunderbird = SpawnBosses(thorium.Find<ModNPC>("TheGrandThunderBird").Type, spawnThunderbird);
				spawnQueenJelly = SpawnBosses(thorium.Find<ModNPC>("QueenJellyfish").Type, spawnQueenJelly);
				spawnViscount = SpawnBosses(thorium.Find<ModNPC>("Viscount").Type, spawnViscount);
				spawnEnergyStorm = SpawnBosses(thorium.Find<ModNPC>("GraniteEnergyStorm").Type, spawnEnergyStorm);
				spawnBuriedChamp = SpawnBosses(thorium.Find<ModNPC>("BuriedChampion").Type, spawnBuriedChamp);
				spawnStarScout = SpawnBosses(thorium.Find<ModNPC>("StarScouter").Type, spawnStarScout);
				spawnBeholder = SpawnBosses(thorium.Find<ModNPC>("FallenBeholder").Type, spawnBeholder);
				spawnLich = SpawnBosses(thorium.Find<ModNPC>("Lich").Type, spawnLich);
				spawnForgottenOne = SpawnBosses(thorium.Find<ModNPC>("ForgottenOne").Type, spawnForgottenOne);
				spawnPrimordials = SpawnBosses(thorium.Find<ModNPC>("SlagFury").Type, spawnPrimordials);
			}

			if (Main.time == 0.0 && Utils.NextBool(Main.rand, spawnConfig.spawnChance))
			{
				spawnEmpress = CheckSpawn(NPCID.HallowBoss, "Light is beginning to deform around you...", spawnEmpress);

				if (calamity != null)
				{
					spawnProvidence = CheckSpawn(calamity.Find<ModNPC>("Providence").Type, "A slumbering goddess becomes restless in search of a lost artifact...", spawnProvidence);
				}

				if (Main.dayTime)
				{
					spawnKingSlime = CheckSpawn(NPCID.KingSlime, "The faintest jiggling of slime can be heard in the distance...", spawnKingSlime);
					if (calamity != null)
					{
						spawnProfanedGuardians = CheckSpawn(calamity.Find<ModNPC>("ProfanedGuardianCommander").Type, "The guardians of a goddess awaken from their slumber...", spawnProfanedGuardians);
					}
				}
				else if (!Main.dayTime)
				{
					spawnSkeletron = CheckSpawn(NPCID.SkeletronHead, "You can hear the rattling of bones nearby...", spawnSkeletron);

					if (calamity != null)
					{
						spawnCalamitas = CheckSpawn(calamity.Find<ModNPC>("CalamitasClone").Type, "Tonight is going to be a horrific night...", spawnCalamitas);
						spawnAureus = CheckSpawn(calamity.Find<ModNPC>("AstrumAureus").Type, "The whir of an infected machine becomes loud...", spawnAureus);
						spawnDeus = CheckSpawn(calamity.Find<ModNPC>("AstrumDeusHead").Type, "The fragments of the god of the stars begin to reform...", spawnDeus);
					}

					if (thorium != null)
					{
						spawnLich = CheckSpawn(thorium.Find<ModNPC>("Lich").Type, "The scrape of skeletal hands on the ground becomes hard to ignore...", spawnLich);
						spawnPrimordials = CheckSpawn(thorium.Find<ModNPC>("SlagFury").Type, "Ancient beings begin to shake the very fabric of the world...", spawnPrimordials);
					}
				}
			}
			if (spawnCounter >= (spawnConfig.spawnCheckAmount * 60) && Utils.NextBool(Main.rand, spawnConfig.spawnChance))
			{
				spawnEater = CheckSpawn(NPCID.EaterofWorldsHead, "A powerful worm is growing hungry...", spawnEater);
				spawnBrain = CheckSpawn(NPCID.BrainofCthulhu, "Brain waves are radiating around you...", spawnBrain);
				spawnBee = CheckSpawn(NPCID.QueenBee, "A squelching sound can be heard from the hive...", spawnBee);
				spawnDeerclops = CheckSpawn(NPCID.Deerclops, "The snow and ice shake from a blood curdling roar nearby...", spawnDeerclops);
				spawnWall = CheckSpawn(NPCID.WallofFlesh, "A bloodthirsty roar can be heard close by...", spawnWall);
				spawnQueenSlime = CheckSpawn(NPCID.QueenSlimeBoss, "The wings of a great beast can be heard faintly in the distance...", spawnQueenSlime);
				spawnDukeFishron = CheckSpawn(NPCID.DukeFishron, "The squeal of a mutant creature eminates from deep underwater...", spawnDukeFishron);
				spawnPlantera = CheckSpawn(NPCID.Plantera, "A planty amalgamation has become enraged...", spawnPlantera);
				spawnGolem = CheckSpawn(NPCID.Golem, "The clanking of a sentient being from the temple grows loud...", spawnGolem);
				spawnCultist = CheckSpawn(NPCID.CultistBoss, "The chanting from the dungeon becomes hurried...", spawnCultist);
				spawnMoonLord = CheckSpawn(NPCID.MoonLordCore, "The lord of the moon awakens from his slumber...", spawnMoonLord);

				if (calamity != null)
				{
					spawnDesertScourge = CheckSpawn(calamity.Find<ModNPC>("DesertScourgeHead").Type, "The desert sand rumbles beneath your feet...", spawnDesertScourge);
					spawnCrabulon = CheckSpawn(calamity.Find<ModNPC>("Crabulon").Type, "The clacking of mycelium claws can be heard nearby...", spawnCrabulon);
					spawnHiveMind = CheckSpawn(calamity.Find<ModNPC>("HiveMind").Type, "Corrupted squelching can be heard deep from the chasms below...", spawnHiveMind);
					spawnPerforators = CheckSpawn(calamity.Find<ModNPC>("PerforatorHive").Type, "The ground rumbles as ichor slowly seeps into the ground...", spawnPerforators);
					spawnSlimeGod = CheckSpawn(calamity.Find<ModNPC>("SlimeGodCore").Type, "Slimes around you begin behaving as though possessed...", spawnSlimeGod);
					spawnCryogen = CheckSpawn(calamity.Find<ModNPC>("Cryogen").Type, "The reflection of a huge icy structure can be seen growing closer...", spawnCryogen);
					spawnAquaticScourge = CheckSpawn(calamity.Find<ModNPC>("AquaticScourgeHead").Type, "The acidic surface undulates by the movement of a massive unseen creature...", spawnAquaticScourge);
					spawnBrimstoneElemental = CheckSpawn(calamity.Find<ModNPC>("BrimstoneElemental").Type, "The crags grow ever warmer as the smell of brimstone becomes strong...", spawnBrimstoneElemental);
					spawnLeviathan = CheckSpawn(calamity.Find<ModNPC>("Anahita").Type, "The wail of an accursed goddess penetrates your head...", spawnLeviathan);
					spawnPlaguebringer = CheckSpawn(calamity.Find<ModNPC>("PlaguebringerGoliath").Type, "The jets of a plagueridden machine can be heard faintly from far away...", spawnPlaguebringer);
					spawnRavager = CheckSpawn(calamity.Find<ModNPC>("RavagerBody").Type, "A magical bone golem becomes enraged in search of it's one true enemy...", spawnRavager);
					spawnDragonfolly = CheckSpawn(calamity.Find<ModNPC>("Bumblefuck").Type, "The beating of huge wings ruffles the foliage of nearby trees...", spawnDragonfolly);
					spawnSignus = CheckSpawn(calamity.Find<ModNPC>("Signus").Type, "Shadows begin warping into strange shapes all around you...", spawnSignus);
					spawnStormWeaver = CheckSpawn(calamity.Find<ModNPC>("StormWeaverHead").Type, "A young worm grows tired of hunting wyverns...", spawnStormWeaver);
					spawnCeaselessVoid = CheckSpawn(calamity.Find<ModNPC>("CeaselessVoid").Type, "The room darkens as a being of void approaches...", spawnCeaselessVoid);
					spawnPolterghast = CheckSpawn(calamity.Find<ModNPC>("Polterghast").Type, "The scraping of metal echoes off the dungeon walls...", spawnPolterghast);
					spawnOldDuke = CheckSpawn(calamity.Find<ModNPC>("OldDuke").Type, "A stray bloodworm can be seen floating in the acid water...", spawnOldDuke);
					spawnDOG = CheckSpawn(calamity.Find<ModNPC>("DevourerofGodsHead").Type, "The sky begins tearing to reveal a dimension filled with purple mist...", spawnDOG);
					spawnYharon = CheckSpawn(calamity.Find<ModNPC>("Yharon").Type, "A rage-filled draconic roar penetrates through the thick jungle foliage...", spawnYharon);
					spawnExoMechs = CheckSpawn(calamity.Find<ModNPC>("Draedon").Type, "The clanking of massive machines echoes in your ears...", spawnExoMechs);
					spawnSCal = CheckSpawn(calamity.Find<ModNPC>("SupremeCalamitas").Type, "The brimstone witch is coming...", spawnSCal);
				}

				if (thorium != null)
				{
					spawnThunderbird = CheckSpawn(thorium.Find<ModNPC>("TheGrandThunderBird").Type, "The flap of massive wings grows loud...", spawnThunderbird);
					spawnQueenJelly = CheckSpawn(thorium.Find<ModNPC>("QueenJellyfish").Type, "Massive bubbles begin emerging from the depths of the ocean...", spawnQueenJelly);
					spawnViscount = CheckSpawn(thorium.Find<ModNPC>("Viscount").Type, "Blood begins dripping from the cavern ceiling...", spawnViscount);
					spawnEnergyStorm = CheckSpawn(thorium.Find<ModNPC>("GraniteEnergyStorm").Type, "Energy begins to coalesce around you...", spawnEnergyStorm);
					spawnBuriedChamp = CheckSpawn(thorium.Find<ModNPC>("BuriedChampion").Type, "Statues around you begin to shift...", spawnBuriedChamp);
					spawnStarScout = CheckSpawn(thorium.Find<ModNPC>("StarScouter").Type, "The hum of a massive engine echoes from the distance...", spawnStarScout);
					spawnBeholder = CheckSpawn(thorium.Find<ModNPC>("FallenBeholder").Type, "A rift from another dimension begins to open...", spawnBeholder);
					spawnForgottenOne = CheckSpawn(thorium.Find<ModNPC>("ForgottenOne").Type, "Roars from a forgotten beast rise from the depths...", spawnForgottenOne);
				}

				spawnCounter = 0;
			}
			else if (spawnCounter >= (spawnConfig.spawnCheckAmount * 60))
			{
				spawnCounter = 0;
			}
		}

        /// <summary>
        /// Adds a boss to the boss spawning Dictionary with shouldSpawn set to false, timer set to 0, and playerIndex set to -1
        /// </summary>
        /// <param name="npcType">The NPCID of the boss to be spawned</param>
        private void AddSpawn(int npcType)
		{
			spawnDict.Add(npcType, new ValueTuple<bool, ValueTuple<int, int>>(false, (0, -1)));
		}

		/// <summary>
		/// Checks if all conditions for a specific boss to spawn are met, then broadcasts the warning text if they are
		/// </summary>
		/// <param name="npcType">The NPCID of the boss to be spawned</param>
		/// <param name="warnText">The spawn text of the boss</param>
		/// <param name="spawnBool">Boolean of whether conditions for spawning the boss have been met</param>
		/// <returns>True if all conditions are met, otherwise otherwise false</returns>
		private bool CheckSpawn(int npcType, string warnText, bool spawnBool)
		{
			if (spawnDict[npcType].Item1 && !spawnBool)
			{
				if(calamity != null)
                {
					if(npcType == calamity.Find<ModNPC>("SupremeCalamitas").Type)
                    {
						if (Main.netMode == NetmodeID.SinglePlayer)
						{
							Main.NewText(warnText, new Color?(new Color(82, 7, 0)));
						}
						else if (Main.netMode == NetmodeID.Server)
						{
							ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(warnText), new Color(82, 7, 0));
						}
					}
					else
                    {
						if (Main.netMode == NetmodeID.SinglePlayer)
						{
							Main.NewText(warnText, new Color?(new Color(50, 255, 130)));
						}
						else if (Main.netMode == NetmodeID.Server)
						{
							ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(warnText), new Color(50, 255, 130));
						}
					}
                }
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(warnText, new Color?(new Color(50, 255, 130)));
				}
				else if (Main.netMode == NetmodeID.Server)
				{
					ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(warnText), new Color(50, 255, 130));
				}
				return true;
			}
			return spawnBool;
		}

        /// <summary>
        /// Increments boss spawn timer by one if boss can spawn, then spawns the boss if the timer has reached the set wait time
        /// </summary>
        /// <param name="npcType">The NPCID of the boss to be spawned</param>
        /// <param name="spawningBool">Boolean of whether conditions for spawning the boss have been met</param>
        /// <returns>spawningBool if no boss was spawned, returns false otherwise</returns>
        private bool SpawnBosses(int npcType, bool spawningBool)
		{
			if (!spawningBool)
			{
				return spawningBool;
			}

			// Increment spawn timer by one
			spawnDict[npcType] = new ValueTuple<bool, ValueTuple<int, int>>(spawnDict[npcType].Item1, (spawnDict[npcType].Item2.Item1 + 1, spawnDict[npcType].Item2.Item2));
			if (spawnDict[npcType].Item2.Item1 >= (spawnConfig.waitAmount*60) && !NPC.AnyNPCs(npcType))
			{
				if(npcType == NPCID.DukeFishron) // Custom spawn logic for Duke Fishron
                {
					if(Main.netMode == NetmodeID.SinglePlayer) 
					{
						Player player = Main.player[Main.myPlayer];
						NPC.SpawnBoss((int)player.position.X + 200, (int)player.position.Y + 100, NPCID.DukeFishron, Main.myPlayer);
					}
					else if(Main.netMode == NetmodeID.Server)
                    {
						int pNum = spawnDict[npcType].Item2.Item2;
						if(pNum < 0) pNum = 0;
                        Player player = Main.player[pNum];
                        NPC.SpawnBoss((int)player.position.X + 200, (int)player.position.Y + 100, NPCID.DukeFishron, pNum);
					}
				}
				else if(npcType == NPCID.SkeletronHead) // Custom spawn logic for Skeletron
                {
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Player player = Main.player[Main.myPlayer];
						NPC.SpawnBoss((int)player.position.X, (int)player.position.Y - 200, NPCID.SkeletronHead, Main.myPlayer);
					}
					else if (Main.netMode == NetmodeID.Server)
					{
                        int pNum = spawnDict[npcType].Item2.Item2;
                        if (pNum < 0) pNum = 0;
                        Player player = Main.player[pNum];

                        NPC.SpawnBoss((int)player.position.X, (int)player.position.Y - 200, NPCID.SkeletronHead, pNum);
					}
				}
				else if(npcType == NPCID.WallofFlesh) // Custom spawn logic for Wall of Flesh
                {
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Player player = Main.player[Main.myPlayer];
						bool isRight = player.position.X >= (Main.maxTilesX*16 / 2);
						int negative = isRight ? 1 : -1;
						bool tooLarge = ((int)player.position.X + 1500) > (Main.maxTilesX*16);
						bool tooSmall = ((int)player.position.X - 1500) < 0;
						if(tooLarge && isRight)
                        {
							NPC.SpawnBoss((Main.maxTilesX*16) - 100, (int)player.position.Y, NPCID.WallofFlesh, Main.myPlayer);
						}
						else if(tooSmall && !isRight)
                        {
							NPC.SpawnBoss(0, (int)player.position.Y, NPCID.WallofFlesh, Main.myPlayer);
						}
						else
                        {
							NPC.SpawnBoss((int)player.position.X + (1500 * negative), (int)player.position.Y, 113, Main.myPlayer);
						}
					}
					else if (Main.netMode == NetmodeID.Server)
					{
                        int pNum = spawnDict[npcType].Item2.Item2;
                        if (pNum < 0) pNum = 0;
                        Player player = Main.player[pNum];

                        bool isRight = player.position.X >= Main.maxTilesX / 2;
						int negative = isRight ? 1 : -1;
						bool tooLarge = (int)player.position.X + 1500 > Main.maxTilesX;
						bool tooSmall = (int)player.position.X - 1500 < 0;
						if (tooLarge)
						{
							NPC.SpawnBoss(Main.maxTilesX, (int)player.position.Y, NPCID.WallofFlesh, pNum);
						}
						else if (tooSmall)
						{
							NPC.SpawnBoss(0, (int)player.position.Y, NPCID.WallofFlesh, pNum);
						}
						else
						{
							NPC.SpawnBoss((int)player.position.X + 1500 * negative, (int)player.position.Y, NPCID.WallofFlesh, pNum);
						}
					}
				}
				else if (npcType == NPCID.Golem) // Custom spawn logic for Golem
                {
					if(Main.netMode == NetmodeID.SinglePlayer)
                    {
						NPC.SpawnBoss((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y - 100, NPCID.Golem, Main.myPlayer);
					}
					else if(Main.netMode == NetmodeID.Server)
                    {
                        int pNum = spawnDict[npcType].Item2.Item2;
                        if (pNum < 0) pNum = 0;
                        Player player = Main.player[pNum];

                        NPC.SpawnBoss((int)player.position.X, (int)player.position.Y - 100, NPCID.Golem, pNum);
					}
				}
				else if (calamity != null && npcType == calamity.Find<ModNPC>("Crabulon").Type) // Custom spawn logic for Crabulon
				{
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Player player = Main.player[Main.myPlayer];
						NPC.SpawnBoss((int)player.position.X + 200, (int)player.position.Y, calamity.Find<ModNPC>("Crabulon").Type, Main.myPlayer);
					}
					else if (Main.netMode == NetmodeID.Server)
					{
                        int pNum = spawnDict[npcType].Item2.Item2;
                        if (pNum < 0) pNum = 0;
                        Player player = Main.player[pNum];

                        NPC.SpawnBoss((int)player.position.X + 200, (int)player.position.Y, calamity.Find<ModNPC>("Crabulon").Type, pNum);
					}
				}
				else if (calamity != null && npcType == calamity.Find<ModNPC>("SupremeCalamitas").Type)
                {
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Player player = Main.player[Main.myPlayer];
						NPC.SpawnBoss((int)player.position.X, (int)player.position.Y, calamity.Find<ModNPC>("SupremeCalamitas").Type, Main.myPlayer);
					}
					else if (Main.netMode == NetmodeID.Server)
					{
                        int pNum = spawnDict[npcType].Item2.Item2;
                        if (pNum < 0) pNum = 0;
                        Player player = Main.player[pNum];

                        NPC.SpawnBoss((int)player.position.X, (int)player.position.Y, calamity.Find<ModNPC>("SupremeCalamitas").Type, pNum);
					}
				}
				else if (thorium != null && npcType == thorium.Find<ModNPC>("SlagFury").Type) // Custom spawn logic for Slag Fury
                {
					if (Main.netMode == NetmodeID.SinglePlayer)
					{
						NPC.SpawnOnPlayer(Main.myPlayer, npcType);
						NPC.SpawnOnPlayer(Main.myPlayer, thorium.Find<ModNPC>("Omnicide").Type);
						NPC.SpawnOnPlayer(Main.myPlayer, thorium.Find<ModNPC>("Aquaius").Type);
					}
					else if (Main.netMode == NetmodeID.Server)
					{
                        int pNum = spawnDict[npcType].Item2.Item2;
                        if (pNum < 0) pNum = 0;

                        NPC.SpawnOnPlayer(pNum, npcType);
						NPC.SpawnOnPlayer(pNum, thorium.Find<ModNPC>("Omnicide").Type);
						NPC.SpawnOnPlayer(pNum, thorium.Find<ModNPC>("Aquaius").Type);
					}
                }
				else if (Main.netMode == NetmodeID.SinglePlayer) // Default singleplayer spawn logic
				{
					NPC.SpawnOnPlayer(Main.myPlayer, npcType);
				}
				else if (Main.netMode == NetmodeID.Server) // Default multiplayer spawn logic
				{
                    int pNum = spawnDict[npcType].Item2.Item2;
                    if (pNum < 0) pNum = 0;
                    Player player = Main.player[pNum];

                    NPC.SpawnOnPlayer(pNum, npcType);
				}

				spawnDict[npcType] = new ValueTuple<bool, ValueTuple<int, int>>(false, (0, -1));
				return false;
			}
			return true;
		}
	}
}
