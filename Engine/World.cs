using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Enums;
using Engine.Factories;
using Engine.Interfaces;

namespace Engine
{
    public class World
    {
        private static readonly IList<IItem> _items = new List<IItem>();
        private static readonly List<Monster> _monsters = new List<Monster>();
        private static readonly List<Quest> _quests = new List<Quest>();
        private static readonly List<Location> _locations = new List<Location>();

        private static IItemFactory itemFactory = new ItemFactory();


        public const int UNSELLABLE_ITEM_PRICE = -1;


        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;
        public const int MONSTER_ID_DRUNK_IDIOT = 4;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;



        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            //new Weapon((int)ItemId.RustySword, "Rusty sword", "Rusty swords", 0, 5, 5)
            _items.Add(itemFactory.CreateItem("Weapon", new object[] { (int)ItemId.RustySword, "Rusty sword", "Rusty swords", 0, 5, 5 }));
            _items.Add(new JunkItem((int)ItemId.RatTail, "Rat tail", "Rat tails", 1));
            _items.Add(new JunkItem((int)ItemId.PieceOfFur, "Piece of fur", "Pieces of fur", 1));
            _items.Add(new JunkItem((int)ItemId.SnakeFang, "Snake fang", "Snake fangs", 2));
            _items.Add(new JunkItem((int)ItemId.Snakeskin, "Snakeskin", "Snakeskins", 3));
            _items.Add(new Weapon((int)ItemId.Club, "Club", "Clubs", 3, 10, 10));
            _items.Add(new HealingPotion((int)ItemId.HealingPotion, "Healing potion", "Healing potions", 5, 3));
            _items.Add(new JunkItem((int)ItemId.SpiderFang, "Spider fang", "Spider fangs", 1));
            _items.Add(new JunkItem((int)ItemId.SpiderSilk, "Spider silk", "Spider silks", 1));
            _items.Add(new JunkItem((int)ItemId.AdventurerPass, "Adventurer pass", "Adventurer passes", UNSELLABLE_ITEM_PRICE));
            _items.Add(new JunkItem((int)ItemId.BottleOfRom, "Bottle of rom", "Bottles of rom", 2));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 5, 3, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID((int)ItemId.RatTail), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID((int)ItemId.PieceOfFur), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 5, 3, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID((int)ItemId.SnakeFang), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID((int)ItemId.Snakeskin), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID((int)ItemId.SpiderFang), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID((int)ItemId.SpiderSilk), 25, false));

            Monster drunkIdiot = new Monster(MONSTER_ID_DRUNK_IDIOT, "Drunk idiot", 6, 10, 15, 8, 10);
            drunkIdiot.LootTable.Add(new LootItem(ItemByID((int)ItemId.BottleOfRom), 75, true));

            _monsters.Add(rat);
            _monsters.Add(snake);
            _monsters.Add(giantSpider);
            _monsters.Add(drunkIdiot);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID((int)ItemId.RatTail), 3));

            clearAlchemistGarden.RewardItem = ItemByID((int)ItemId.HealingPotion);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID((int)ItemId.SnakeFang), 3));

            clearFarmersField.RewardItem = ItemByID((int)ItemId.AdventurerPass);

            _quests.Add(clearAlchemistGarden);
            _quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.");
            Vendor bobTheRatCatcher = new Vendor("Bob the Rat-Catcher");
            bobTheRatCatcher.AddItemToInventory(ItemByID((int)ItemId.PieceOfFur), 5);
            bobTheRatCatcher.AddItemToInventory(ItemByID((int)ItemId.RatTail), 3); 
            bobTheRatCatcher.AddItemToInventory(ItemByID((int)ItemId.RustySword), 3);
            bobTheRatCatcher.AddItemToInventory(ItemByID((int)ItemId.BottleOfRom), 2);
            townSquare.VendorWorkingHere = bobTheRatCatcher;

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.");
            alchemistsGarden.AddMonster(MONSTER_ID_RAT, 60);
            alchemistsGarden.AddMonster(MONSTER_ID_SNAKE, 40);


            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.");
            farmersField.AddMonster(MONSTER_ID_SNAKE, 100);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", ItemByID((int)ItemId.AdventurerPass));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.");
            farmersField.AddMonster(MONSTER_ID_DRUNK_IDIOT, 100);

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.");
            spiderField.AddMonster(MONSTER_ID_GIANT_SPIDER, 100);

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            _locations.Add(home);
            _locations.Add(townSquare);
            _locations.Add(guardPost);
            _locations.Add(alchemistHut);
            _locations.Add(alchemistsGarden);
            _locations.Add(farmhouse);
            _locations.Add(farmersField);
            _locations.Add(bridge);
            _locations.Add(spiderField);
        }

        public static IItem ItemByID(int id)
        {
            return _items.SingleOrDefault(x => x.ID == id);
        }

        public static Monster MonsterByID(int id)
        {
            return _monsters.SingleOrDefault(x => x.ID == id);
        }

        public static Quest QuestByID(int id)
        {
            return _quests.SingleOrDefault(x => x.ID == id);
        }

        public static Location LocationByID(int id)
        {
            return _locations.SingleOrDefault(x => x.ID == id);
        }
    }
}
