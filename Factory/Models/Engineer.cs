using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;
public class Engineer
{
  public int EngineerId { get; set; }
  [Required(ErrorMessage = "Please Enter A Name.")]
  public string Name { get; set; }
  public List<EngineerMachine> JoinEntities { get; }
}
