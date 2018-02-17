using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public interface IHistoryItem
    {
        long Id { get; set; }

        string NameOperation { get; set; }

        string Args { get; set; }

        DateTime Time { get; set; }

        float? Result { get; set; }
    }
}
