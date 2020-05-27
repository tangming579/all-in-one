using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac
{
    class Program
    {
        public class Movie
        {
            public string Name { get; set; }
        }
        public interface IMovieFinder
        {
            List<Movie> FindAll();
        }
        public class MPGMovieLister
        {
            private readonly IMovieFinder _movieFinder;
            //增加了构造函数，参数是IMovieFinder对象
            public MPGMovieLister(IMovieFinder movieFinder)
            {
                _movieFinder = movieFinder;
            }

            public Movie[] GetMPG()
            {
                var allMovies = _movieFinder.FindAll();
                return allMovies.Where(m => m.Name.EndsWith(".MPG")).ToArray();
            }
        }
        public class ListMovieFinder : IMovieFinder
        {
            public List<Movie> FindAll()
            {
                return new List<Movie>
                      {
                          new Movie
                              {
                                  Name = "Die Hard.wmv"
                              },
                          new Movie
                              {
                                  Name = "My Name is John.MPG"
                              }
                      };
            }
        }
        public class DBMovieFinder : IMovieFinder
        {
            public List<Movie> FindAll()
            {
                return new List<Movie>
                      {
                          new Movie
                              {
                                  Name = "Davi.wmv"
                              },
                          new Movie
                              {
                                  Name = "Tom.MPG"
                              }
                      };
            }
        }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //注册ListMovieFinder类型，这里的AsImplementedInterfaces表示以接口的形式注册
            builder.RegisterType<ListMovieFinder>().AsImplementedInterfaces();
            //builder.RegisterType<ListMovieFinder>().As<IMovieFinder>();
            //builder.RegisterType<ListMovieFinder>().Named<IMovieFinder>("list");

            //注册MPGMovieLister类型
            builder.RegisterType<MPGMovieLister>();
            var _container = builder.Build();

            var lister = _container.Resolve<MPGMovieLister>();
            //var listFinder = (ListMovieFinder)_container.ResolveNamed<IMovieFinder>("list");

            foreach (var movie in lister.GetMPG())
            {
                Console.WriteLine(movie.Name);
            }

            Console.ReadKey();
        }
    }
}
