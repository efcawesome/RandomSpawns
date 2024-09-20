using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace RandomSpawns
{
    // In game configuration for most values
    internal class SpawnConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header($"Header1")]

        [DefaultValue(true)]
        public bool kingSlimeEnabled;
        [DefaultValue(8)]
        public int kingMinDef;
        [Range(0, 1000)]
        [DefaultValue(120)]
        public int kingMinHP;

        [DefaultValue(true)]
        public bool eaterBrainEnabled;
        [DefaultValue(12)]
        public int eaterBrainMinDef;
        [Range(0, 1000)]
        [DefaultValue(240)]
        public int eaterBrainMinHP;

        [DefaultValue(true)]
        public bool beeEnabled;
        [DefaultValue(15)]
        public int beeMinDef;
        [Range(0, 1000)]
        [DefaultValue(280)]
        public int beeMinHP;

        [DefaultValue(true)]
        public bool skeleEnabled;
        [DefaultValue(15)]
        public int skeleMinDef;
        [Range(0, 1000)]
        [DefaultValue(300)]
        public int skeleMinHP;

        [DefaultValue(true)]
        public bool deerEnabled;
        [DefaultValue(15)]
        public int deerMinDef;
        [Range(0, 1000)]
        [DefaultValue(330)]
        public int deerMinHP;

        [DefaultValue(true)]
        public bool wallEnabled;
        [DefaultValue(20)]
        public int wallMinDef;
        [Range(0, 1000)]
        [DefaultValue(360)]
        public int wallMinHP;

        [DefaultValue(true)]
        public bool queenEnabled;
        [DefaultValue(25)]
        public int queenMinDef;
        [Range(0, 1000)]
        [DefaultValue(380)]
        public int queenMinHP;

        [DefaultValue(true)]
        public bool dukeEnabled;
        [DefaultValue(30)]
        public int dukeMinDef;
        [Range(0, 1000)]
        [DefaultValue(405)]
        public int dukeMinHP;

        [DefaultValue(true)]
        public bool plantEnabled;
        [DefaultValue(30)]
        public int plantMinDef;
        [Range(0, 1000)]
        [DefaultValue(405)]
        public int plantMinHP;

        [DefaultValue(true)]
        public bool golemEnabled;
        [DefaultValue(35)]
        public int golemMinDef;
        [Range(0, 1000)]
        [DefaultValue(425)]
        public int golemMinHP;

        [DefaultValue(true)]
        public bool empressEnabled;
        [DefaultValue(35)]
        public int empressMinDef;
        [Range(0, 1000)]
        [DefaultValue(430)]
        public int empressMinHP;

        [DefaultValue(true)]
        public bool cultistEnabled;
        [DefaultValue(40)]
        public int cultistMinDef;
        [Range(0, 1000)]
        [DefaultValue(440)]
        public int cultistMinHP;

        [DefaultValue(true)]
        public bool moonEnabled;
        [DefaultValue(40)]
        public int moonMinDef;
        [Range(0, 1000)]
        [DefaultValue(450)]
        public int moonMinHP;

        [Header($"Header2")]

        [DefaultValue(60)]
        public int waitAmount;

        [DefaultValue(60)]
        public int spawnCheckAmount;

        [Range(1, 100)]
        [DefaultValue(3)]
        public int spawnChance;

        [DefaultValue(false)]
        public bool canRespawn;

        [Header($"Header3")]

        [DefaultValue(true)]
        public bool desertScourgeEnabled;
        [DefaultValue(10)]
        public int desertScourgeMinDef;
        [Range(0, 1000)]
        [DefaultValue(200)]
        public int desertScourgeMinHP;

        [DefaultValue(true)]
        public bool crabulonEnabled;
        [DefaultValue(10)]
        public int crabulonMinDef;
        [Range(0, 1000)]
        [DefaultValue(210)]
        public int crabulonMinHP;

        [DefaultValue(true)]
        public bool hivePerforatorsEnabled;
        [DefaultValue(13)]
        public int hivePerforatorsMinDef;
        [Range(0, 1000)]
        [DefaultValue(250)]
        public int hivePerforatorsMinHP;

        [DefaultValue(true)]
        public bool slimeGodEnabled;
        [DefaultValue(17)]
        public int slimeGodMinDef;
        [Range(0, 1000)]
        [DefaultValue(340)]
        public int slimeGodMinHP;

        [DefaultValue(true)]
        public bool cryogenEnabled;
        [DefaultValue(25)]
        public int cryogenMinDef;
        [Range(0, 1000)]
        [DefaultValue(380)]
        public int cryogenMinHP;

        [DefaultValue(true)]
        public bool aquaticScourgeEnabled;
        [DefaultValue(25)]
        public int aquaticScourgeMinDef;
        [Range(0, 1000)]
        [DefaultValue(390)]
        public int aquaticScourgeMinHP;

        [DefaultValue(true)]
        public bool brimstoneElementalEnabled;
        [DefaultValue(25)]
        public int brimstoneElementalMinDef;
        [Range(0, 1000)]
        [DefaultValue(400)]
        public int brimstoneElementalMinHP;

        [DefaultValue(true)]
        public bool calamitasEnabled;
        [DefaultValue(30)]
        public int calamitasMinDef;
        [Range(0, 1000)]
        [DefaultValue(405)]
        public int calamitasMinHP;

        [DefaultValue(true)]
        public bool leviathanEnabled;
        [DefaultValue(35)]
        public int leviathanMinDef;
        [Range(0, 1000)]
        [DefaultValue(425)]
        public int leviathanMinHP;

        [DefaultValue(true)]
        public bool aureusEnabled;
        [DefaultValue(35)]
        public int aureusMinDef;
        [Range(0, 1000)]
        [DefaultValue(425)]
        public int aureusMinHP;

        [DefaultValue(true)]
        public bool plaguebringerEnabled;
        [DefaultValue(35)]
        public int plaguebringerMinDef;
        [Range(0, 1000)]
        [DefaultValue(430)]
        public int plaguebringerMinHP;

        [DefaultValue(true)]
        public bool ravagerEnabled;
        [DefaultValue(35)]
        public int ravagerMinDef;
        [Range(0, 1000)]
        [DefaultValue(435)]
        public int ravagerMinHP;

        [DefaultValue(true)]
        public bool deusEnabled;
        [DefaultValue(40)]
        public int deusMinDef;
        [Range(0, 1000)]
        [DefaultValue(445)]
        public int deusMinHP;

        [DefaultValue(true)]
        public bool profanedGuardiansEnabled;
        [DefaultValue(45)]
        public int profanedGuardiansMinDef;
        [Range(0, 1000)]
        [DefaultValue(500)]
        public int profanedGuardiansMinHP;

        [DefaultValue(true)]
        public bool dragonfollyEnabled;
        [DefaultValue(45)]
        public int dragonfollyMinDef;
        [Range(0, 1000)]
        [DefaultValue(500)]
        public int dragonfollyMinHP;

        [DefaultValue(true)]
        public bool providenceEnabled;
        [DefaultValue(45)]
        public int providenceMinDef;
        [Range(0, 1000)]
        [DefaultValue(505)]
        public int providenceMinHP;

        [DefaultValue(true)]
        public bool sentinelsEnabled;
        [DefaultValue(65)]
        public int sentinelsMinDef;
        [Range(0, 1000)]
        [DefaultValue(530)]
        public int sentinelsMinHP;

        [DefaultValue(true)]
        public bool polterghastEnabled;
        [DefaultValue(65)]
        public int polterghastMinDef;
        [Range(0, 1000)]
        [DefaultValue(555)]
        public int polterghastMinHP;

        [DefaultValue(true)]
        public bool oldDukeEnabled;
        [DefaultValue(75)]
        public int oldDukeMinDef;
        [Range(0, 1000)]
        [DefaultValue(560)]
        public int oldDukeMinHP;

        [DefaultValue(true)]
        public bool dogEnabled;
        [DefaultValue(80)]
        public int dogMinDef;
        [Range(0, 1000)]
        [DefaultValue(570)]
        public int dogMinHP;

        [DefaultValue(true)]
        public bool yharonEnabled;
        [DefaultValue(90)]
        public int yharonMinDef;
        [Range(0, 1000)]
        [DefaultValue(575)]
        public int yharonMinHP;

        [DefaultValue(true)]
        public bool exoMechsEnabled;
        [DefaultValue(100)]
        public int exoMechsMinDef;
        [Range(0, 1000)]
        [DefaultValue(600)]
        public int exoMechsMinHP;

        [DefaultValue(true)]
        public bool sCalEnabled;
        [DefaultValue(100)]
        public int sCalMinDef;
        [Range(0, 1000)]
        [DefaultValue(600)]
        public int sCalMinHP;

        [Header($"Header4")]

        [DefaultValue(true)]
        public bool thunderBirdEnabled;
        [DefaultValue(8)]
        public int thunderBirdMinDef;
        [Range(0, 1000)]
        [DefaultValue(120)]
        public int thunderBirdMinHP;

        [DefaultValue(true)]
        public bool queenJellyEnabled;
        [DefaultValue(13)]
        public int queenJellyMinDef;
        [Range(0, 1000)]
        [DefaultValue(260)]
        public int queenJellyMinHP;

        [DefaultValue(true)]
        public bool viscountEnabled;
        [DefaultValue(15)]
        public int viscountMinDef;
        [Range(0, 1000)]
        [DefaultValue(280)]
        public int viscountMinHP;

        [DefaultValue(true)]
        public bool graniteStormEnabled;
        [DefaultValue(17)]
        public int graniteStormMinDef;
        [Range(0, 1000)]
        [DefaultValue(340)]
        public int graniteStormMinHP;

        [DefaultValue(true)]
        public bool buriedChampEnabled;
        [DefaultValue(17)]
        public int buriedChampMinDef;
        [Range(0, 1000)]
        [DefaultValue(340)]
        public int buriedChampMinHP;

        [DefaultValue(true)]
        public bool starScoutEnabled;
        [DefaultValue(18)]
        public int starScoutMinDef;
        [Range(0, 1000)]
        [DefaultValue(350)]
        public int starScoutMinHP;

        [DefaultValue(true)]
        public bool borStrideEnabled;
        [DefaultValue(22)]
        public int borStrideMinDef;
        [Range(0, 1000)]
        [DefaultValue(370)]
        public int borStrideMinHP;

        [DefaultValue(true)]
        public bool beholderEnabled;
        [DefaultValue(23)]
        public int beholderMinDef;
        [Range(0, 1000)]
        [DefaultValue(380)]
        public int beholderMinHP;

        [DefaultValue(true)]
        public bool lichEnabled;
        [DefaultValue(28)]
        public int lichMinDef;
        [Range(0, 1000)]
        [DefaultValue(405)]
        public int lichMinHP;

        [DefaultValue(true)]
        public bool forgottenOneEnabled;
        [DefaultValue(35)]
        public int forgottenOneMinDef;
        [Range(0, 1000)]
        [DefaultValue(430)]
        public int forgottenOneMinHP;

        [DefaultValue(true)]
        public bool primordialsEnabled;
        [DefaultValue(55)]
        public int primordialsMinDef;
        [Range(0, 1000)]
        [DefaultValue(480)]
        public int primordialsMinHP;
    }
}
