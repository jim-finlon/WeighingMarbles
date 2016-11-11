using System.Collections.Generic;
using System.Dynamic;

namespace WeighingMarbles.ViewModels
{
    public class MarbleWeighing
    {
        public List<Marble> StartingList { get; set; }

        public double ListWeight { get; set; }

        public List<Marble> Group1 { get; set; }
        public double Group1ListWeight { get; set; }

        public List<Marble> Group2 { get; set; }
        public double Group2ListWeight { get; set; }
        public List<Marble> Group3 { get; set; }
        public double Group3ListWeight { get; set; }
        

    }
}