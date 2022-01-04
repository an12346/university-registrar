using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Registrar.Controllers
{
  public class StudentController : Controller
  {
    private readonly RegistrarContext _db;
    public StudentController(RegistrarContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult RazeItToTheGround()
    {
      return View();
    }

    [HttpPost]
    public ActionResult RazeItToTheGround(string output)
    {
      var whatever = output;
      List<Student> studentList = _db.Students.ToList();
      foreach(Student s in studentList){
        _db.Students.Remove(s);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}