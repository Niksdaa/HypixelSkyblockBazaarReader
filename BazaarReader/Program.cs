using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1Test
{
    class Program
    {
        //Test3
        //Build MyValue
        public struct MyValue
        {
            public object productIDInDict;
            public string translatedProductNameInDict;
            public double productSellPriceInDict;
            public double productBuyPriceInDict;
            public string productPriceDifferenceInDict;
            public int productSellMovingWeekInDict;
            public int productBuyMovingWeekInDict;
            public string productProfitPerCoin;
        }

        //Build own Dict
        public class MyDictionary : Dictionary<int, MyValue>
        {
            public void Add(int key, object value1, string value2, double value3, double value4, string value5, int value6, int value7, string value8)
            {
                MyValue val;
                val.productIDInDict = value1;
                val.translatedProductNameInDict = value2;
                val.productSellPriceInDict = value3;
                val.productBuyPriceInDict = value4;
                val.productPriceDifferenceInDict = value5;
                val.productSellMovingWeekInDict = value6;
                val.productBuyMovingWeekInDict = value7;
                val.productProfitPerCoin = value8;
                this.Add(key, val);
            }
        }

        static void Main(string[] args)
        {

            //ATTENTION ENCHANTEDCARROTONASTICK (buy & sell_summary) = List<object> == null
            //ATTENTION BAZAARCOOKIE (buy & sell_summary) = List<object> == null

            //Usable Objects
            object productName;
            object productSellSummary = null;
            object productBuySummary = null;
            object productSellMovingWeek = null;
            object productBuyMovingWeek = null;

            //Char for way of sorting
            char test = 'z'; //z = null; a = Profit per Coin; b = Overall Profit

            //Amount of places in Dict and Output
            int amount = 100;

            //Prep Value-Dict
            var dict = new MyDictionary();
            for (int i = 1; i <= amount; i++)
            {
                dict.Add(i, null, null, 0, 0, null, 0, 0, null);
            }

            //Translation-Dict
            Dictionary<String, String> nameTranslation = new Dictionary<string, string>();
            nameTranslation.Add("INKSACK3", "Cocoa Beans");
            nameTranslation.Add("BROWNMUSHROOM", "Brown Mushroom");
            nameTranslation.Add("SPOOKYSHARD", "Spookyshard");
            nameTranslation.Add("INKSACK4", "Lapis Lazuli");
            nameTranslation.Add("TARANTULAWEB", "Tarantula Web");
            nameTranslation.Add("CARROTITEM", "Carrot");
            nameTranslation.Add("ENCHANTEDPOTATO", "Enchanted Potato");
            nameTranslation.Add("EXPBOTTLE", "Experience Bottle");
            nameTranslation.Add("JERRYBOXGREEN", "Green Jerry Box");
            nameTranslation.Add("ENCHANTEDSLIMEBALL", "Enchanted Slimeball");
            nameTranslation.Add("ENCHANTEDGOLDENCARROT", "Enchanted Golden Carrot");
            nameTranslation.Add("ENCHANTEDREDMUSHROOM", "Enchanted Red Mushroom");
            nameTranslation.Add("ENCHANTEDRABBITHIDE", "Enchanted Rabbit Hide");
            nameTranslation.Add("FLAWEDAMETHYSTGEM", "Flawed Amethyst");
            nameTranslation.Add("PERFECTJADEGEM", "Perfect Jade");
            nameTranslation.Add("ENCHANTEDBIRCHLOG", "Enchanted Birch Log");
            nameTranslation.Add("ENCHANTEDGUNPOWDER", "Enchanted Gunpowder");
            nameTranslation.Add("ENCHANTEDMELON", "Enchanted Melon");
            nameTranslation.Add("ENCHANTEDSUGAR", "Enchanted Sugar");
            nameTranslation.Add("CACTUS", "Cactus");
            nameTranslation.Add("ENCHANTEDBLAZEROD", "Enchanted Blazerod");
            nameTranslation.Add("FLAWEDJASPERGEM", "Flawed Jasper");
            nameTranslation.Add("ENCHANTEDCAKE", "Enchanted Cake");
            nameTranslation.Add("PUMPKIN", "Pumpkin");
            nameTranslation.Add("ENCHANTEDBROWNMUSHROOM", "Enchanted Brown Mushroom");
            nameTranslation.Add("GOBLINEGGYELLOW", "Yellow Goblinegg");
            nameTranslation.Add("WHEAT", "Wheat");
            nameTranslation.Add("FLAWEDAMBERGEM", "Flawed Amber");
            nameTranslation.Add("NURSESHARKTOOTH", "Nurseshark Tooth");
            nameTranslation.Add("ENCHANTEDRAWSALMON", "Echanted Raw Salmon");
            nameTranslation.Add("ENCHANTEDGLISTERINGMELON", "Enchanted Glistering Melon");
            nameTranslation.Add("PRISMARINESHARD", "Prismarine Shard");
            nameTranslation.Add("PROTECTORFRAGMENT", "Protector Dragon Fragment");
            nameTranslation.Add("ENCHANTEDEMERALD", "Enchanted Emerald");
            nameTranslation.Add("ENCHANTEDSPIDEREYE", "Enchanted Spider Eye");
            nameTranslation.Add("REDMUSHROOM", "Red Mushroom");
            nameTranslation.Add("GRANDEXPBOTTLE", "Grand Experience Bottle");
            nameTranslation.Add("ENCHANTEDMELONBLOCK", "Enchanted Melon Block");
            nameTranslation.Add("MUTTON", "Mutton");
            nameTranslation.Add("POWERCRYSTAL", "Power Crystal");
            nameTranslation.Add("RAWSOULFLOW", "Raw Soulflow");
            nameTranslation.Add("DIAMOND", "Diamond");
            nameTranslation.Add("SHARKFIN", "Shark Fin");
            nameTranslation.Add("WISEFRAGMENT", "Wise Dragon Fragment");
            nameTranslation.Add("COBBLESTONE", "Cobblestone");
            nameTranslation.Add("REFINEDMITHRIL", "Refined Mithril");
            nameTranslation.Add("RAWFISH", "Raw Fish");
            nameTranslation.Add("SPIDEREYE", "Spider Eye");
            nameTranslation.Add("PERFECTRUBYGEM", "Perfect Ruby");
            nameTranslation.Add("ENCHANTEDPUFFERFISH", "Enchanted Pufferfish");
            nameTranslation.Add("YOGGIE", "Yoggie");
            nameTranslation.Add("PERFECTJASPERGEM", "Perfect Jasper");
            nameTranslation.Add("POTATOITEM", "Potato");
            nameTranslation.Add("ENCHANTEDNETHERRACK", "Enchanted Netherrack");
            nameTranslation.Add("ENCHANTEDHARDSTONE", "Enchanted Hardstone");
            nameTranslation.Add("ENCHANTEDHUGEMUSHROOM1", "Enchanted Brown Mushroom Block");
            nameTranslation.Add("REFINEDDIAMOND", "Refined Diamond");
            nameTranslation.Add("ENCHANTEDCOBBLESTONE", "Enchanted Cobblestone");
            nameTranslation.Add("TIGHTLYTIEDHAYBALE", "Tightly-Tied Hay Bale");
            nameTranslation.Add("ENCHANTEDHUGEMUSHROOM2", "Enchanted Red Mushroom Block");
            nameTranslation.Add("PORK", "Pork");
            nameTranslation.Add("PRISMARINECRYSTALS", "Prismarine Crystals");
            nameTranslation.Add("ICE", "Ice");
            nameTranslation.Add("HUGEMUSHROOM1", "Brown Mushroom Block");
            nameTranslation.Add("TIGERSHARKTOOTH", "Tiger Shark Tooth");
            nameTranslation.Add("HUGEMUSHROOM2", "Red Mushroom Block");
            nameTranslation.Add("ICEBAIT", "Ice Bait");
            nameTranslation.Add("LOG21", "Dark Oak Wood");
            nameTranslation.Add("ENCHANTEDSNOWBLOCK", "Enchanted Snow Block");
            nameTranslation.Add("STRING", "String");
            nameTranslation.Add("GOLDENTOOTH", "Golden Tooth");
            nameTranslation.Add("CHEESEFUEL", "Cheese Fuel");
            nameTranslation.Add("HYPERCATALYST", "Hyper Catalyst");
            nameTranslation.Add("RABBITFOOT", "Rabbit Foot");
            nameTranslation.Add("REDSTONE", "Redstone");
            nameTranslation.Add("JERRYBOXGOLDEN", "Golden Jerrybox");
            nameTranslation.Add("PUMPKINGUTS", "Pumpkin Guts");
            nameTranslation.Add("ENCHANTEDCACTUSGREEN", "Enchanted Cactusgreen");
            nameTranslation.Add("BOOSTERCOOKIE", "Boostercookie");
            nameTranslation.Add("ENCHANTEDCARROTONASTICK", "Enchanted Carrot on a Stick");
            nameTranslation.Add("ENCHANTEDLAPISLAZULIBLOCK", "Enchanted Lapis Lazuli Block");
            nameTranslation.Add("ENCHANTEDENDSTONE", "Enchanted Endstone");
            nameTranslation.Add("ENCHANTEDCOOKIE", "Enchanted Cookie");
            nameTranslation.Add("ENCHANTEDSAND", "Enchanted Sand");
            nameTranslation.Add("COLOSSALEXPBOTTLE", "Colossal Experience Bottle");
            nameTranslation.Add("ENCHANTEDSTRING", "Enchanted String");
            nameTranslation.Add("STRONGFRAGMENT", "Strong Dragon Fragment");
            nameTranslation.Add("SLIMEBALL", "Slimeball");
            nameTranslation.Add("ENCHANTEDACACIALOG", "Enchanted Acacia Log");
            nameTranslation.Add("SNOWBALL", "Snowball");
            nameTranslation.Add("HOLYFRAGMENT", "Holy Dragon Fragment");
            nameTranslation.Add("ENCHANTEDEGG", "Enchanted Egg");
            nameTranslation.Add("SAND", "Sand");
            nameTranslation.Add("SOULFRAGMENT", "Soul Fragment");
            nameTranslation.Add("FLAWEDRUBYGEM", "Flawed Ruby");
            nameTranslation.Add("FINEJADEGEM", "Fine Jade");
            nameTranslation.Add("RAWCHICKEN", "Raw Chicken");
            nameTranslation.Add("PLASMABUCKET", "Plasma Bucket");
            nameTranslation.Add("FLAWLESSJASPERGEM", "Flawless Jasper");
            nameTranslation.Add("ANCIENTCLAW", "Ancient Claw");
            nameTranslation.Add("ENCHANTEDLAPISLAZULI", "Enchanted Lapis Lazuli");
            nameTranslation.Add("ENCHANTEDGHASTTEAR", "Enchanted Ghasttear");
            nameTranslation.Add("ENCHANTEDCOCOA", "Enchanted Cocoabeans");
            nameTranslation.Add("CARROTBAIT", "Carrot Bait");
            nameTranslation.Add("FINETOPAZGEM", "Fine Topaz");
            nameTranslation.Add("SEEDS", "Seeds");
            nameTranslation.Add("FINERUBYGEM", "Fine Ruby");
            nameTranslation.Add("ENCHANTEDLEATHER", "Enchanted Leather");
            nameTranslation.Add("ENCHANTEDSHARKFIN", "Enchanted Shark Fin");
            nameTranslation.Add("ENCHANTEDSPONGE", "Enchanted Sponge");
            nameTranslation.Add("PERFECTAMBERGEM", "Perfect Amber");
            nameTranslation.Add("HAYBLOCK", "Hay Block");
            nameTranslation.Add("INKSACK", "Inksack");
            nameTranslation.Add("FLINT", "Flint");
            nameTranslation.Add("ENCHANTEDROTTENFLESH", "Enchanted Rotten Flesh");
            nameTranslation.Add("WOLFTOOTH", "Wolf Tooth");
            nameTranslation.Add("ENCHANTEDSPRUCELOG", "Enchanted Spruce Log");
            nameTranslation.Add("ENCHANTEDGRILLEDPORK", "Enchanted Grilled Pork");
            nameTranslation.Add("ENCHANTEDNETHERSTALK", "Enchanted Netherstalk");
            nameTranslation.Add("ENCHANTEDREDSTONEBLOCK", "Enchanted Redstone Block");
            nameTranslation.Add("ENCHANTEDQUARTZBLOCK", "Enchanted Quartz Block");
            nameTranslation.Add("ENCHANTEDANCIENTCLAW", "Enchanted Ancient Claw");
            nameTranslation.Add("GREENCANDY", "Green Candy");
            nameTranslation.Add("ENCHANTEDREDSTONE", "Enchanted Redstone");
            nameTranslation.Add("ENCHANTEDREDSTONELAMP", "Enchanted Redstonelamp");
            nameTranslation.Add("TREASURITE", "Treasurite");
            nameTranslation.Add("DWARVENCOMPACTOR", "Dwarven Compactor");
            nameTranslation.Add("GREATWHITESHARKTOOTH", "Great White Shark Tooth");
            nameTranslation.Add("GRAVEL", "Gravel");
            nameTranslation.Add("MELON", "Melon");
            nameTranslation.Add("ENCHANTEDLAVABUCKET", "Enchanted Lava Bucket");
            nameTranslation.Add("ENCHANTEDPACKEDICE", "Enchanted Packed Ice");
            nameTranslation.Add("RAWFISH3", "Pufferfish");
            nameTranslation.Add("ENCHANTEDPRISMARINESHARD", "Enchanted Prismarine Shard");
            nameTranslation.Add("ENCHANTEDIRONBLOCK", "Enchanted Iron Block");
            nameTranslation.Add("RECOMBOBULATOR3000", "Recombobulator 3000");
            nameTranslation.Add("ENCHANTEDCARROTSTICK", "Enchanted Carrot on a Stick");
            nameTranslation.Add("BONE", "Bone");
            nameTranslation.Add("RAWFISH2", "Clownfish");
            nameTranslation.Add("RAWFISH1", "Raw Salmon");
            nameTranslation.Add("REVENANTFLESH", "Revenant Flesh");
            nameTranslation.Add("ENCHANTEDGLOWSTONE", "Enchanted Glowstone");
            nameTranslation.Add("ENCHANTEDPORK", "Enchanted Pork");
            nameTranslation.Add("GOBLINEGGRED", "Red Goblin Egg");
            nameTranslation.Add("ROUGHJASPERGEM", "Rough Jasper");
            nameTranslation.Add("FEATHER", "Feather");
            nameTranslation.Add("WHALEBAIT", "Whale Bait");
            nameTranslation.Add("NETHERRACK", "Netherrack");
            nameTranslation.Add("SPONGE", "Sponge");
            nameTranslation.Add("BLAZEROD", "Blaze Rod");
            nameTranslation.Add("ENCHANTEDDARKOAKLOG", "Enchanted Dark Oak Log");
            nameTranslation.Add("FLAWLESSTOPAZGEM", "Flawless Topaz");
            nameTranslation.Add("YOUNGFRAGMENT", "Young Dragon Fragment");
            nameTranslation.Add("ENCHANTEDCLOWNFISH", "Enchanted Clownfish");
            nameTranslation.Add("REFINEDMINERAL", "Refined Mineral");
            nameTranslation.Add("ENCHANTEDGOLD", "Enchanted Gold");
            nameTranslation.Add("ENCHANTEDRAWCHICKEN", "Enchanted Raw Chicken");
            nameTranslation.Add("ENCHANTEDWATERLILY", "Enchanted Lily Pad");
            nameTranslation.Add("ROUGHAMETHYSTGEM", "Rough Amethyst");
            nameTranslation.Add("ROUGHRUBYGEM", "Rough Ruby");
            nameTranslation.Add("GOBLINEGGBLUE", "Blue Goblin Egg");
            nameTranslation.Add("LOG1", "Spruce Log");
            nameTranslation.Add("FLAWLESSRUBYGEM", "Flawless Ruby");
            nameTranslation.Add("NULLATOM", "Nullatom");
            nameTranslation.Add("TITANIUMORE", "Titanium Ore");
            nameTranslation.Add("CATALYST", "Catalyst");
            nameTranslation.Add("BLUESHARKTOOTH", "Blue Shark Tooth");
            nameTranslation.Add("LOG3", "Jungle Log");
            nameTranslation.Add("LOG2", "Birch Log");
            nameTranslation.Add("BLESSEDBAIT", "Blessed Bait");
            nameTranslation.Add("ENCHANTEDGLOWSTONEDUST", "Enchanted Glowstone Dust");
            nameTranslation.Add("ENCHANTEDINKSACK", "Enchanted Inksack");
            nameTranslation.Add("ENCHANTEDCACTUS", "Enchanted Cactus");
            nameTranslation.Add("ENCHANTEDSUGARCANE", "Enchanted Sugar Cane");
            nameTranslation.Add("FLAWLESSSAPPHIREGEM", "Flawless Sapphire");
            nameTranslation.Add("ENCHANTEDCOOKEDSALMON", "Enchanted Cooked Salmon");
            nameTranslation.Add("ENCHANTEDSEEDS", "Enchanted Seeds");
            nameTranslation.Add("CONCENTRATEDSTONE", "Concentrated Stone");
            nameTranslation.Add("LOG", "Oak Log");
            nameTranslation.Add("JACOBSTICKET", "Jacob's Ticket");
            nameTranslation.Add("ENCHANTEDBONEBLOCK", "Enchanted Bone Block");
            nameTranslation.Add("GHASTTEAR", "Ghats Tear");
            nameTranslation.Add("ABSOLUTEENDERPEARL", "Absolute Enderpearl");
            nameTranslation.Add("ENCHANTEDENDERPEARL", "Enchanted Ender Pearl");
            nameTranslation.Add("UNSTABLEFRAGMENT", "Unstable Dragon Fragment");
            nameTranslation.Add("PURPLECANDY", "Purple Candy");
            nameTranslation.Add("SPIKEDBAIT", "Spiked Bait");
            nameTranslation.Add("POLISHEDPUMPKIN", "Polished Pumpkin");
            nameTranslation.Add("ENCHANTEDFERMENTEDSPIDEREYE", "Enchanted Fermented Spider Eye");
            nameTranslation.Add("ENCHANTEDGOLDBLOCK", "Enchanted Gold Block");
            nameTranslation.Add("ROUGHJADEGEM", "Rough Jade");
            nameTranslation.Add("ENCHANTEDJUNGLELOG", "Enchanted Jungle Log");
            nameTranslation.Add("ENCHANTEDFLINT", "Enchanted Flint");
            nameTranslation.Add("IRONINGOT", "Iron Ingot");
            nameTranslation.Add("ENCHANTEDEMERALDBLOCK", "Enchanted Emerald Block");
            nameTranslation.Add("NULLOVOID", "Nullovoid");
            nameTranslation.Add("ENCHANTEDCLAYBALL", "Enchanted Clay Ball");
            nameTranslation.Add("ROUGHSAPPHIREGEM", "Rough Sapphire");
            nameTranslation.Add("GLOWSTONEDUST", "Glowstone Dust");
            nameTranslation.Add("GOLDINGOT", "Gold Ingot");
            nameTranslation.Add("REVENANTVISCERA", "Revenant Viscera");
            nameTranslation.Add("PERFECTAMETHYSTGEM", "Perfect Amethyst");
            nameTranslation.Add("TARANTULASILK", "Tarantula Silk");
            nameTranslation.Add("TITANICEXPBOTTLE", "Titanic Experience Bottle");
            nameTranslation.Add("ENCHANTEDMUTTON", "Enchanted Mutton");
            nameTranslation.Add("NULLSPHERE", "Nullsphere");
            nameTranslation.Add("ENCHANTEDIRON", "Enchanted Iron Ingot");
            nameTranslation.Add("SUPERCOMPACTOR3000", "Supercompactor 3000");
            nameTranslation.Add("SUPEREGG", "Super Egg");
            nameTranslation.Add("STOCKOFSTONKS", "Stock of Stonks");
            nameTranslation.Add("MITHRILORE", "Mithril Ore");
            nameTranslation.Add("ENCHANTEDHAYBLOCK", "Enchanted Hay Block");
            nameTranslation.Add("ENCHANTEDBONE", "Enchanted Bone");
            nameTranslation.Add("ENCHANTEDPAPER", "Enchanted Paper");
            nameTranslation.Add("ENCHANTEDTITANIUM", "Enchanted Titanium");
            nameTranslation.Add("ENCHANTEDDIAMONDBLOCK", "Enchanted Diamond Block");
            nameTranslation.Add("SPOOKYBAIT", "Spooky Bait");
            nameTranslation.Add("SUPERIORFRAGMENT", "Superior Dragon Fragment");
            nameTranslation.Add("MAGMABUCKET", "Magma Bucket");
            nameTranslation.Add("EMERALD", "Emerald");
            nameTranslation.Add("GOBLINEGGGREEN", "Green Goblin Egg");
            nameTranslation.Add("ENCHANTEDRABBITFOOT", "Enchanted Rabbit Foot");
            nameTranslation.Add("LIGHTBAIT", "Light Bait");
            nameTranslation.Add("HOTPOTATOBOOK", "Hot Potato Book");
            nameTranslation.Add("ENCHANTEDICE", "Enchanted (D)ice");
            nameTranslation.Add("CLAYBALL", "Clay Ball");
            nameTranslation.Add("ARACHNEKEEPERFRAGMENT", "Arachne's Keeper Fragment");
            nameTranslation.Add("OLDFRAGMENT", "Old Dragon Fragment");
            nameTranslation.Add("GREENGIFT", "Green Gift");
            nameTranslation.Add("WORMMEMBRANE", "Wormmembrane");
            nameTranslation.Add("FLAWLESSAMETHYSTGEM", "Flawless Amethyst");
            nameTranslation.Add("ROUGHTOPAZGEM", "Rough Topaz");
            nameTranslation.Add("PACKEDICE", "Packed Ice");
            nameTranslation.Add("ROUGHAMBERGEM", "Rough Amber");
            nameTranslation.Add("WATERLILY", "Lily Pad");
            nameTranslation.Add("LOG_2", "Acacia Log");
            nameTranslation.Add("HAMSTERWHEEL", "Hamster Wheel");
            nameTranslation.Add("ENCHANTEDOBSIDIAN", "Enchanted Obsidian");
            nameTranslation.Add("FINEAMBERGEM", "Fine Amber");
            nameTranslation.Add("ENCHANTEDCOAL", "Enchanted Coal");
            nameTranslation.Add("ENCHANTEDQUARTZ", "Enchanted Quartz");
            nameTranslation.Add("COAL", "Coal");
            nameTranslation.Add("ENDERPEARL", "Enderpearl");
            nameTranslation.Add("ENCHANTEDCOALBLOCK", "Enchanted Coal Block");
            nameTranslation.Add("WEREWOLFSKIN", "Werewolf Skin");
            nameTranslation.Add("PERFECTTOPAZGEM", "Perfect Topaz");
            nameTranslation.Add("GOBLINEGG", "Goblin Egg");
            nameTranslation.Add("ENCHANTEDPRISMARINECRYSTALS", "Enchanted Prismarine Crystals");
            nameTranslation.Add("DAEDALUSSTICK", "Daedalus Stick");
            nameTranslation.Add("ENCHANTEDWETSPONGE", "Enchanted Wet Sponge");
            nameTranslation.Add("FLAWEDJADEGEM", "Flawed Jade");
            nameTranslation.Add("ENCHANTEDRAWFISH", "Enchanted Raw Fish");
            nameTranslation.Add("ENDERSTONE", "Endstone");
            nameTranslation.Add("FOULFLESH", "Foul Flesh");
            nameTranslation.Add("QUARTZ", "Quartz");
            nameTranslation.Add("JERRYBOXPURPLE", "Purple Jerry Box");
            nameTranslation.Add("RAWBEEF", "Raw Beef");
            nameTranslation.Add("SLUDGEJUICE", "Sludge Juice");
            nameTranslation.Add("ENCHANTEDEYEOFENDER", "Enchanted Eye of Ender");
            nameTranslation.Add("ECTOPLASM", "Ectoplasm");
            nameTranslation.Add("MAGMACREAM", "Magmacream");
            nameTranslation.Add("SUGARCANE", "Sugar Cane");
            nameTranslation.Add("SHARKBAIT", "Shark Bait");
            nameTranslation.Add("ENCHANTEDMITHRIL", "Enchanted Mithril");
            nameTranslation.Add("REDGIFT", "Red Gift");
            nameTranslation.Add("JERRYBOXBLUE", "Blue Jerry Box");
            nameTranslation.Add("ENCHANTEDRAWBEEF", "Enchanted Raw Beef");
            nameTranslation.Add("ENCHANTEDSLIMEBLOCK", "Enchanted Slime Block");
            nameTranslation.Add("ENCHANTEDFEATHER", "Enchanted Feather");
            nameTranslation.Add("ENCHANTEDOAKLOG", "Enchanted Oak Log");
            nameTranslation.Add("RABBITHIDE", "Rabbit Hide");
            nameTranslation.Add("WHITEGIFT", "White Gift");
            nameTranslation.Add("SULPHUR", "Sulphur");
            nameTranslation.Add("RABBIT", "Raw Rabbit");
            nameTranslation.Add("FINESAPPHIREGEM", "Fine Sapphire");
            nameTranslation.Add("NETHERSTALK", "Nether Wart");
            nameTranslation.Add("DARKBAIT", "Dark Bait");
            nameTranslation.Add("ENCHANTEDCARROT", "Enchanted Carrot");
            nameTranslation.Add("ENCHANTEDPUMPKIN", "Enchanted Pumpkin");
            nameTranslation.Add("GRIFFINFEATHER", "Griffin Feather");
            nameTranslation.Add("ROTTENFLESH", "Rotten Flesh");
            nameTranslation.Add("ENCHANTEDCOOKEDFISH", "Enchanted Cooked Fish");
            nameTranslation.Add("OBSIDIAN", "Obsidian");
            nameTranslation.Add("SOULFLOW", "Soulflow");
            nameTranslation.Add("MINNOWBAIT", "Minnow Bait");
            nameTranslation.Add("ENCHANTEDMAGMACREAM", "Enchanted Magma Cream");
            nameTranslation.Add("ENCHANTEDFIREWORKROCKET", "Enchanted Firework Rocket");
            nameTranslation.Add("STARFALL", "Starfall");
            nameTranslation.Add("FLAWLESSJADEGEM", "Flawless Jade");
            nameTranslation.Add("HARDSTONE", "Hardstone");
            nameTranslation.Add("FLAWEDTOPAZGEM", "Flawed Topaz");
            nameTranslation.Add("LEATHER", "Leather");
            nameTranslation.Add("ENCHANTEDCOOKEDMUTTON", "Enchanted Cooked Mutton");
            nameTranslation.Add("FINEAMETHYSTGEM", "Fine Amethyst");
            nameTranslation.Add("REFINEDTITANIUM", "Refined Titanium");
            nameTranslation.Add("ENCHANTEDRABBIT", "Enchanted Raw Rabbit");
            nameTranslation.Add("SOULSTRING", "Soul String");
            nameTranslation.Add("MUTANTNETHERSTALK", "Mutant Nether Wart");
            nameTranslation.Add("ENCHANTEDBREAD", "Enchanted Bread");
            nameTranslation.Add("FUMINGPOTATOBOOK", "Fuming Potato Book");
            nameTranslation.Add("FINEJASPERGEM", "Fine Jasper");
            nameTranslation.Add("ENCHANTEDCHARCOAL", "Enchanted Charcoal");
            nameTranslation.Add("FLAWEDSAPPHIREGEM", "Flawed Sapphire");
            nameTranslation.Add("FLAWLESSAMBERGEM", "Flawless Amber");
            nameTranslation.Add("ENCHANTEDBLAZEPOWDER", "Enchanted Blazepowder");
            nameTranslation.Add("SUMMONINGEYE", "Summoning Eye");
            nameTranslation.Add("PERFECTSAPPHIREGEM", "Perfect Sapphire");
            nameTranslation.Add("FISHBAIT", "Fish Bait");
            nameTranslation.Add("SNOWBLOCK", "Snow Block");
            nameTranslation.Add("ENCHANTEDBAKEDPOTATO", "Enchanted Baked Potato");
            nameTranslation.Add("COMPACTOR", "Compactor");
            nameTranslation.Add("ENCHANTEDDIAMOND", "Enchanted Diamond");
            nameTranslation.Add("BAZAARCOOKIE", "Bazaar Cookie");

            WithoutStartup();

            void WithoutStartup()
            {
                //Get JSON-String
                var JsonString = Get();
                Thread.Sleep(2000);
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(JsonString.Result);

                Console.Clear();
                Console.WriteLine("Enter way of sorting:");

                string input = Console.ReadLine().ToLower();
                //Read first input
                if (input.Equals("per coin") || input.Equals("coin") || input.Equals("percoin") || input.Equals("c"))
                {
                    test = 'a';
                    Function();
                }
                else if (input.Equals("overall") || input.Equals("all") || input.Equals("a"))
                {
                    test = 'b';
                    Function();
                }
                else
                {
                    test = 'z';
                    Retry();
                }

                void Function()
                {
                    //Get Properties
                    PropertyInfo[] properties = typeof(Products).GetProperties();

                    //Get Properties per Item
                    foreach (PropertyInfo property in properties)
                    {
                        var products = property.GetValue(myDeserializedClass.products);
                        productName = products.GetType().Name;

                        //Sell summary values
                        if (products.GetType().GetProperty("sell_summary").GetValue(products) != null)
                        {
                            var sellSummary = products.GetType().GetProperty("sell_summary").GetValue(products);

                            foreach (var foreachSellSummary in (List<SellSummary>)sellSummary)
                            {
                                var pricePerUnitSellSummary = foreachSellSummary.GetType().GetProperty("pricePerUnit");
                                productSellSummary = pricePerUnitSellSummary.GetValue(foreachSellSummary);
                                break;
                            }
                        }

                        //Buy Summary values
                        if (products.GetType().GetProperty("buy_summary").GetValue(products) != null)
                        {
                            var buySummary = products.GetType().GetProperty("buy_summary").GetValue(products);

                            foreach (var foreachBuySummary in (List<BuySummary>)buySummary)
                            {
                                var pricePerUnitBuySummary = foreachBuySummary.GetType().GetProperty("pricePerUnit");
                                productBuySummary = pricePerUnitBuySummary.GetValue(foreachBuySummary);
                                break;
                            }
                        }

                        //Quick Status values
                        if (products.GetType().GetProperty("quick_status").GetValue(products) != null)
                        {
                            var quickStatus = products.GetType().GetProperty("quick_status").GetValue(products);

                            var buyMovingWeek = quickStatus.GetType().GetProperty("buyMovingWeek");
                            var sellMovingWeek = quickStatus.GetType().GetProperty("sellMovingWeek");

                            productBuyMovingWeek = buyMovingWeek.GetValue(quickStatus);
                            productSellMovingWeek = sellMovingWeek.GetValue(quickStatus);
                        }

                        //Dict-Replacer/-Shifter
                        for (int i = 1; i <= amount; i++)
                        {
                            //Case for Profit per Coin
                            if (i < amount && (Convert.ToDouble(dict[i].productProfitPerCoin) < (Convert.ToDouble(productBuySummary) / Convert.ToDouble(productSellSummary))) && test.Equals('a'))
                            {
                                dict.Remove(amount);
                                for (int i2 = amount - 1; i2 >= i; i2--)
                                {
                                    MyValue save;
                                    save = dict[i2];
                                    dict.Remove(i2);
                                    dict.Add(i2 + 1, save);
                                }
                                dict.Add(i, productName, nameTranslation[productName.ToString()], Convert.ToDouble(productSellSummary), Convert.ToDouble(productBuySummary), String.Format("{0:0.0}", (Convert.ToDouble(productBuySummary) - Convert.ToDouble(productSellSummary))), Convert.ToInt32(productSellMovingWeek), Convert.ToInt32(productBuyMovingWeek), String.Format("{0:0.00}", (Convert.ToDouble(productBuySummary) / Convert.ToDouble(productSellSummary))));
                                break;
                            }
                            else if (i == amount && (Convert.ToDouble(dict[i].productProfitPerCoin) < (Convert.ToDouble(productBuySummary) / Convert.ToDouble(productSellSummary))) && test.Equals('a'))
                            {
                                dict.Remove(amount);
                                dict.Add(amount, productName, nameTranslation[productName.ToString()], Convert.ToDouble(productSellSummary), Convert.ToDouble(productBuySummary), String.Format("{0:0.0}", (Convert.ToDouble(productBuySummary) - Convert.ToDouble(productSellSummary))), Convert.ToInt32(productSellMovingWeek), Convert.ToInt32(productBuyMovingWeek), String.Format("{0:0.00}", (Convert.ToDouble(productBuySummary) / Convert.ToDouble(productSellSummary))));
                                break;
                            }


                            //Case for Overall Profit
                            else if (i < amount && (Convert.ToDouble(dict[i].productPriceDifferenceInDict) < (Convert.ToDouble(productBuySummary) - Convert.ToDouble(productSellSummary))) && test.Equals('b'))
                            {
                                dict.Remove(amount);
                                for (int i2 = amount - 1; i2 >= i; i2--)
                                {
                                    MyValue save;
                                    save = dict[i2];
                                    dict.Remove(i2);
                                    dict.Add(i2 + 1, save);
                                }
                                dict.Add(i, productName, nameTranslation[productName.ToString()], Convert.ToDouble(productSellSummary), Convert.ToDouble(productBuySummary), String.Format("{0:0.0}", (Convert.ToDouble(productBuySummary) - Convert.ToDouble(productSellSummary))), Convert.ToInt32(productSellMovingWeek), Convert.ToInt32(productBuyMovingWeek), String.Format("{0:0.00}", (Convert.ToDouble(productBuySummary) / Convert.ToDouble(productSellSummary))));
                                break;
                            }
                            else if (i == amount && (Convert.ToDouble(dict[i].productPriceDifferenceInDict) < (Convert.ToDouble(productBuySummary) - Convert.ToDouble(productSellSummary))) && test.Equals('b'))
                            {
                                dict.Remove(amount);
                                dict.Add(amount, productName, nameTranslation[productName.ToString()], Convert.ToDouble(productSellSummary), Convert.ToDouble(productBuySummary), String.Format("{0:0.0}", (Convert.ToDouble(productBuySummary) - Convert.ToDouble(productSellSummary))), Convert.ToInt32(productSellMovingWeek), Convert.ToInt32(productBuyMovingWeek), String.Format("{0:0.00}", (Convert.ToDouble(productBuySummary) / Convert.ToDouble(productSellSummary))));
                                break;
                            }
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("\n\n");

                    //Write Output
                    for (int i = 1; i <= amount; i++)
                    {
                        Console.WriteLine(i + ".: " + dict[i].translatedProductNameInDict + ";\n       Profit: " + dict[i].productPriceDifferenceInDict + " Coins\n" + "       Buyprice: " + dict[i].productSellPriceInDict + " Coins  (Bought last 7 days: " + dict[i].productSellMovingWeekInDict + " Items)\n" + "       Sellprice: " + dict[i].productBuyPriceInDict + " Coins  (Sold last 7 days: " + dict[i].productBuyMovingWeekInDict + " Items)\n" + "       Profit per Coin: " + dict[i].productProfitPerCoin + " Coins\n");
                    }

                    //Check which key was pressed after output
                    if (Console.ReadKey().Key.Equals(ConsoleKey.Escape))
                    {
                        Console.WriteLine("\n Shutting Down!");
                        Thread.Sleep(2000);
                    }
                    else
                        WithoutStartup();
                }

                void Retry() //Retry Function for invalid input at start
                {
                    Console.WriteLine("\nPlease enter \"Per Coin\", \"Percoin\", \"Coin\" or \"C\" for the Profit per Coin invested.\nOr enter \"Overall\", \"All\" or \"A\" for the overall Profit of the Item!\n\nProgram doesn't care about upper- or lowercase letters.\n\nProgram will restart after 10 sec!");
                    Thread.Sleep(10000);
                    WithoutStartup();
                }
            }
        }

        //Get JSON-String
        public static async Task<String> Get()
        {
            string url = $"https://api.hypixel.net/skyblock/bazaar";

            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
    }

    //*********************************************************
    //Classes for reading JSON-String
    //*********************************************************

    public class SellSummary
    {
        public int amount { get; set; }
        public double pricePerUnit { get; set; }
        public int orders { get; set; }
    }

    public class BuySummary
    {
        public int amount { get; set; }
        public double pricePerUnit { get; set; }
        public int orders { get; set; }
    }

    public class QuickStatus
    {
        public string productId { get; set; }
        public double sellPrice { get; set; }
        public int sellVolume { get; set; }
        public int sellMovingWeek { get; set; }
        public int sellOrders { get; set; }
        public double buyPrice { get; set; }
        public int buyVolume { get; set; }
        public int buyMovingWeek { get; set; }
        public int buyOrders { get; set; }
    }

    public class INKSACK3
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BROWNMUSHROOM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SPOOKYSHARD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class INKSACK4
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TARANTULAWEB
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CARROTITEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPOTATO
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class EXPBOTTLE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class JERRYBOXGREEN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSLIMEBALL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGOLDENCARROT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDREDMUSHROOM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRABBITHIDE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDAMETHYSTGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTJADEGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBIRCHLOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGUNPOWDER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDMELON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSUGAR
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CACTUS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBLAZEROD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDJASPERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCAKE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PUMPKIN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBROWNMUSHROOM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOBLINEGGYELLOW
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WHEAT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDAMBERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class NURSESHARKTOOTH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRAWSALMON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGLISTERINGMELON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PRISMARINESHARD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PROTECTORFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDEMERALD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSPIDEREYE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REDMUSHROOM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GRANDEXPBOTTLE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDMELONBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MUTTON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class POWERCRYSTAL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWSOULFLOW
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class DIAMOND
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SHARKFIN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WISEFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class COBBLESTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REFINEDMITHRIL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWFISH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SPIDEREYE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTRUBYGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPUFFERFISH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class YOGGIE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTJASPERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class POTATOITEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDNETHERRACK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDHARDSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDHUGEMUSHROOM1
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REFINEDDIAMOND
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOBBLESTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TIGHTLYTIEDHAYBALE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDHUGEMUSHROOM2
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PORK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PRISMARINECRYSTALS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ICE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HUGEMUSHROOM1
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TIGERSHARKTOOTH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HUGEMUSHROOM2
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ICEBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LOG21
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSNOWBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class STRING
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOLDENTOOTH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CHEESEFUEL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HYPERCATALYST
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RABBITFOOT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REDSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class JERRYBOXGOLDEN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PUMPKINGUTS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCACTUSGREEN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BOOSTERCOOKIE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCARROTONASTICK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDLAPISLAZULIBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDENDSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOOKIE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSAND
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class COLOSSALEXPBOTTLE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSTRING
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class STRONGFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SLIMEBALL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDACACIALOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SNOWBALL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HOLYFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDEGG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SAND
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SOULFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDRUBYGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINEJADEGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWCHICKEN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PLASMABUCKET
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSJASPERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ANCIENTCLAW
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDLAPISLAZULI
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGHASTTEAR
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOCOA
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CARROTBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINETOPAZGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SEEDS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINERUBYGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDLEATHER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSHARKFIN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSPONGE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTAMBERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HAYBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class INKSACK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLINT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDROTTENFLESH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WOLFTOOTH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSPRUCELOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGRILLEDPORK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDNETHERSTALK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDREDSTONEBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDQUARTZBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDANCIENTCLAW
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GREENCANDY
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDREDSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDREDSTONELAMP
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TREASURITE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class DWARVENCOMPACTOR
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GREATWHITESHARKTOOTH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GRAVEL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MELON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDLAVABUCKET
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPACKEDICE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWFISH3
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPRISMARINESHARD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDIRONBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RECOMBOBULATOR3000
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCARROTSTICK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWFISH2
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWFISH1
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REVENANTFLESH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGLOWSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPORK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOBLINEGGRED
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHJASPERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FEATHER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WHALEBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class NETHERRACK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SPONGE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BLAZEROD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDDARKOAKLOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSTOPAZGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class YOUNGFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCLOWNFISH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REFINEDMINERAL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGOLD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRAWCHICKEN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDWATERLILY
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHAMETHYSTGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHRUBYGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOBLINEGGBLUE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LOG1
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSRUBYGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class NULLATOM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TITANIUMORE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CATALYST
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BLUESHARKTOOTH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LOG3
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LOG2
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BLESSEDBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGLOWSTONEDUST
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDINKSACK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCACTUS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSUGARCANE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSSAPPHIREGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOOKEDSALMON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSEEDS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CONCENTRATEDSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class JACOBSTICKET
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBONEBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GHASTTEAR
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ABSOLUTEENDERPEARL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDENDERPEARL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class UNSTABLEFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PURPLECANDY
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SPIKEDBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class POLISHEDPUMPKIN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDFERMENTEDSPIDEREYE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDGOLDBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHJADEGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDJUNGLELOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDFLINT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class IRONINGOT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDEMERALDBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class NULLOVOID
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCLAYBALL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHSAPPHIREGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GLOWSTONEDUST
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOLDINGOT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REVENANTVISCERA
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTAMETHYSTGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TARANTULASILK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class TITANICEXPBOTTLE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDMUTTON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class NULLSPHERE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDIRON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SUPERCOMPACTOR3000
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SUPEREGG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class STOCKOFSTONKS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MITHRILORE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDHAYBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPAPER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDTITANIUM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDDIAMONDBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SPOOKYBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SUPERIORFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MAGMABUCKET
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class EMERALD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOBLINEGGGREEN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRABBITFOOT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LIGHTBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HOTPOTATOBOOK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDICE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class CLAYBALL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ARACHNEKEEPERFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class OLDFRAGMENT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GREENGIFT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WORMMEMBRANE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSAMETHYSTGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHTOPAZGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PACKEDICE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROUGHAMBERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WATERLILY
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LOG_2
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HAMSTERWHEEL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDOBSIDIAN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINEAMBERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOAL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDQUARTZ
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class COAL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENDERPEARL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOALBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WEREWOLFSKIN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTTOPAZGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GOBLINEGG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPRISMARINECRYSTALS
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class DAEDALUSSTICK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDWETSPONGE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDJADEGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRAWFISH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENDERSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FOULFLESH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class QUARTZ
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class JERRYBOXPURPLE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RAWBEEF
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SLUDGEJUICE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDEYEOFENDER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ECTOPLASM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MAGMACREAM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SUGARCANE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SHARKBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDMITHRIL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REDGIFT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class JERRYBOXBLUE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRAWBEEF
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDSLIMEBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDFEATHER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDOAKLOG
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RABBITHIDE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class WHITEGIFT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SULPHUR
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class RABBIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINESAPPHIREGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class NETHERSTALK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class DARKBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCARROT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDPUMPKIN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class GRIFFINFEATHER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ROTTENFLESH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOOKEDFISH
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class OBSIDIAN
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SOULFLOW
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MINNOWBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDMAGMACREAM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDFIREWORKROCKET
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class STARFALL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSJADEGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class HARDSTONE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDTOPAZGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class LEATHER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCOOKEDMUTTON
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINEAMETHYSTGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class REFINEDTITANIUM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDRABBIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SOULSTRING
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class MUTANTNETHERSTALK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBREAD
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FUMINGPOTATOBOOK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FINEJASPERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDCHARCOAL
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWEDSAPPHIREGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FLAWLESSAMBERGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBLAZEPOWDER
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SUMMONINGEYE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class PERFECTSAPPHIREGEM
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class FISHBAIT
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class SNOWBLOCK
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDBAKEDPOTATO
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class COMPACTOR
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class ENCHANTEDDIAMOND
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class BAZAARCOOKIE
    {
        public string product_id { get; set; }
        public List<SellSummary> sell_summary { get; set; }
        public List<BuySummary> buy_summary { get; set; }
        public QuickStatus quick_status { get; set; }
    }

    public class Products
    {
        [JsonProperty("INK_SACK:3")]
        public INKSACK3 INKSACK3 { get; set; }
        public BROWNMUSHROOM BROWN_MUSHROOM { get; set; }
        public SPOOKYSHARD SPOOKY_SHARD { get; set; }

        [JsonProperty("INK_SACK:4")]
        public INKSACK4 INKSACK4 { get; set; }
        public TARANTULAWEB TARANTULA_WEB { get; set; }
        public CARROTITEM CARROT_ITEM { get; set; }
        public ENCHANTEDPOTATO ENCHANTED_POTATO { get; set; }
        public EXPBOTTLE EXP_BOTTLE { get; set; }
        public JERRYBOXGREEN JERRY_BOX_GREEN { get; set; }
        public ENCHANTEDSLIMEBALL ENCHANTED_SLIME_BALL { get; set; }
        public ENCHANTEDGOLDENCARROT ENCHANTED_GOLDEN_CARROT { get; set; }
        public ENCHANTEDREDMUSHROOM ENCHANTED_RED_MUSHROOM { get; set; }
        public ENCHANTEDRABBITHIDE ENCHANTED_RABBIT_HIDE { get; set; }
        public FLAWEDAMETHYSTGEM FLAWED_AMETHYST_GEM { get; set; }
        public PERFECTJADEGEM PERFECT_JADE_GEM { get; set; }
        public ENCHANTEDBIRCHLOG ENCHANTED_BIRCH_LOG { get; set; }
        public ENCHANTEDGUNPOWDER ENCHANTED_GUNPOWDER { get; set; }
        public ENCHANTEDMELON ENCHANTED_MELON { get; set; }
        public ENCHANTEDSUGAR ENCHANTED_SUGAR { get; set; }
        public CACTUS CACTUS { get; set; }
        public ENCHANTEDBLAZEROD ENCHANTED_BLAZE_ROD { get; set; }
        public FLAWEDJASPERGEM FLAWED_JASPER_GEM { get; set; }
        public ENCHANTEDCAKE ENCHANTED_CAKE { get; set; }
        public PUMPKIN PUMPKIN { get; set; }
        public ENCHANTEDBROWNMUSHROOM ENCHANTED_BROWN_MUSHROOM { get; set; }
        public GOBLINEGGYELLOW GOBLIN_EGG_YELLOW { get; set; }
        public WHEAT WHEAT { get; set; }
        public FLAWEDAMBERGEM FLAWED_AMBER_GEM { get; set; }
        public NURSESHARKTOOTH NURSE_SHARK_TOOTH { get; set; }
        public ENCHANTEDRAWSALMON ENCHANTED_RAW_SALMON { get; set; }
        public ENCHANTEDGLISTERINGMELON ENCHANTED_GLISTERING_MELON { get; set; }
        public PRISMARINESHARD PRISMARINE_SHARD { get; set; }
        public PROTECTORFRAGMENT PROTECTOR_FRAGMENT { get; set; }
        public ENCHANTEDEMERALD ENCHANTED_EMERALD { get; set; }
        public ENCHANTEDSPIDEREYE ENCHANTED_SPIDER_EYE { get; set; }
        public REDMUSHROOM RED_MUSHROOM { get; set; }
        public GRANDEXPBOTTLE GRAND_EXP_BOTTLE { get; set; }
        public ENCHANTEDMELONBLOCK ENCHANTED_MELON_BLOCK { get; set; }
        public MUTTON MUTTON { get; set; }
        public POWERCRYSTAL POWER_CRYSTAL { get; set; }
        public RAWSOULFLOW RAW_SOULFLOW { get; set; }
        public DIAMOND DIAMOND { get; set; }
        public SHARKFIN SHARK_FIN { get; set; }
        public WISEFRAGMENT WISE_FRAGMENT { get; set; }
        public COBBLESTONE COBBLESTONE { get; set; }
        public REFINEDMITHRIL REFINED_MITHRIL { get; set; }
        public RAWFISH RAW_FISH { get; set; }
        public SPIDEREYE SPIDER_EYE { get; set; }
        public PERFECTRUBYGEM PERFECT_RUBY_GEM { get; set; }
        public ENCHANTEDPUFFERFISH ENCHANTED_PUFFERFISH { get; set; }
        public YOGGIE YOGGIE { get; set; }
        public PERFECTJASPERGEM PERFECT_JASPER_GEM { get; set; }
        public POTATOITEM POTATO_ITEM { get; set; }
        public ENCHANTEDNETHERRACK ENCHANTED_NETHERRACK { get; set; }
        public ENCHANTEDHARDSTONE ENCHANTED_HARD_STONE { get; set; }
        public ENCHANTEDHUGEMUSHROOM1 ENCHANTED_HUGE_MUSHROOM_1 { get; set; }
        public REFINEDDIAMOND REFINED_DIAMOND { get; set; }
        public ENCHANTEDCOBBLESTONE ENCHANTED_COBBLESTONE { get; set; }
        public TIGHTLYTIEDHAYBALE TIGHTLY_TIED_HAY_BALE { get; set; }
        public ENCHANTEDHUGEMUSHROOM2 ENCHANTED_HUGE_MUSHROOM_2 { get; set; }
        public PORK PORK { get; set; }
        public PRISMARINECRYSTALS PRISMARINE_CRYSTALS { get; set; }
        public ICE ICE { get; set; }
        public HUGEMUSHROOM1 HUGE_MUSHROOM_1 { get; set; }
        public TIGERSHARKTOOTH TIGER_SHARK_TOOTH { get; set; }
        public HUGEMUSHROOM2 HUGE_MUSHROOM_2 { get; set; }
        public ICEBAIT ICE_BAIT { get; set; }

        [JsonProperty("LOG_2:1")]
        public LOG21 LOG21 { get; set; }
        public ENCHANTEDSNOWBLOCK ENCHANTED_SNOW_BLOCK { get; set; }
        public STRING STRING { get; set; }
        public GOLDENTOOTH GOLDEN_TOOTH { get; set; }
        public CHEESEFUEL CHEESE_FUEL { get; set; }
        public HYPERCATALYST HYPER_CATALYST { get; set; }
        public RABBITFOOT RABBIT_FOOT { get; set; }
        public REDSTONE REDSTONE { get; set; }
        public JERRYBOXGOLDEN JERRY_BOX_GOLDEN { get; set; }
        public PUMPKINGUTS PUMPKIN_GUTS { get; set; }
        public ENCHANTEDCACTUSGREEN ENCHANTED_CACTUS_GREEN { get; set; }
        public BOOSTERCOOKIE BOOSTER_COOKIE { get; set; }
        public ENCHANTEDCARROTONASTICK ENCHANTED_CARROT_ON_A_STICK { get; set; }
        public ENCHANTEDLAPISLAZULIBLOCK ENCHANTED_LAPIS_LAZULI_BLOCK { get; set; }
        public ENCHANTEDENDSTONE ENCHANTED_ENDSTONE { get; set; }
        public ENCHANTEDCOOKIE ENCHANTED_COOKIE { get; set; }
        public ENCHANTEDSAND ENCHANTED_SAND { get; set; }
        public COLOSSALEXPBOTTLE COLOSSAL_EXP_BOTTLE { get; set; }
        public ENCHANTEDSTRING ENCHANTED_STRING { get; set; }
        public STRONGFRAGMENT STRONG_FRAGMENT { get; set; }
        public SLIMEBALL SLIME_BALL { get; set; }
        public ENCHANTEDACACIALOG ENCHANTED_ACACIA_LOG { get; set; }
        public SNOWBALL SNOW_BALL { get; set; }
        public HOLYFRAGMENT HOLY_FRAGMENT { get; set; }
        public ENCHANTEDEGG ENCHANTED_EGG { get; set; }
        public SAND SAND { get; set; }
        public SOULFRAGMENT SOUL_FRAGMENT { get; set; }
        public FLAWEDRUBYGEM FLAWED_RUBY_GEM { get; set; }
        public FINEJADEGEM FINE_JADE_GEM { get; set; }
        public RAWCHICKEN RAW_CHICKEN { get; set; }
        public PLASMABUCKET PLASMA_BUCKET { get; set; }
        public FLAWLESSJASPERGEM FLAWLESS_JASPER_GEM { get; set; }
        public ANCIENTCLAW ANCIENT_CLAW { get; set; }
        public ENCHANTEDLAPISLAZULI ENCHANTED_LAPIS_LAZULI { get; set; }
        public ENCHANTEDGHASTTEAR ENCHANTED_GHAST_TEAR { get; set; }
        public ENCHANTEDCOCOA ENCHANTED_COCOA { get; set; }
        public CARROTBAIT CARROT_BAIT { get; set; }
        public FINETOPAZGEM FINE_TOPAZ_GEM { get; set; }
        public SEEDS SEEDS { get; set; }
        public FINERUBYGEM FINE_RUBY_GEM { get; set; }
        public ENCHANTEDLEATHER ENCHANTED_LEATHER { get; set; }
        public ENCHANTEDSHARKFIN ENCHANTED_SHARK_FIN { get; set; }
        public ENCHANTEDSPONGE ENCHANTED_SPONGE { get; set; }
        public PERFECTAMBERGEM PERFECT_AMBER_GEM { get; set; }
        public HAYBLOCK HAY_BLOCK { get; set; }
        public INKSACK INK_SACK { get; set; }
        public FLINT FLINT { get; set; }
        public ENCHANTEDROTTENFLESH ENCHANTED_ROTTEN_FLESH { get; set; }
        public WOLFTOOTH WOLF_TOOTH { get; set; }
        public ENCHANTEDSPRUCELOG ENCHANTED_SPRUCE_LOG { get; set; }
        public ENCHANTEDGRILLEDPORK ENCHANTED_GRILLED_PORK { get; set; }
        public ENCHANTEDNETHERSTALK ENCHANTED_NETHER_STALK { get; set; }
        public ENCHANTEDREDSTONEBLOCK ENCHANTED_REDSTONE_BLOCK { get; set; }
        public ENCHANTEDQUARTZBLOCK ENCHANTED_QUARTZ_BLOCK { get; set; }
        public ENCHANTEDANCIENTCLAW ENCHANTED_ANCIENT_CLAW { get; set; }
        public GREENCANDY GREEN_CANDY { get; set; }
        public ENCHANTEDREDSTONE ENCHANTED_REDSTONE { get; set; }
        public ENCHANTEDREDSTONELAMP ENCHANTED_REDSTONE_LAMP { get; set; }
        public TREASURITE TREASURITE { get; set; }
        public DWARVENCOMPACTOR DWARVEN_COMPACTOR { get; set; }
        public GREATWHITESHARKTOOTH GREAT_WHITE_SHARK_TOOTH { get; set; }
        public GRAVEL GRAVEL { get; set; }
        public MELON MELON { get; set; }
        public ENCHANTEDLAVABUCKET ENCHANTED_LAVA_BUCKET { get; set; }
        public ENCHANTEDPACKEDICE ENCHANTED_PACKED_ICE { get; set; }

        [JsonProperty("RAW_FISH:3")]
        public RAWFISH3 RAWFISH3 { get; set; }
        public ENCHANTEDPRISMARINESHARD ENCHANTED_PRISMARINE_SHARD { get; set; }
        public ENCHANTEDIRONBLOCK ENCHANTED_IRON_BLOCK { get; set; }
        public RECOMBOBULATOR3000 RECOMBOBULATOR_3000 { get; set; }
        public ENCHANTEDCARROTSTICK ENCHANTED_CARROT_STICK { get; set; }
        public BONE BONE { get; set; }

        [JsonProperty("RAW_FISH:2")]
        public RAWFISH2 RAWFISH2 { get; set; }

        [JsonProperty("RAW_FISH:1")]
        public RAWFISH1 RAWFISH1 { get; set; }
        public REVENANTFLESH REVENANT_FLESH { get; set; }
        public ENCHANTEDGLOWSTONE ENCHANTED_GLOWSTONE { get; set; }
        public ENCHANTEDPORK ENCHANTED_PORK { get; set; }
        public GOBLINEGGRED GOBLIN_EGG_RED { get; set; }
        public ROUGHJASPERGEM ROUGH_JASPER_GEM { get; set; }
        public FEATHER FEATHER { get; set; }
        public WHALEBAIT WHALE_BAIT { get; set; }
        public NETHERRACK NETHERRACK { get; set; }
        public SPONGE SPONGE { get; set; }
        public BLAZEROD BLAZE_ROD { get; set; }
        public ENCHANTEDDARKOAKLOG ENCHANTED_DARK_OAK_LOG { get; set; }
        public FLAWLESSTOPAZGEM FLAWLESS_TOPAZ_GEM { get; set; }
        public YOUNGFRAGMENT YOUNG_FRAGMENT { get; set; }
        public ENCHANTEDCLOWNFISH ENCHANTED_CLOWNFISH { get; set; }
        public REFINEDMINERAL REFINED_MINERAL { get; set; }
        public ENCHANTEDGOLD ENCHANTED_GOLD { get; set; }
        public ENCHANTEDRAWCHICKEN ENCHANTED_RAW_CHICKEN { get; set; }
        public ENCHANTEDWATERLILY ENCHANTED_WATER_LILY { get; set; }
        public ROUGHAMETHYSTGEM ROUGH_AMETHYST_GEM { get; set; }
        public ROUGHRUBYGEM ROUGH_RUBY_GEM { get; set; }
        public GOBLINEGGBLUE GOBLIN_EGG_BLUE { get; set; }

        [JsonProperty("LOG:1")]
        public LOG1 LOG1 { get; set; }
        public FLAWLESSRUBYGEM FLAWLESS_RUBY_GEM { get; set; }
        public NULLATOM NULL_ATOM { get; set; }
        public TITANIUMORE TITANIUM_ORE { get; set; }
        public CATALYST CATALYST { get; set; }
        public BLUESHARKTOOTH BLUE_SHARK_TOOTH { get; set; }

        [JsonProperty("LOG:3")]
        public LOG3 LOG3 { get; set; }

        [JsonProperty("LOG:2")]
        public LOG2 LOG2 { get; set; }
        public BLESSEDBAIT BLESSED_BAIT { get; set; }
        public ENCHANTEDGLOWSTONEDUST ENCHANTED_GLOWSTONE_DUST { get; set; }
        public ENCHANTEDINKSACK ENCHANTED_INK_SACK { get; set; }
        public ENCHANTEDCACTUS ENCHANTED_CACTUS { get; set; }
        public ENCHANTEDSUGARCANE ENCHANTED_SUGAR_CANE { get; set; }
        public FLAWLESSSAPPHIREGEM FLAWLESS_SAPPHIRE_GEM { get; set; }
        public ENCHANTEDCOOKEDSALMON ENCHANTED_COOKED_SALMON { get; set; }
        public ENCHANTEDSEEDS ENCHANTED_SEEDS { get; set; }
        public CONCENTRATEDSTONE CONCENTRATED_STONE { get; set; }
        public LOG LOG { get; set; }
        public JACOBSTICKET JACOBS_TICKET { get; set; }
        public ENCHANTEDBONEBLOCK ENCHANTED_BONE_BLOCK { get; set; }
        public GHASTTEAR GHAST_TEAR { get; set; }
        public ABSOLUTEENDERPEARL ABSOLUTE_ENDER_PEARL { get; set; }
        public ENCHANTEDENDERPEARL ENCHANTED_ENDER_PEARL { get; set; }
        public UNSTABLEFRAGMENT UNSTABLE_FRAGMENT { get; set; }
        public PURPLECANDY PURPLE_CANDY { get; set; }
        public SPIKEDBAIT SPIKED_BAIT { get; set; }
        public POLISHEDPUMPKIN POLISHED_PUMPKIN { get; set; }
        public ENCHANTEDFERMENTEDSPIDEREYE ENCHANTED_FERMENTED_SPIDER_EYE { get; set; }
        public ENCHANTEDGOLDBLOCK ENCHANTED_GOLD_BLOCK { get; set; }
        public ROUGHJADEGEM ROUGH_JADE_GEM { get; set; }
        public ENCHANTEDJUNGLELOG ENCHANTED_JUNGLE_LOG { get; set; }
        public ENCHANTEDFLINT ENCHANTED_FLINT { get; set; }
        public IRONINGOT IRON_INGOT { get; set; }
        public ENCHANTEDEMERALDBLOCK ENCHANTED_EMERALD_BLOCK { get; set; }
        public NULLOVOID NULL_OVOID { get; set; }
        public ENCHANTEDCLAYBALL ENCHANTED_CLAY_BALL { get; set; }
        public ROUGHSAPPHIREGEM ROUGH_SAPPHIRE_GEM { get; set; }
        public GLOWSTONEDUST GLOWSTONE_DUST { get; set; }
        public GOLDINGOT GOLD_INGOT { get; set; }
        public REVENANTVISCERA REVENANT_VISCERA { get; set; }
        public PERFECTAMETHYSTGEM PERFECT_AMETHYST_GEM { get; set; }
        public TARANTULASILK TARANTULA_SILK { get; set; }
        public TITANICEXPBOTTLE TITANIC_EXP_BOTTLE { get; set; }
        public ENCHANTEDMUTTON ENCHANTED_MUTTON { get; set; }
        public NULLSPHERE NULL_SPHERE { get; set; }
        public ENCHANTEDIRON ENCHANTED_IRON { get; set; }
        public SUPERCOMPACTOR3000 SUPER_COMPACTOR_3000 { get; set; }
        public SUPEREGG SUPER_EGG { get; set; }
        public STOCKOFSTONKS STOCK_OF_STONKS { get; set; }
        public MITHRILORE MITHRIL_ORE { get; set; }
        public ENCHANTEDHAYBLOCK ENCHANTED_HAY_BLOCK { get; set; }
        public ENCHANTEDBONE ENCHANTED_BONE { get; set; }
        public ENCHANTEDPAPER ENCHANTED_PAPER { get; set; }
        public ENCHANTEDTITANIUM ENCHANTED_TITANIUM { get; set; }
        public ENCHANTEDDIAMONDBLOCK ENCHANTED_DIAMOND_BLOCK { get; set; }
        public SPOOKYBAIT SPOOKY_BAIT { get; set; }
        public SUPERIORFRAGMENT SUPERIOR_FRAGMENT { get; set; }
        public MAGMABUCKET MAGMA_BUCKET { get; set; }
        public EMERALD EMERALD { get; set; }
        public GOBLINEGGGREEN GOBLIN_EGG_GREEN { get; set; }
        public ENCHANTEDRABBITFOOT ENCHANTED_RABBIT_FOOT { get; set; }
        public LIGHTBAIT LIGHT_BAIT { get; set; }
        public HOTPOTATOBOOK HOT_POTATO_BOOK { get; set; }
        public ENCHANTEDICE ENCHANTED_ICE { get; set; }
        public CLAYBALL CLAY_BALL { get; set; }
        public ARACHNEKEEPERFRAGMENT ARACHNE_KEEPER_FRAGMENT { get; set; }
        public OLDFRAGMENT OLD_FRAGMENT { get; set; }
        public GREENGIFT GREEN_GIFT { get; set; }
        public WORMMEMBRANE WORM_MEMBRANE { get; set; }
        public FLAWLESSAMETHYSTGEM FLAWLESS_AMETHYST_GEM { get; set; }
        public ROUGHTOPAZGEM ROUGH_TOPAZ_GEM { get; set; }
        public PACKEDICE PACKED_ICE { get; set; }
        public ROUGHAMBERGEM ROUGH_AMBER_GEM { get; set; }
        public WATERLILY WATER_LILY { get; set; }
        public LOG2 LOG_2 { get; set; }
        public HAMSTERWHEEL HAMSTER_WHEEL { get; set; }
        public ENCHANTEDOBSIDIAN ENCHANTED_OBSIDIAN { get; set; }
        public FINEAMBERGEM FINE_AMBER_GEM { get; set; }
        public ENCHANTEDCOAL ENCHANTED_COAL { get; set; }
        public ENCHANTEDQUARTZ ENCHANTED_QUARTZ { get; set; }
        public COAL COAL { get; set; }
        public ENDERPEARL ENDER_PEARL { get; set; }
        public ENCHANTEDCOALBLOCK ENCHANTED_COAL_BLOCK { get; set; }
        public WEREWOLFSKIN WEREWOLF_SKIN { get; set; }
        public PERFECTTOPAZGEM PERFECT_TOPAZ_GEM { get; set; }
        public GOBLINEGG GOBLIN_EGG { get; set; }
        public ENCHANTEDPRISMARINECRYSTALS ENCHANTED_PRISMARINE_CRYSTALS { get; set; }
        public DAEDALUSSTICK DAEDALUS_STICK { get; set; }
        public ENCHANTEDWETSPONGE ENCHANTED_WET_SPONGE { get; set; }
        public FLAWEDJADEGEM FLAWED_JADE_GEM { get; set; }
        public ENCHANTEDRAWFISH ENCHANTED_RAW_FISH { get; set; }
        public ENDERSTONE ENDER_STONE { get; set; }
        public FOULFLESH FOUL_FLESH { get; set; }
        public QUARTZ QUARTZ { get; set; }
        public JERRYBOXPURPLE JERRY_BOX_PURPLE { get; set; }
        public RAWBEEF RAW_BEEF { get; set; }
        public SLUDGEJUICE SLUDGE_JUICE { get; set; }
        public ENCHANTEDEYEOFENDER ENCHANTED_EYE_OF_ENDER { get; set; }
        public ECTOPLASM ECTOPLASM { get; set; }
        public MAGMACREAM MAGMA_CREAM { get; set; }
        public SUGARCANE SUGAR_CANE { get; set; }
        public SHARKBAIT SHARK_BAIT { get; set; }
        public ENCHANTEDMITHRIL ENCHANTED_MITHRIL { get; set; }
        public REDGIFT RED_GIFT { get; set; }
        public JERRYBOXBLUE JERRY_BOX_BLUE { get; set; }
        public ENCHANTEDRAWBEEF ENCHANTED_RAW_BEEF { get; set; }
        public ENCHANTEDSLIMEBLOCK ENCHANTED_SLIME_BLOCK { get; set; }
        public ENCHANTEDFEATHER ENCHANTED_FEATHER { get; set; }
        public ENCHANTEDOAKLOG ENCHANTED_OAK_LOG { get; set; }
        public RABBITHIDE RABBIT_HIDE { get; set; }
        public WHITEGIFT WHITE_GIFT { get; set; }
        public SULPHUR SULPHUR { get; set; }
        public RABBIT RABBIT { get; set; }
        public FINESAPPHIREGEM FINE_SAPPHIRE_GEM { get; set; }
        public NETHERSTALK NETHER_STALK { get; set; }
        public DARKBAIT DARK_BAIT { get; set; }
        public ENCHANTEDCARROT ENCHANTED_CARROT { get; set; }
        public ENCHANTEDPUMPKIN ENCHANTED_PUMPKIN { get; set; }
        public GRIFFINFEATHER GRIFFIN_FEATHER { get; set; }
        public ROTTENFLESH ROTTEN_FLESH { get; set; }
        public ENCHANTEDCOOKEDFISH ENCHANTED_COOKED_FISH { get; set; }
        public OBSIDIAN OBSIDIAN { get; set; }
        public SOULFLOW SOULFLOW { get; set; }
        public MINNOWBAIT MINNOW_BAIT { get; set; }
        public ENCHANTEDMAGMACREAM ENCHANTED_MAGMA_CREAM { get; set; }
        public ENCHANTEDFIREWORKROCKET ENCHANTED_FIREWORK_ROCKET { get; set; }
        public STARFALL STARFALL { get; set; }
        public FLAWLESSJADEGEM FLAWLESS_JADE_GEM { get; set; }
        public HARDSTONE HARD_STONE { get; set; }
        public FLAWEDTOPAZGEM FLAWED_TOPAZ_GEM { get; set; }
        public LEATHER LEATHER { get; set; }
        public ENCHANTEDCOOKEDMUTTON ENCHANTED_COOKED_MUTTON { get; set; }
        public FINEAMETHYSTGEM FINE_AMETHYST_GEM { get; set; }
        public REFINEDTITANIUM REFINED_TITANIUM { get; set; }
        public ENCHANTEDRABBIT ENCHANTED_RABBIT { get; set; }
        public SOULSTRING SOUL_STRING { get; set; }
        public MUTANTNETHERSTALK MUTANT_NETHER_STALK { get; set; }
        public ENCHANTEDBREAD ENCHANTED_BREAD { get; set; }
        public FUMINGPOTATOBOOK FUMING_POTATO_BOOK { get; set; }
        public FINEJASPERGEM FINE_JASPER_GEM { get; set; }
        public ENCHANTEDCHARCOAL ENCHANTED_CHARCOAL { get; set; }
        public FLAWEDSAPPHIREGEM FLAWED_SAPPHIRE_GEM { get; set; }
        public FLAWLESSAMBERGEM FLAWLESS_AMBER_GEM { get; set; }
        public ENCHANTEDBLAZEPOWDER ENCHANTED_BLAZE_POWDER { get; set; }
        public SUMMONINGEYE SUMMONING_EYE { get; set; }
        public PERFECTSAPPHIREGEM PERFECT_SAPPHIRE_GEM { get; set; }
        public FISHBAIT FISH_BAIT { get; set; }
        public SNOWBLOCK SNOW_BLOCK { get; set; }
        public ENCHANTEDBAKEDPOTATO ENCHANTED_BAKED_POTATO { get; set; }
        public COMPACTOR COMPACTOR { get; set; }
        public ENCHANTEDDIAMOND ENCHANTED_DIAMOND { get; set; }
        public BAZAARCOOKIE BAZAAR_COOKIE { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public long lastUpdated { get; set; }
        public Products products { get; set; }
    }
}
