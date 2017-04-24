using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkDataObjects.Abstract
{
    public interface IMediaRepository
    {
        IEnumerable<Movie> Movies { get; }
        IEnumerable<Game> Games { get; }
    }
}
