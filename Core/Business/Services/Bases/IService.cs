﻿using Core.Results.Bases;

namespace Core.Business.Services.Bases
{
    public interface IService<TModel> : IDisposable where TModel : class, new()
    {
        IQueryable<TModel> Query();
        ResultBase Add(TModel model);
        ResultBase Update(TModel model);
        ResultBase Delete(params int[] ids);
    }
}
