using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ViewModels;

namespace Application.Interfaces
{
    public interface IEnumService
    {
        List<EnumViewModel> GetValues<T>();
        
    }
}
