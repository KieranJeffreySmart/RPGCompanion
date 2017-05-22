using System.Collections.Generic;
using RPGCompanion.Domain.Model;

namespace RPGCompanion.Domain.Repository
{
    public interface IActionRepository
    {
        List<Model.Action> GetAll(Context context);
    }
}
