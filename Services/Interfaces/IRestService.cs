using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Interfaces
{
    public interface IRestService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> DoHttpGetRequest(string controllerUrl);
        Task<string> DoHttpPostRequest(string controllerUrl, TEntity entityToInsert);
        Task<string> DoHttpPutRequest(string controllerUrl, TEntity entityToUpdate);
        Task<string> DoHttpDeleteRequest(string controllerUrl);
    }
}
