﻿using Blaze_Or.Models;

namespace Blaze_Or.Services
{
    public interface IDataService
    {
        Task Add(ItemModel model);

        Task<int> Count();

        Task<List<Item>> List(int currentPage, int pageSize);
    }
}
