using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.ViewModels;

namespace Application.Services
{
    public class EnumService : IEnumService
    {
        public List<EnumViewModel> GetValues<T>()
        {
            List<EnumViewModel> values = new List<EnumViewModel>();
            foreach (var itemType in Enum.GetValues(typeof (T)))
            {
                values
                    .Add(new EnumViewModel()
                    {
                        Id = (int) itemType,
                        Value = Enum.GetName(typeof (T), itemType)
                    });
            }
            return values;
        }
    }
}
