using LazerSharkDataObjects;
using LazerSharkDataObjects.Abstract;
using LazerSharkDataObjects.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkDataAccess.Concrete
{
    public class EFMediaRepository : IMediaRepository
    {
        private LazerSharkDBContext context = new LazerSharkDBContext();

        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }

        public IEnumerable<Game> Games
        {
            get { return context.Games; }
        }


    }
}
