using System;
using System.Collections.Generic;

namespace CRUD_Q10.Models;

public partial class TblTest
{
    public string PruebaNombre { get; set; } = null!;

    public string PruebaApellidos { get; set; } = null!;

    public int PruebaIdentificacion { get; set; }

    public string PruebaGenero { get; set; } = null!;

    public int PruebaTelefono { get; set; }

    public string PruebaMail { get; set; } = null!;
}
