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
        //AddChoreItem (C)
        [HttpPost("AddChoreItem")]
        public bool AddChoreItem(ChoreItemModel newChoreItem){
            return _data.AddChoreItem(newChoreItem);
        }

        //GetAllChoreItems (R)
        [HttpGet("GetChoreItems")]
        public IEnumerable<ChoreItemModel>GetAllChoreItems(){
            return _data.GetAllChoreItems();
        }

        //GetChoreItemsByCategory (R) kitchen, bathroom, bedroom, living room, other
        [HttpGet("GetItemsByCategory/{Category}")]
        public IEnumerable<ChoreItemModel>GetItemsByCategory(string Category){
            return _data.GetItemsByCategory(Category);
        }

        //GetChoreItemByDueDate (R)
        [HttpGet("GetItemsByDueDate/{Date}")]
        public IEnumerable<ChoreItemModel>GetItemsByDueDate(string Date){
            return _data.GetItemsByDueDate(Date);
        }

        //GetCompletedChoreItems (?)
        [HttpGet("GetCompletedChoreItems")]
        public IEnumerable<ChoreItemModel>GetCompletedChoreItems(){
            return _data.GetCompletedChoreItems();
        }

        // UpdateChores (U) (?)
        // [HttpPost("UpdateChores")]
        // public bool UpdateChores(string title, string category){
        //     return _data.UpdateChores(title, category)
        //} this would update the individual chore and not the list of chores so not what we want

        //DeleteChoreItem (D) (?)
        [HttpPost("DeleteChoreItem/{ChoreItemToDelete}")]
        public bool DeleteChoreItem(ChoreItemModel ChoreDelete){
            return _data.DeleteChoreItem(ChoreDelete);
        }

        
    }
}