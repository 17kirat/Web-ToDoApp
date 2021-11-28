using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyToDoList.Data;

namespace MyToDoList.Pages
{
    public class IndexModel : PageModel
    {
        
        [FromForm]
        public Models.ToDos addTask { get; set; }

        private EFContext db = new EFContext();
        
        
        public List<Models.ToDos> ToDos { get; set; }
        

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            
            _logger = logger;
        }

        // default method to get all todo items from database
        public void OnGet()
        {
            ToDos = db.ToDos.ToList();
        }
        // default OnPost method to create new record
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return ;
            }
            else
            {
                //add try catch because title is primary key updating or adding may throw error for already
                // existing record with same title 
                try
                {
                    db.ToDos.Add(addTask);
                    db.SaveChanges();
                    ToDos = db.ToDos.ToList();
                }
                catch(Exception e) { Console.WriteLine(e.Message); }
                
            }
            
        }

        //custom OnPost item to delete record from list and database
        public ActionResult OnPostDelete(string? title)
        {
            if (title != null)
            {
                //search record by title which is primary key
                var data = (from todo in db.ToDos
                            where todo.Title == title
                            select todo).SingleOrDefault();

                db.Remove(data);
                db.SaveChanges();
            }
            return RedirectToPage("index");
        }
        //custom OnPost method to update item
        public ActionResult OnPostUpdate(string? title)
        {
            
            if (title != null)
            { 
                var data = (from todo in db.ToDos
                            where todo.Title == title
                            select todo).SingleOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                if(data.IsCompleted != addTask.IsCompleted)
                {
                    addTask.CompletedOn = DateTime.Now;
                }

                //add try catch because title is primary key updating or adding may throw error for already
                // existing record with same title 
                try
                {
                    db.Remove(data);
                    db.Add(addTask);
                    db.SaveChanges();
                }
                catch (Exception e) { Console.WriteLine(e.Message); }

            }
            return RedirectToPage("index");
        }

        // this method will run on Cancel operation to refresh/redirect page
        public ActionResult OnPostCancel()
        {
            return RedirectToPage("index");
        }
    }
}
