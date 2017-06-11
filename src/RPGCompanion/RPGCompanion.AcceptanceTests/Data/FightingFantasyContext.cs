using RPGCompanion.Application.Context;
using RPGCompanion.Domain.Model.Context;
using RPGCompanion.Domain.Model.Context.Types;
using RPGCompanion.Domain.Model.Values;
using System.Collections.Generic;

namespace RPGCompanion.AcceptanceTests.Data
{
    public static class FightingFantasyContext
    {
        private static readonly Name _contextName = new Name("Fighting Fantasy Books");
        private static readonly Description _contextDescription = new Description("Role Play Books by Steve Jackson and Ian Livingstone");
        public static readonly UnitType ScoreUnitType = new UnitType(new Name("Score"), new Description("Character Attribute Scores"));
        public static readonly UnitType DoseUnitType = new UnitType(new Name("Dose"), new Description("A Dose of Potion"));
        public static readonly UnitType RationUnitType = new UnitType(new Name("Ration"), new Description("A Dose of Potion"));
        public static readonly UnitType MetersUnitType = new UnitType(new Name("Meters"), new Description("Metric Measurement"));

        private static readonly AddCharacterType _addCharacterType = new AddCharacterType { Name = new Name("Player Character"), Traits = PlayerTraits() };                
        private static readonly AddItemType _addLanternType = new AddItemType { Name = new Name("Lantern"), Traits = StandardLanternTraits() };
        private static readonly AddItemType _addSwordType = new AddItemType { Name = new Name("Sword"), Traits = StandardSwordTraits() };
        private static readonly AddItemType _addRationsType = new AddItemType { Name = new Name("Rations"), Traits = StandardRationsTraits() };
        private static readonly AddItemType _addSkillPotionType = new AddItemType { Name = new Name("Skill Potion"), Traits = StandardPotionTraits() };

        public static readonly CreateContext FightingFantasyContextCommand = new CreateContext
        {
            Name = _contextName,
            Description = _contextDescription
        };

        public static readonly List<AddItemType> FightingFantasyItemTypeCommands = new List<AddItemType>
        {
            _addLanternType,
            _addSwordType,
            _addRationsType,
            _addSkillPotionType
        };

        public static readonly List<AddCharacterType> FightingFantasyCharacterTypeCommands = new List<AddCharacterType>
        {
            _addCharacterType
        };

        private static List<TraitGroup> PlayerTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Scores"), new List<Trait>
                    {
                        new Trait(new Name("Skill"), new Unit(ScoreUnitType, 11)),
                        new Trait(new Name("Stamina"), new Unit(ScoreUnitType, 11)),
                        new Trait(new Name("Luck"), new Unit(ScoreUnitType, 11))
                    })
            };
        }

        private static List<TraitGroup> StandardPotionTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Unit"),
                    new List<Trait>
                    {
                        new Trait(new Name("Doses"), new Unit(DoseUnitType, 1))
                    })
            };
        }

        private static List<TraitGroup> StandardRationsTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Scores"),
                    new List<Trait>
                    {
                        new Trait(new Name("Stamina"), new Unit(ScoreUnitType, 99))
                    }),
                new TraitGroup(new Name("Unit"),
                    new List<Trait>
                    {
                        new Trait(new Name("Portions"), new Unit(RationUnitType, 1))
                    })
            };
        }

        private static List<TraitGroup> StandardLanternTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Environmental"),
                    new List<Trait>
                    {
                        new Trait(new Name("Emit Light"), new Unit(MetersUnitType, 5))
                    })
            };
        }

        private static List<TraitGroup> StandardSwordTraits()
        {
            return new List<TraitGroup>
            {
                new TraitGroup(new Name("Scores"),
                    new List<Trait>
                    {
                        new Trait(new Name("Stamina"), new Unit(ScoreUnitType, -2))
                    })
            };
        }
    }
}
