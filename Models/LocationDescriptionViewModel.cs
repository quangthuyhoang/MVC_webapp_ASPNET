using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class LocationDescriptionViewModel
    {
        public List<Destination> destinations;
        public SelectList description;
        public string destinationDescription { get; set; }
    }
}
