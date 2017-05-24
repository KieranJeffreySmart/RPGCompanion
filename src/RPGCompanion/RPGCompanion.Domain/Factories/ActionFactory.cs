namespace RPGCompanion.Domain.Factories
{
    using Model.Timeline;

    public class ActionFactory
    {
        private readonly Action _actionTemplate;

        Action Create()
        {
            return _actionTemplate.Clone();
        }
    }
}
