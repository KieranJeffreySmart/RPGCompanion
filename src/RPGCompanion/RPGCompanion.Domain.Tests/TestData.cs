using RPGCompanion.Domain.Abstract;
using RPGCompanion.Domain.Model;
using System.Collections.Generic;

namespace RPGCompanion.Domain.Tests
{
    public class TestData
    {
        public class SteveJacksonContext : Context
        {
            public SteveJacksonContext() : base(new Name("Steve Jackson"))
            {
                Characters.AddRange(SteveJacksonCharacters);
                UnitTypes.AddRange(SteveJacksonUnitTypes);
                ItemTypes.AddRange(SteveJacksonItemTypes);
                Things.AddRange(SteveJacksonThings);
                Items.AddRange(SteveJacksonItems);
                Creatures.AddRange(SteveJacksonCreatures);
                Actions.AddRange(SteveJacksonActions);
                Events.AddRange(SteveJacksonEvents);
                Locations.AddRange(SteveJacksonLocations);
                LocalEnvironments.AddRange(SteveJacksonLocalEnvironments);
                GlobalEnvironments.AddRange(SteveJacksonGlobalEnvironments);
            }
        }

        public static List<Character> SteveJacksonCharacters = new List<Character>
        {
            SteveJacksonAdventurer,
            MagicalItemCharacter,
            SimpleItemCharacter
        };

        public static Character SteveJacksonAdventurer = new Character(new List<Trait>
        {
            new KeyValuePairTrait<string, string>(new Name("Identity"), new Dictionary<string, string>
            {
                { "Adventurers Name", "" }
            }),
            new KeyValuePairTrait<string, float>(new Name("Statistics"), new Dictionary<string, float>
            {
                { "Skill", 0 },
                { "Stamina", 0 },
                { "Luck", 0 }
            })
        });

        public static Character MagicalItemCharacter = new Character(new List<Trait>
        {
            new KeyValuePairTrait<string, string>(new Name("Identity"), new Dictionary<string, string>
            {
                { "Item Name", "" }
            })
        });

        public static Character MagicalContainerCharacter = new Character(new List<Trait>
        {
            new KeyValuePairTrait<string, string>(new Name("Identity"), new Dictionary<string, string>
            {
                { "Item Name", "" }
            }),
            new KeyValuePairTrait<string, string>(new Name("Container"), new Dictionary<string, string>
            {
                { "Entity", "" },
                { "Unit", "" },
                { "CapacityUnit", "" },
                { "MaxCapacity", "" }
            })
        });

        public static Character SimpleItemCharacter = new Character(new List<Trait>
        {
            new KeyValuePairTrait<string, string>(new Name("Identity"), new Dictionary<string, string>
            {
                { "Item Name", "" }
            })
        });

        public static List<UnitType> SteveJacksonUnitTypes = new List<UnitType>
        {
            Millileters,
            Millimeters,
            Bottles,
            Doses
        };

        public static UnitType Millileters = new UnitType(1, new Name("Millileters"));
        public static UnitType Millimeters = new UnitType(2, new Name("Millimeters"));
        public static UnitType Doses = new UnitType(3, new Name("Doses"));
        public static UnitType Bottles = new UnitType(4, new Name("Bottles"));

        public static List<Thing> SteveJacksonThings = new List<Thing>
        {
            MagicalBottle
        };

        public static Thing MagicalBottle = new Thing(new Timeline(), MagicalContainerCharacter, new Name("Bottle"));

        public static List<ItemType> SteveJacksonItemTypes = new List<ItemType>
        {
            SkillPotion
        };

        public static ItemType SkillPotion = new ItemType(1, MagicalItemCharacter, Vials.Id);
        

        public static List<Item> SteveJacksonItems = new List<Item>
        {
            SkillPotion1
        };

        public static Item SkillPotion1 => new Item(MagicalBottle);
    }
}
