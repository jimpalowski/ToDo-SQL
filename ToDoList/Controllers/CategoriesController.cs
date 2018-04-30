using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
    {
      [HttpGet("/Categories")]
      public ActionResult Index()
      {
        List<Category> allCategories = Category.GetAll();
        return View(allCategories);
      }

      [HttpPost("/Categories/AddCategory")]
      public ActionResult CreateForm()
      {
        return View();
      }

      [HttpPost("/Categories")]
      public ActionResult CreateCategory()
      {
        Category newCategory = new Category(Request.Form["category-name"]);
        newCategory.Save();
        List<Category> allCategories = Category.GetAll();
        return View("Index", allCategories);
      }

      [HttpGet("/Categories/{id}")]
      public ActionResult Details(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(id);
        List<Item> categoryItems = selectedCategory.GetItems();
        model.Add("category", selectedCategory);
        model.Add("items", categoryItems);
        return View(model);
      }

      [HttpPost("/Items")]
      public ActionResult CreateItem()
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category foundCategory = Category.Find(Int32.Parse(Request.Form["category-id"]));
        var description = (Request.Form["item"]);
        var date = (Request.Form["date"]);
        var memo = (Request.Form["description"]);
        var importance = (Request.Form["importance"]);
        Item newItem = new Item(description, date, memo, importance);
        newItem.Save();
        List<Item> allItems = Item.GetAll();
        return View("/Items/List", allItems);
        foundCategory.AddItem(newItem);
        List<Item> categoryItems = foundCategory.GetItems();
        model.Add("items", categoryItems);
        model.Add("category", foundCategory);
        return View("Details", model);
      }

    }

}
