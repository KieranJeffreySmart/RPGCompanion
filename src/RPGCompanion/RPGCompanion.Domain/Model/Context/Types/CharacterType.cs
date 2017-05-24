namespace RPGCompanion.Domain.Model.Context.Types
{
    using DomainCore;

    public class CharacterType : DomainEntity<long>
    {
        public CharacterType(long id) : base(id)
        {
        }
    }
}