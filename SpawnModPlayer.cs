using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SteelSeries.GameSense.DeviceZone;

namespace RandomSpawns
{
	internal class SpawnModPlayer : ModPlayer
	{
		static Mod calamity;
		bool calamEnabled = ModLoader.TryGetMod("CalamityMod", out calamity);
		static Mod thorium;
		bool thoriumEnabled = ModLoader.TryGetMod("ThoriumMod", out thorium);

		private bool isBossAlive = false;

		private bool canSpawnKingSlime;
		private bool canSpawnEater;
		private bool canSpawnBrain;
		private bool canSpawnBee;
		private bool canSpawnSkeletron;
		private bool canSpawnDeerclops;
		private bool canSpawnWall;
		private bool canSpawnQueenSlime;
		private bool canSpawnDukeFishron;
		private bool canSpawnPlantera;
		private bool canSpawnGolem;
		private bool canSpawnEmpress;
		private bool canSpawnCultist;
		private bool canSpawnMoonLord;

		//Calamity
		private bool canSpawnDesertScourge;
		private bool canSpawnCrabulon;
		private bool canSpawnHiveMind;
		private bool canSpawnPerforators;
		private bool canSpawnSlimeGod;
		private bool canSpawnCryogen;
		private bool canSpawnAquaticScourge;
		private bool canSpawnBrimstone;
		private bool canSpawnCalamitas;
		private bool canSpawnLeviathan;
		private bool canSpawnAureus;
		private bool canSpawnPlaguebringer;
		private bool canSpawnRavager;
		private bool canSpawnDeus;
		private bool canSpawnProfanedGuardians;
		private bool canSpawnDragonfolly;
		private bool canSpawnProvidence;
		private bool canSpawnStormWeaver;
		private bool canSpawnCeaselessVoid;
		private bool canSpawnSignus;
		private bool canSpawnPolterghast;
		private bool canSpawnOldDuke;
		private bool canSpawnDOG;
		private bool canSpawnYharon;
		private bool canSpawnExoMechs;
		private bool canSpawnSCal;

		//Thorium
		private bool canSpawnThunderBird;
		private bool canSpawnQueenJelly;
		private bool canSpawnViscount;
		private bool canSpawnEnergyStorm;
		private bool canSpawnBuriedChampion;
		private bool canSpawnStarScouter;
		private bool canSpawnFallenBeholder;
		private bool canSpawnLich;
		private bool canSpawnForgottenOne;
		private bool canSpawnPrimordials;

		SpawnConfig spawnConfig = ModContent.GetInstance<SpawnConfig>();

		// Called at the end of the player update every frame
        public override void PostUpdate()
		{
			// True if a boss is alive, false if not (not implemented by Terraria)
			isBossAlive = NPC.AnyNPCs(NPCID.KingSlime) || NPC.AnyNPCs(NPCID.EyeofCthulhu) || NPC.AnyNPCs(NPCID.EaterofWorldsHead) || NPC.AnyNPCs(NPCID.BrainofCthulhu) || NPC.AnyNPCs(NPCID.QueenBee) ||
				NPC.AnyNPCs(NPCID.SkeletronHead) || NPC.AnyNPCs(NPCID.Deerclops) || NPC.AnyNPCs(NPCID.WallofFlesh) || NPC.AnyNPCs(NPCID.QueenSlimeBoss) || NPC.AnyNPCs(NPCID.DukeFishron) ||
				NPC.AnyNPCs(NPCID.SkeletronPrime) || NPC.AnyNPCs(NPCID.Retinazer) || NPC.AnyNPCs(NPCID.Spazmatism) || NPC.AnyNPCs(NPCID.TheDestroyer) ||
				NPC.AnyNPCs(NPCID.Plantera) || NPC.AnyNPCs(NPCID.Golem) || NPC.AnyNPCs(NPCID.HallowBoss) || NPC.AnyNPCs(NPCID.CultistBoss) || NPC.AnyNPCs(NPCID.MoonLordCore) ||
				//Calamity
				(calamity != null ? NPC.AnyNPCs(calamity.Find<ModNPC>("DesertScourgeHead").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Crabulon").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("HiveMind").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("PerforatorHive").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("SlimeGodCore").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Cryogen").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("AquaticScourgeHead").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("BrimstoneElemental").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("CalamitasClone").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("Anahita").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("AstrumAureus").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("PlaguebringerGoliath").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("RavagerBody").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("AstrumDeusHead").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("ProfanedGuardianCommander").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("ProfanedGuardianDefender").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("ProfanedGuardianHealer").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Bumblefuck").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("Providence").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Signus").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("StormWeaverHead").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("CeaselessVoid").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Polterghast").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("OldDuke").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("Yharon").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Draedon").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Apollo").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("AresBody").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("Artemis").Type) || NPC.AnyNPCs(calamity.Find<ModNPC>("ThanatosHead").Type) ||
				NPC.AnyNPCs(calamity.Find<ModNPC>("SupremeCalamitas").Type) : false) ||
				//Thorium
				(thorium != null ? NPC.AnyNPCs(thorium.Find<ModNPC>("TheGrandThunderBird").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("QueenJellyfish").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("Viscount").Type) ||
				NPC.AnyNPCs(thorium.Find<ModNPC>("GraniteEnergyStorm").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("BuriedChampion").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("StarScouter").Type) ||
				NPC.AnyNPCs(thorium.Find<ModNPC>("BoreanStrider").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("FallenBeholder").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("Lich").Type) ||
				NPC.AnyNPCs(thorium.Find<ModNPC>("ForgottenOne").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("SlagFury").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("Aquaius").Type) ||
				NPC.AnyNPCs(thorium.Find<ModNPC>("Omnicide").Type) || NPC.AnyNPCs(thorium.Find<ModNPC>("DreamEater").Type) : false);

			// Vanilla boss conditions
			canSpawnKingSlime = (!isBossAlive && Player.statDefense >= spawnConfig.kingMinDef && Player.statLifeMax2 >= spawnConfig.kingMinHP && (!NPC.downedSlimeKing || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.KingSlime) && spawnConfig.kingSlimeEnabled);
			EditSpawnDict(NPCID.KingSlime, canSpawnKingSlime);
			canSpawnEater = (!isBossAlive && Player.ZoneCorrupt && Player.statDefense >= spawnConfig.eaterBrainMinDef && Player.statLifeMax2 >= spawnConfig.eaterBrainMinHP && (!NPC.downedBoss2 || spawnConfig.canRespawn) && NPC.downedBoss1 && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && spawnConfig.eaterBrainEnabled);
			EditSpawnDict(NPCID.EaterofWorldsHead, canSpawnEater);
			canSpawnBrain = (!isBossAlive && Player.ZoneCrimson && Player.statDefense >= spawnConfig.eaterBrainMinDef && Player.statLifeMax2 >= spawnConfig.eaterBrainMinHP && (!NPC.downedBoss2 || spawnConfig.canRespawn) && NPC.downedBoss1 && !NPC.AnyNPCs(NPCID.BrainofCthulhu) && spawnConfig.eaterBrainEnabled);
			EditSpawnDict(NPCID.BrainofCthulhu, canSpawnBrain);
			canSpawnBee = (!isBossAlive && Player.ZoneJungle && Player.statDefense >= spawnConfig.beeMinDef && Player.statLifeMax2 >= spawnConfig.beeMinHP && NPC.downedBoss2 && (!NPC.downedQueenBee || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.QueenBee) && spawnConfig.beeEnabled);
			EditSpawnDict(NPCID.QueenBee, canSpawnBee);
			canSpawnSkeletron = (!isBossAlive && Player.statDefense >= spawnConfig.skeleMinDef && Player.statLifeMax2 >= spawnConfig.skeleMinHP && (!NPC.downedBoss3 || spawnConfig.canRespawn) && NPC.downedBoss2 && !NPC.AnyNPCs(NPCID.SkeletronHead) && spawnConfig.skeleEnabled);
			EditSpawnDict(NPCID.SkeletronHead, canSpawnSkeletron);
			canSpawnDeerclops = (!isBossAlive && Player.ZoneSnow && Player.statDefense >= spawnConfig.deerMinDef && Player.statLifeMax2 >= spawnConfig.deerMinHP && NPC.downedBoss3 && (!NPC.downedDeerclops || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.Deerclops) && spawnConfig.deerEnabled);
			EditSpawnDict(NPCID.Deerclops, canSpawnDeerclops);
			canSpawnWall = (!isBossAlive && Player.ZoneUnderworldHeight && Player.statDefense >= spawnConfig.wallMinDef && Player.statLifeMax2 >= spawnConfig.wallMinHP && (!Main.hardMode || spawnConfig.canRespawn) && NPC.downedBoss3 && !NPC.AnyNPCs(NPCID.WallofFlesh) && spawnConfig.wallEnabled);
			EditSpawnDict(NPCID.WallofFlesh, canSpawnWall);
			canSpawnQueenSlime = (!isBossAlive && Player.ZoneHallow && Player.statDefense >= spawnConfig.queenMinDef && Player.statLifeMax2 >= spawnConfig.queenMinHP && Main.hardMode && (!NPC.downedQueenSlime || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.QueenSlimeBoss) && spawnConfig.queenEnabled);
			EditSpawnDict(NPCID.QueenSlimeBoss, canSpawnQueenSlime);
			canSpawnDukeFishron = (!isBossAlive && Player.ZoneBeach && Player.statDefense >= spawnConfig.dukeMinDef && Player.statLifeMax2 >= spawnConfig.dukeMinHP && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && (!NPC.downedFishron || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.DukeFishron) && spawnConfig.dukeEnabled);
			EditSpawnDict(NPCID.DukeFishron, canSpawnDukeFishron);
			canSpawnPlantera = (!isBossAlive && Player.ZoneJungle && Player.statDefense >= spawnConfig.plantMinDef && Player.statLifeMax2 >= spawnConfig.plantMinHP && Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && (!NPC.downedPlantBoss || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.Plantera) && spawnConfig.plantEnabled);
			EditSpawnDict(NPCID.Plantera, canSpawnPlantera);
			canSpawnGolem = (!isBossAlive && (Player.ZoneJungle || Player.ZoneLihzhardTemple) && Player.statDefense >= spawnConfig.golemMinDef && Player.statLifeMax2 >= spawnConfig.golemMinHP && Main.hardMode && NPC.downedPlantBoss && (!NPC.downedGolemBoss || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.Golem) && spawnConfig.golemEnabled);
			EditSpawnDict(NPCID.Golem, canSpawnGolem);
			canSpawnEmpress = (!isBossAlive && Player.ZoneHallow && Player.statDefense >= spawnConfig.empressMinDef && Player.statLifeMax2 >= spawnConfig.empressMinHP && Main.hardMode && NPC.downedGolemBoss && (!NPC.downedEmpressOfLight || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.HallowBoss) && spawnConfig.empressEnabled);
			EditSpawnDict(NPCID.HallowBoss, canSpawnEmpress);
			canSpawnCultist = (!isBossAlive && Player.statDefense >= spawnConfig.cultistMinDef && Player.statLifeMax2 >= spawnConfig.cultistMinHP && Main.hardMode && NPC.downedGolemBoss && (!NPC.downedAncientCultist || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.CultistBoss) && spawnConfig.cultistEnabled);
			EditSpawnDict(NPCID.CultistBoss, canSpawnCultist);
			canSpawnMoonLord = (!isBossAlive && Player.statDefense >= spawnConfig.moonMinDef && Player.statLifeMax2 >= spawnConfig.moonMinHP && Main.hardMode && NPC.downedAncientCultist && (!NPC.downedMoonlord || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.MoonLordCore) && !NPC.AnyNPCs(NPCID.LunarTowerNebula) && !NPC.AnyNPCs(NPCID.LunarTowerSolar) && !NPC.AnyNPCs(NPCID.LunarTowerStardust) && !NPC.AnyNPCs(NPCID.LunarTowerVortex) && spawnConfig.moonEnabled);
			EditSpawnDict(NPCID.MoonLordCore, canSpawnMoonLord);

			// Calamity Mod boss conditions
			if(calamity != null)
            {
				canSpawnDesertScourge = (!isBossAlive && (Player.ZoneDesert || Player.ZoneUndergroundDesert) && Player.statDefense >= spawnConfig.desertScourgeMinDef && Player.statLifeMax2 >= spawnConfig.desertScourgeMinHP && NPC.downedSlimeKing && (!(bool)calamity.Call("GetBossDowned", "desertscourge") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("DesertScourgeHead").Type) && spawnConfig.desertScourgeEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("DesertScourgeHead").Type, canSpawnDesertScourge);
				canSpawnCrabulon = (!isBossAlive && Player.ZoneGlowshroom && Player.statDefense >= spawnConfig.crabulonMinDef && Player.statLifeMax2 >= spawnConfig.crabulonMinHP && NPC.downedBoss1 && (!(bool)calamity.Call("GetBossDowned", "crabulon") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Crabulon").Type) && spawnConfig.crabulonEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Crabulon").Type, canSpawnCrabulon);
				canSpawnHiveMind = (!isBossAlive && Player.ZoneCorrupt && Player.statDefense >= spawnConfig.hivePerforatorsMinDef && Player.statLifeMax2 >= spawnConfig.hivePerforatorsMinHP && NPC.downedBoss2 && (!(bool)calamity.Call("GetBossDowned", "hivemind") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("HiveMind").Type) && spawnConfig.hivePerforatorsEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("HiveMind").Type, canSpawnHiveMind);
				canSpawnPerforators = (!isBossAlive && Player.ZoneCrimson && Player.statDefense >= spawnConfig.hivePerforatorsMinDef && Player.statLifeMax2 >= spawnConfig.hivePerforatorsMinHP && NPC.downedBoss2 && (!(bool)calamity.Call("GetBossDowned", "perforators") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("PerforatorHive").Type) && spawnConfig.hivePerforatorsEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("PerforatorHive").Type, canSpawnPerforators);
				canSpawnSlimeGod = (!isBossAlive && Player.statDefense >= spawnConfig.slimeGodMinDef && Player.statLifeMax2 >= spawnConfig.slimeGodMinHP && NPC.downedBoss3 && (!(bool)calamity.Call("GetBossDowned", "slimegod") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("SlimeGodCore").Type) && spawnConfig.slimeGodEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("SlimeGodCore").Type, canSpawnSlimeGod);
				canSpawnCryogen = (!isBossAlive && Player.ZoneSnow && Player.statDefense >= spawnConfig.cryogenMinDef && Player.statLifeMax2 >= spawnConfig.cryogenMinHP && Main.hardMode && (!(bool)calamity.Call("GetBossDowned", "cryogen") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Cryogen").Type) && spawnConfig.cryogenEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Cryogen").Type, canSpawnCryogen);
				canSpawnAquaticScourge = (!isBossAlive && (bool)calamity.Call("GetInZone", Player, "sulfursea") && Player.statDefense >= spawnConfig.aquaticScourgeMinDef && Player.statLifeMax2 >= spawnConfig.aquaticScourgeMinHP && NPC.downedMechBossAny && (!(bool)calamity.Call("GetBossDowned", "aquaticscourge") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("AquaticScourgeHead").Type) && spawnConfig.aquaticScourgeEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("AquaticScourgeHead").Type, canSpawnAquaticScourge);
				canSpawnBrimstone = (!isBossAlive && (bool)calamity.Call("GetInZone", Player, "brimstonecrags") && Player.statDefense >= spawnConfig.brimstoneElementalMinDef && Player.statLifeMax2 >= spawnConfig.brimstoneElementalMinHP && NPC.downedMechBossAny && (!(bool)calamity.Call("GetBossDowned", "brimstoneelemental") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("BrimstoneElemental").Type) && spawnConfig.brimstoneElementalEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("BrimstoneElemental").Type, canSpawnBrimstone);
				canSpawnCalamitas = (!isBossAlive && Player.statDefense >= spawnConfig.calamitasMinDef && Player.statLifeMax2 >= spawnConfig.calamitasMinHP && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && (!(bool)calamity.Call("GetBossDowned", "calamitasclone") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("CalamitasClone").Type) && spawnConfig.calamitasEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("CalamitasClone").Type, canSpawnCalamitas);
				canSpawnLeviathan = (!isBossAlive && Player.ZoneBeach && Player.statDefense >= spawnConfig.leviathanMinDef && Player.statLifeMax2 >= spawnConfig.leviathanMinHP && NPC.downedPlantBoss && (!(bool)calamity.Call("GetBossDowned", "anahitaandleviathan") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Anahita").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Leviathan").Type) && spawnConfig.leviathanEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Anahita").Type, canSpawnLeviathan);
				canSpawnAureus = (!isBossAlive && (bool)calamity.Call("GetInZone", Player, "astral") && Player.statDefense >= spawnConfig.aureusMinDef && Player.statLifeMax2 >= spawnConfig.aureusMinHP && NPC.downedPlantBoss && (!(bool)calamity.Call("GetBossDowned", "astrumaureus") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("AstrumAureus").Type) && spawnConfig.aureusEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("AstrumAureus").Type, canSpawnAureus);
				canSpawnPlaguebringer = (!isBossAlive && Player.ZoneJungle && Player.statDefense >= spawnConfig.plaguebringerMinDef && Player.statLifeMax2 >= spawnConfig.plaguebringerMinHP && NPC.downedGolemBoss && (!(bool)calamity.Call("GetBossDowned", "plaguebringergoliath") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("PlaguebringerGoliath").Type) && spawnConfig.plaguebringerEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("PlaguebringerGoliath").Type, canSpawnPlaguebringer);
				canSpawnRavager = (!isBossAlive && Player.statDefense >= spawnConfig.ravagerMinDef && Player.statLifeMax2 >= spawnConfig.ravagerMinHP && NPC.downedGolemBoss && (!(bool)calamity.Call("GetBossDowned", "ravager") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("RavagerBody").Type) && spawnConfig.ravagerEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("RavagerBody").Type, canSpawnRavager);
				canSpawnDeus = (!isBossAlive && (bool)calamity.Call("GetInZone", Player, "astral") && Player.statDefense >= spawnConfig.deusMinDef && Player.statLifeMax2 >= spawnConfig.deusMinHP && NPC.downedAncientCultist && (!(bool)calamity.Call("GetBossDowned", "astrumdeus") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("AstrumDeusHead").Type) && spawnConfig.deusEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("AstrumDeusHead").Type, canSpawnDeus);
				canSpawnProfanedGuardians = (!isBossAlive && (Player.ZoneHallow || Player.ZoneUnderworldHeight) && Player.statDefense >= spawnConfig.profanedGuardiansMinDef && Player.statLifeMax2 >= spawnConfig.profanedGuardiansMinHP && NPC.downedMoonlord && (!(bool)calamity.Call("GetBossDowned", "profanedguardians") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("ProfanedGuardianCommander").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("ProfanedGuardianDefender").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("ProfanedGuardianHealer").Type) && spawnConfig.profanedGuardiansEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("ProfanedGuardianCommander").Type, canSpawnProfanedGuardians);
				canSpawnDragonfolly = (!isBossAlive && Player.ZoneJungle && Player.statDefense >= spawnConfig.dragonfollyMinDef && Player.statLifeMax2 >= spawnConfig.dragonfollyMinHP && NPC.downedMoonlord && (!(bool)calamity.Call("GetBossDowned", "dragonfolly") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Bumblefuck").Type) && spawnConfig.dragonfollyEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Bumblefuck").Type, canSpawnDragonfolly);
				canSpawnProvidence = (!isBossAlive && (Player.ZoneUnderworldHeight || Player.ZoneHallow) && Player.statDefense >= spawnConfig.providenceMinDef && Player.statLifeMax2 >= spawnConfig.providenceMinHP && (bool)calamity.Call("GetBossDowned", "profanedguardians") && (!(bool)calamity.Call("GetBossDowned", "providence") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Providence").Type) && spawnConfig.providenceEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Providence").Type, canSpawnProvidence);
				canSpawnStormWeaver = (!isBossAlive && Player.ZoneSkyHeight &&  Player.statDefense >= spawnConfig.sentinelsMinDef && Player.statLifeMax2 >= spawnConfig.sentinelsMinHP && (bool)calamity.Call("GetBossDowned", "providence") && (!(bool)calamity.Call("GetBossDowned", "stormweaver") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("StormWeaverHead").Type) && spawnConfig.sentinelsEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("StormWeaverHead").Type, canSpawnStormWeaver);
				canSpawnCeaselessVoid = (!isBossAlive && Player.ZoneDungeon && Player.statDefense >= spawnConfig.sentinelsMinDef && Player.statLifeMax2 >= spawnConfig.sentinelsMinHP && (bool)calamity.Call("GetBossDowned", "providence") && (!(bool)calamity.Call("GetBossDowned", "ceaselessvoid") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("CeaselessVoid").Type) && spawnConfig.sentinelsEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("CeaselessVoid").Type, canSpawnCeaselessVoid);
				canSpawnSignus = (!isBossAlive && Player.ZoneUnderworldHeight && Player.statDefense >= spawnConfig.sentinelsMinDef && Player.statLifeMax2 >= spawnConfig.sentinelsMinHP && (bool)calamity.Call("GetBossDowned", "providence") && (!(bool)calamity.Call("GetBossDowned", "signus") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Signus").Type) && spawnConfig.sentinelsEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Signus").Type, canSpawnSignus);
				canSpawnPolterghast = (!isBossAlive && Player.ZoneDungeon && Player.statDefense >= spawnConfig.polterghastMinDef && Player.statLifeMax2 >= spawnConfig.polterghastMinHP && (bool)calamity.Call("GetBossDowned", "allsentinels") && (!(bool)calamity.Call("GetBossDowned", "polterghast") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Polterghast").Type) && spawnConfig.polterghastEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Polterghast").Type, canSpawnPolterghast);
				canSpawnOldDuke = (!isBossAlive && (bool)calamity.Call("GetInZone", Player, "sulfursea") && Player.statDefense >= spawnConfig.oldDukeMinDef && Player.statLifeMax2 >= spawnConfig.oldDukeMinHP && (bool)calamity.Call("GetBossDowned", "polterghast") && (!(bool)calamity.Call("GetBossDowned", "oldduke") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("OldDuke").Type) && spawnConfig.oldDukeEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("OldDuke").Type, canSpawnOldDuke);
				canSpawnDOG = (!isBossAlive && Player.statDefense >= spawnConfig.dogMinDef && Player.statLifeMax2 >= spawnConfig.dogMinHP && (bool)calamity.Call("GetBossDowned", "polterghast") && (!(bool)calamity.Call("GetBossDowned", "dog") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("DevourerofGodsHead").Type) && spawnConfig.dogEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("DevourerofGodsHead").Type, canSpawnDOG);
				canSpawnYharon = (!isBossAlive && Player.ZoneJungle && Player.statDefense >= spawnConfig.yharonMinDef && Player.statLifeMax2 >= spawnConfig.yharonMinHP && (bool)calamity.Call("GetBossDowned", "dog") && (!(bool)calamity.Call("GetBossDowned", "yharon") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Yharon").Type) && spawnConfig.yharonEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Yharon").Type, canSpawnYharon);
				canSpawnExoMechs = (!isBossAlive && Player.statDefense >= spawnConfig.exoMechsMinDef && Player.statLifeMax2 >= spawnConfig.exoMechsMinHP && (bool)calamity.Call("GetBossDowned", "yharon") && (!(bool)calamity.Call("GetBossDowned", "exomechs") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("SupremeCalamitas").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Draedon").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Apollo").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("AresBody").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Artemis").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("ThanatosHead").Type) && spawnConfig.exoMechsEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("Draedon").Type, canSpawnExoMechs);
				canSpawnSCal = (!isBossAlive && Player.statDefense >= spawnConfig.sCalMinDef && Player.statLifeMax2 >= spawnConfig.sCalMinHP && (bool)calamity.Call("GetBossDowned", "yharon") && (!(bool)calamity.Call("GetBossDowned", "scal") || spawnConfig.canRespawn) && !NPC.AnyNPCs(calamity.Find<ModNPC>("SupremeCalamitas").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Draedon").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Apollo").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("AresBody").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("Artemis").Type) && !NPC.AnyNPCs(calamity.Find<ModNPC>("ThanatosHead").Type) && spawnConfig.sCalEnabled);
				EditSpawnDict(calamity.Find<ModNPC>("SupremeCalamitas").Type, canSpawnSCal);
			}

			// Thorium Mod boss conditions
			if(thorium != null)
            {
				canSpawnThunderBird = (!isBossAlive && spawnConfig.thunderBirdEnabled && Main.dayTime && Player.ZoneDesert && Player.statDefense >= spawnConfig.thunderBirdMinDef && Player.statLifeMax2 >= spawnConfig.thunderBirdMinHP && (!(bool)thorium.Call("GetDownedBoss", "TheGrandThunderBird") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("TheGrandThunderBird").Type));
				EditSpawnDict(thorium.Find<ModNPC>("TheGrandThunderBird").Type, canSpawnThunderBird);
				canSpawnQueenJelly = (!isBossAlive && spawnConfig.queenJellyEnabled && Main.dayTime && Player.ZoneBeach && Player.statDefense >= spawnConfig.queenJellyMinDef && Player.statLifeMax2 >= spawnConfig.queenJellyMinHP && NPC.downedBoss2 && (!(bool)thorium.Call("GetDownedBoss", "QueenJellyfish") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("QueenJellyfish").Type));
				EditSpawnDict(thorium.Find<ModNPC>("QueenJellyfish").Type, canSpawnQueenJelly);
				canSpawnViscount = (!isBossAlive && spawnConfig.viscountEnabled && Player.ZoneNormalCaverns && Player.statDefense >= spawnConfig.viscountMinDef && Player.statLifeMax2 >= spawnConfig.viscountMinHP && (bool)thorium.Call("GetDownedBoss", "QueenJellyfish") && (!(bool)thorium.Call("GetDownedBoss", "Viscount") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("Viscount").Type));
				EditSpawnDict(thorium.Find<ModNPC>("Viscount").Type, canSpawnViscount);
				canSpawnEnergyStorm = (!isBossAlive && spawnConfig.graniteStormEnabled && (thorium.TryFind("GraniteBiome", out ModBiome biome) ? Player.InModBiome(biome) : false) && Player.statDefense >= spawnConfig.graniteStormMinDef && Player.statLifeMax2 >= spawnConfig.graniteStormMinHP && NPC.downedBoss3 && (!(bool)thorium.Call("GetDownedBoss", "GraniteEnergyStorm") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("GraniteEnergyStorm").Type));
				EditSpawnDict(thorium.Find<ModNPC>("GraniteEnergyStorm").Type, canSpawnEnergyStorm);
				canSpawnBuriedChampion = (!isBossAlive && spawnConfig.buriedChampEnabled && (thorium.TryFind("MarbleBiome", out ModBiome biome1) ? Player.InModBiome(biome1) : false) && Player.statDefense >= spawnConfig.buriedChampMinDef && Player.statLifeMax2 >= spawnConfig.buriedChampMinHP && NPC.downedBoss3 && (!(bool)thorium.Call("GetDownedBoss", "BuriedChampion") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("BuriedChampion").Type));
				EditSpawnDict(thorium.Find<ModNPC>("BuriedChampion").Type, canSpawnBuriedChampion);
				canSpawnStarScouter = (!isBossAlive && spawnConfig.starScoutEnabled && Player.ZoneSkyHeight && Player.statDefense >= spawnConfig.starScoutMinDef && Player.statLifeMax2 >= spawnConfig.starScoutMinHP && ((bool)thorium.Call("GetDownedBoss", "BuriedChampion") || (bool)thorium.Call("GetDownedBoss", "GraniteEnergyStorm")) && (!(bool)thorium.Call("GetDownedBoss", "StarScouter") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("StarScouter").Type));
				EditSpawnDict(thorium.Find<ModNPC>("StarScouter").Type, canSpawnStarScouter);
				canSpawnFallenBeholder = (!isBossAlive && spawnConfig.beholderEnabled && Player.ZoneUnderworldHeight && Player.statDefense >= spawnConfig.beholderMinDef && Player.statLifeMax2 >= spawnConfig.beholderMinHP && (bool)thorium.Call("GetDownedBoss", "BoreanStrider") && (!(bool)thorium.Call("GetDownedBoss", "FallenBeholder") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("FallenBeholder").Type));
				EditSpawnDict(thorium.Find<ModNPC>("FallenBeholder").Type, canSpawnFallenBeholder);
				canSpawnLich = (!isBossAlive && spawnConfig.lichEnabled && Player.statDefense >= spawnConfig.lichMinDef && Player.statLifeMax2 >= spawnConfig.lichMinHP && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && (!(bool)thorium.Call("GetDownedBoss", "Lich") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("Lich").Type));
				EditSpawnDict(thorium.Find<ModNPC>("Lich").Type, canSpawnLich);
				canSpawnForgottenOne = (!isBossAlive && spawnConfig.forgottenOneEnabled && (thorium.TryFind("DepthsBiome", out ModBiome biome2) ? Player.InModBiome(biome2) : false) && Player.statDefense >= spawnConfig.forgottenOneMinDef && Player.statLifeMax2 >= spawnConfig.forgottenOneMinHP && NPC.downedGolemBoss && (!(bool)thorium.Call("GetDownedBoss", "ForgottenOne") || spawnConfig.canRespawn) && !NPC.AnyNPCs(thorium.Find<ModNPC>("ForgottenOne").Type));
				EditSpawnDict(thorium.Find<ModNPC>("ForgottenOne").Type, canSpawnForgottenOne);
				canSpawnPrimordials = (!isBossAlive && spawnConfig.primordialsEnabled && Player.statDefense >= spawnConfig.primordialsMinDef && Player.statLifeMax2 >= spawnConfig.primordialsMinHP && NPC.downedMoonlord && (!(bool)thorium.Call("GetDownedBoss", "ThePrimordials") || spawnConfig.canRespawn) && !NPC.AnyNPCs(NPCID.LunarTowerNebula) && !NPC.AnyNPCs(NPCID.LunarTowerSolar) && !NPC.AnyNPCs(NPCID.LunarTowerStardust) && !NPC.AnyNPCs(NPCID.LunarTowerVortex) && !NPC.AnyNPCs(thorium.Find<ModNPC>("Aquaius").Type) && !NPC.AnyNPCs(thorium.Find<ModNPC>("Omnicide").Type) && !NPC.AnyNPCs(thorium.Find<ModNPC>("SlagFury").Type) && !NPC.AnyNPCs(thorium.Find<ModNPC>("DreamEater").Type));
				EditSpawnDict(thorium.Find<ModNPC>("SlagFury").Type, canSpawnPrimordials);
			}
		}

        /// <summary>
        /// Edits the boss spawning Dictionary in the SpawningModWorld class
        /// </summary>
        /// <param name="npcType">The NPCID of the boss to be spawned</param>
        /// <param name="spawnBool">Boolean of whether conditions are met for the boss to spawn</param>
        private void EditSpawnDict(int npcType, bool spawnBool)
		{
			int pNum = Player.whoAmI;
			if(!spawnBool && pNum == SpawningModWorld.spawnDict[npcType].Item2.Item2) SpawningModWorld.spawnDict[npcType] = new ValueTuple<bool, ValueTuple<int, int>>(spawnBool, (SpawningModWorld.spawnDict[npcType].Item2.Item1, -1));
			else if(spawnBool && SpawningModWorld.spawnDict[npcType].Item2.Item2 == -1) SpawningModWorld.spawnDict[npcType] = new ValueTuple<bool, ValueTuple<int, int>>(spawnBool, (SpawningModWorld.spawnDict[npcType].Item2.Item1, pNum));
        }
	}
}