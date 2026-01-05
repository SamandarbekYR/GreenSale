using System;
using System.Collections.Generic;
using System.Text;

namespace GreenSale.Data.Entities;

public interface IDeletable
{
    bool IsDeleted { get; set; }
}