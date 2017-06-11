using System.Collections.Generic;
using RPGCompanion.Application.Character;
using RPGCompanion.Domain.Model.Character;
using RPGCompanion.Domain.Model.Values;

namespace RPGCompanion.AcceptanceTests.Data
{
    public static class SampleCharacters
    {
        public static CreateCharacter CreateOpheliaLapwigCommand = new CreateCharacter
        {
            Name = new Name("Ophelia Lapwig"),
            Description = new Description("Tied to no one and nowhere, Ophelia has become a nymph-like treasure hunter.")
        };

        public static List<TraitGroup> ConansTraits = new List<TraitGroup>();
    }
}
