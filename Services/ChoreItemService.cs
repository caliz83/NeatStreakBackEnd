using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using NeatStreakBackEnd.Models;
using NeatStreakBackEnd.Services.Context;

namespace NeatStreakBackEnd.Services
{
    public class ChoreItemService
    {

        //holds data _context
        private readonly DataContext _context;

        //constructor
        public ChoreItemService(DataContext context){
            _context = context;
        }

        public bool AddChoreItem(ChoreItemModel newChoreItem)
        {
            bool result = false;
            _context.Add<ChoreItemModel>(newChoreItem);
            result = _context.SaveChanges() != 0;
            return result;
        }

        public bool DeleteChoreItem(ChoreItemModel ChoreDelete)
        {
            _context.Update<ChoreItemModel>(ChoreDelete);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<ChoreItemModel> GetAllChoreItems()
        {
            return _context.ChoreInfo;
        }

        public IEnumerable<ChoreItemModel> GetCompletedChoreItems()
        {
            return _context.ChoreInfo.Where(item => item.IsCompleted);
        }

        public IEnumerable<ChoreItemModel> GetItemsByCategory(string Category)
        {
            return _context.ChoreInfo.Where(item => item.Category == Category);
        }

        public IEnumerable<ChoreItemModel> GetItemsByDueDate(string Date)
        {
            return _context.ChoreInfo.Where(item => item.Date == Date);
        }
    }
}