namespace Mpanagos.Alexandria.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mpanagos.Alexandria.Data.Base;

public class Publisher : Entity<long>
{
  public string Name { get; set; } = string.Empty;
}
