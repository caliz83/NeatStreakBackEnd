using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeatStreakBackEnd.Models;
using NeatStreakBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace NeatStreakBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoreController : ControllerBase
    {
        //variable to hold data
        private readonly ChoreItemService _data;

        //constructor
        public ChoreController(ChoreItemService dataFromService){
            _data = dataFromService;
        }

        //ENDPOINTS!!
        //AddChoreItem
        [HttpPost("AddChoreItem")]
        public bool AddChoreItem(ChoreItemModel newChoreItem){
            return _data.AddChoreItem(newChoreItem);
        }

        //GetAllChoreItems
        [HttpGet("GetChoreItems")]
        public IEnumerable<ChoreItemModel>GetAllChoreItems(){
            return _data.GetAllChoreItems();
        }

        //GetChoreItemsByCategory
        [HttpGet("GetItemsByCategory/{Category}")]
        public IEnumerable<ChoreItemModel>GetItemsByCategory(string Category){
            return _data.GetItemsByCategory(Category);
        }

        //GetChoreItemByDueDate
        [HttpGet("GetItemsByDueDate/{Date}")]
        public IEnumerable<ChoreItemModel>GetItemsByDueDate(string Date){
            return _data.GetItemsByDueDate(Date);
        }

        //GetCompletedChoreItems (?)
        [HttpGet("GetCompletedChoreItems")]
        public IEnumerable<ChoreItemModel>GetCompletedChoreItems(){
            return _data.GetCompletedChoreItems();
        }

        //DeleteChoreItem (?)
        [HttpPost("DeleteChoreItem/{ChoreItemToDelete}")]
        public bool DeleteChoreItem(ChoreItemModel ChoreDelete){
            return _data.DeleteChoreItem(ChoreDelete);
        }

        
    }
}