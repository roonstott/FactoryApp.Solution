using System.Collections.Generic;
namespace Factory.Models;
using System.ComponentModel.DataAnnotations;

public class Machine
{
  public int MachineId { get; set; }
  [Required(ErrorMessage = "Please Enter A Name")]
  public string Name { get; set; }
  public List<EngineerMachine> JoinEntities { get; }
}