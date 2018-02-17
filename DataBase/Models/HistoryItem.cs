using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class HistoryItem : IHistoryItem
    {
        public virtual long Id { get; set; }

        public virtual string NameOperation { get; set; }

        public virtual string Args { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual float? Result { get; set; }
    }
}
