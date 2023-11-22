using Lektion7Practise.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lektion7Practise.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactMe(Contact contact)
        {
            MongoClient dbClient = new MongoClient(); //Connects to the database

            var database = dbClient.GetDatabase("Contact");
            var collection = database.GetCollection<Contact>("contacts");

            collection.InsertOne(contact);

            return View(contact);
        }
        public IActionResult ContactRequests()
        {
            MongoClient dbClient = new MongoClient(); //Connects to the database

            var database = dbClient.GetDatabase("Contact");
            var collection = database.GetCollection<Contact>("contacts");

            List<Contact> contacts = collection.Find(o => true).ToList();

            return View(contacts);
        }
        public IActionResult ShowContact(string Id)
        {
            ObjectId contactId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient(); //Connects to the database

            var database = dbClient.GetDatabase("Contact");
            var collection = database.GetCollection<Contact>("contacts");

            Contact contact = collection.Find(o => o.Id == contactId).FirstOrDefault();

            return View(contact);
        }

        public IActionResult DeleteContact(string Id)
        {
            ObjectId contactId = new ObjectId(Id);

            MongoClient dbClient = new MongoClient();
            var database = dbClient.GetDatabase("Contact");
            var collection = database.GetCollection<Contact>("contacts");

            collection.DeleteOne(o => o.Id == contactId);

            return Redirect("/Contact/ContactRequests");

        }
    }
}
