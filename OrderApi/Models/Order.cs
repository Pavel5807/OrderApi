using System;
using System.Collections.Generic;

namespace OrderApi.Models;

public class Order
{
    public System.Guid Id { get; set; }
    public String Status { get; set; }
    public DateTime Created { get; set; }

    public List<Line> Lines { get; set; }
}
