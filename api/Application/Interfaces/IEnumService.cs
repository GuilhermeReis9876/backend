using api.Domain.ViewModels;
using System.Collections.Generic;

namespace api.Application.Interfaces
{
    public interface IEnumService
    {
        List<EnumViewModel> GetValues<T>();

    }
}
