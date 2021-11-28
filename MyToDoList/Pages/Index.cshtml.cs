using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoApp.Data;

namespace ToDoApp.Pages
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
                //try to catch if primary key exist 
                try
                {
                    db.ToDos.Add(addTask);
                    db.SaveChanges();
                    ToDos = db.ToDos.ToList();
                }
                catch(Exception e) { Console.WriteLine(e.Message); }
                
            }
            
        }

        //custom OnPost to delete item
        public ActionResult OnPostDelete(string? title)
        {
            if (title != null)
            {
                
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
                if(data.IsDone != addTask.IsDone)
                {
                    addTask.CompletedDate = DateTime.Now;
                }

                //try to catch if primary key exist 
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

        // run onclick cancel
        public void OnPostCancel()
        {
            return ;
        }
    }
}
