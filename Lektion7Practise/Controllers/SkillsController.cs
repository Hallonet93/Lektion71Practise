using Lektion7Practise.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lektion7Practise.Controllers
{
    public class SkillsController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Skill");
            var collection = database.GetCollection<Skills>("skills");

            List<Skills> skills = collection.Find(o => true).ToList();

            return View(skills);
        }
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skills skill)
        {
            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Skill");
            var collection = database.GetCollection<Skills>("skills");

            collection.InsertOne(skill);

            return Redirect("/Skills");
        }

        public IActionResult ShowSkills(string Id)
        {
            ObjectId skillId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient(); //Connects to the database

            var database = dbClient.GetDatabase("Skills");
            var collection = database.GetCollection<Skills>("skills");

            Skills skill = collection.Find(o => o.Id == skillId).FirstOrDefault();

            return View(skill);
        }

        public ActionResult DeleteSkill(string Id)
        {
            ObjectId skillId = new ObjectId(Id); // Assigning a variable to the info we get from user

            MongoClient dbClient = new MongoClient(); // Always need to again show the Database we use

            var database = dbClient.GetDatabase("Skills");
            var collection = database.GetCollection<Skills>("skills");

            collection.DeleteOne(o => o.Id == skillId); // DeleteOne removes one item from the collections

            return Redirect("/Skills");
        }
    }
}
