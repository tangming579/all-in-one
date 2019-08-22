using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4netSqliteDemo
{
    public static class LoggerHelper
    {
        private static ILog logger;
        public static ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                return logger;
            }
        }

        static LoggerHelper()
        {
            XmlConfigurator.Configure();
        }


        public static List<LogInfo> GetLoggers()
        {
            var context = new LogContext();
            return context.Persons.Where(x => string.Equals(x.Level, "ERROR")).ToList();
        }
    }

    [Table("Log")]
    public class LogInfo
    {

        public DateTime? Date { get; set; }
        [Key]
        public string Level { get; set; }
        public string Domain { get; set; }

        public string Type { get; set; }
        public string Line { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }
    }

    public class LogContext : DbContext
    {
        public DbSet<LogInfo> Persons { get; set; }

        public LogContext()
            : base("SqliteLog")
        {

        }
    }
}
