namespace RPGCompanion.AcceptanceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Character;
    using Castle.Components.DictionaryAdapter;
    using Domain.Model.Character;
    using Domain.Model.Context;
    using Domain.Model.Values;
    using TestStack.BDDfy;
    using Xunit;
    using Trait = Domain.Model.Character.Trait;
    using TraitGroup = Domain.Model.Character.TraitGroup;

    public class CharacterAcceptanceTests
    {
        private CreateCharacter _newActorCommand;
        private Context _context;
        private EditableList<NewItem> _actorProps;
        private List<CreateCharacter> _characters;

        [Fact]
        public void Quick_Character_Create()
        {
            this.Given(t => t.AnActor())
                .And(t => t.TheActorHasACharacter())
                .And(t => t.TheActorHasSomeProps())
                .When(t => t.TheCharacterIsCreated().Wait())
                .Then(t => t.ACharacterSheetCanBeRead().Wait())
                .BDDfy();
        }

        private void AnActor()
        {
            _newActorCommand = new CreateCharacter { Name = new Name("Player") };
        }

        private void TheActorHasACharacter()
        {
            //_newActorCommand.CharacterId = _context.Characters.First(c => Equals(c.Name, new Name("Player Character"))).Id;
        }

        private void TheActorHasSomeProps()
        {
            var unitType = _context.UnitTypes.First(ut => Equals(ut.Name, new Name("Item")));
            //var lanternCharacter = _context.Characters.First(c => Equals(c.Name, new Name("Standard Lantern")));
            //var swordCharacter = _context.Characters.First(c => Equals(c.Name, new Name("Standard Sword")));
            //var rationsnCharacter = _context.Characters.First(c => Equals(c.Name, new Name("Standard Rations")));
            //var potionCharacter = _context.Characters.First(c => Equals(c.Name, new Name("Skill Potion")));

            //_actorProps = new EditableList<NewProp>
            //{
            //    new NewProp { Name = new Name("Lantern"), Quantity = new Unit(unitType, 1), CharacterId = lanternCharacter.Id },
            //    new NewProp { Name = new Name("Sword"), Quantity = new Unit(unitType, 1), CharacterId = swordCharacter.Id },
            //    new NewProp { Name = new Name("Rations"), Quantity = new Unit(unitType, 6), CharacterId = rationsnCharacter.Id },
            //    new NewProp { Name = new Name("Potion"), Quantity = new Unit(unitType, 1), CharacterId = potionCharacter.Id  }
            //};
        }

        private async Task TheCharacterIsCreated()
        {

        }

        private async Task ACharacterSheetCanBeRead()
        {
            throw new System.NotImplementedException();
        }
    }
}