using System.Collections.Generic;
using api.Domain.ViewModels;

namespace api.Application.Interfaces
{
    public interface IEnumService
    {
        List<EnumViewModel> GetValues<T>();
        
    }
}
