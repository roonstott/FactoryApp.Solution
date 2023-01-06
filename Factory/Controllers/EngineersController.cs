using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers;

  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges(); 
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details (int id, bool showForm)
    {
      Engineer thisEngineer = _db.Engineers
                                          .Include(e => e.JoinEntities)
                                          .ThenInclude(join => join.Machine)
                                          .FirstOrDefault(e => e.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.ShowForm = showForm;
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Details")]
    public ActionResult AddMachine( int machineId, Engineer engineer)
    {
      EngineerMachine join = new EngineerMachine {EngineerId = engineer.EngineerId, MachineId = machineId};
      _db.JoinEntities.Add(join); 
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId, showForm = false});

    }
  }

