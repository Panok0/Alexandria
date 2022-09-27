namespace Mpanagos.Alexandria.Data.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mpanagos.Alexandria.Data.Base;
using Mpanagos.Alexandria.Data.Model;

public class BookCategory
{
  public Book Book { get; set; } = default!;

  public Category Category { get; set; } = default!;
}
