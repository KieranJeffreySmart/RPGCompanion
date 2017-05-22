namespace RPGCompanion.Domain.Model
{
    public class ActionFactory
    {
        private readonly Action _actionTemplate;

        Action Create()
        {
            return _actionTemplate.Clone();
        }
    }
}
