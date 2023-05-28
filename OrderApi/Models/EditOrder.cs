using System;
using System.Collections.Generic;

namespace OrderApi.Models;

public class EditOrder
{
    public String Status { get; set; }
    public List<Line> Lines { get; set; }
}