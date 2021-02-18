using api.Application.Interfaces;
using api.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace api.Application.Services
{
    public class EnumService : IEnumService
    {
        public List<EnumViewModel> GetValues<T>()
        {
            List<EnumViewModel> values = new List<EnumViewModel>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                values
                    .Add(new EnumViewModel()
                    {
                        Id = (int)itemType,
                        Value = Enum.GetName(typeof(T), itemType)
                    });
            }
            return values;
        }
    }
}
