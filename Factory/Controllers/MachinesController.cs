using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers;

  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges(); 
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details (int id, bool showForm)
    {
      Machine thisMachine = _db.Machines
                                          .Include(m => m.JoinEntities)
                                          .ThenInclude(join => join.Engineer)
                                          .FirstOrDefault(m => m.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      ViewBag.ShowForm = showForm;
      return View(thisMachine);
    }

    [HttpPost, ActionName("Details")]
    public ActionResult AddMachine( int engineerId, Machine machine)
    {
      EngineerMachine join = new EngineerMachine {EngineerId = engineerId, MachineId = machine.MachineId};
      _db.JoinEntities.Add(join); 
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId, showForm = false});
    }
  }

