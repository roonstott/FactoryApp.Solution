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

    public ActionResult Details (int id, bool showForm, bool showDelete)
    {
      Machine thisMachine = _db.Machines
                                          .Include(m => m.JoinEntities)
                                          .ThenInclude(join => join.Engineer)
                                          .FirstOrDefault(m => m.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      ViewBag.ShowForm = showForm;
      ViewBag.ShowDelete = showDelete;
      return View(thisMachine);
    }

    [HttpPost, ActionName("Details")]
    public ActionResult AddMachine( int engineerId, Machine machine)
    {
      #nullable enable
      EngineerMachine ? check = _db.JoinEntities.FirstOrDefault(j => (j.EngineerId == engineerId && j.MachineId == machine.MachineId)); 
      #nullable disable
      if (check == null && engineerId !=0)
      { 
        EngineerMachine join = new EngineerMachine {EngineerId = engineerId, MachineId = machine.MachineId};
        _db.JoinEntities.Add(join); 
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = machine.MachineId, showForm = false, showDelete = false});
    }

    [HttpPost]
    public ActionResult DeleteJoin (int joinId, int mId)
    {
      EngineerMachine join = _db.JoinEntities.FirstOrDefault(j => j.EngineerMachineId == joinId);
      _db.JoinEntities.Remove(join); 
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = mId, showForm = false, showDelete = false});
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
      _db.Machines.Remove(thisMachine); 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }

