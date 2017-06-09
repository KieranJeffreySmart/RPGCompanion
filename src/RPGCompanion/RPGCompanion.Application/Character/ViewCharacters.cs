namespace RPGCompanion.Application.Character
{
    using System.Collections.Generic;
    using Domain;
    using RPGCompanion.Domain.Model.Character;

    public class ViewCharacters: DomainQuery<IEnumerable<Character>>
    {
        
    }
}