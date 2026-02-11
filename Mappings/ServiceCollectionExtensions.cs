using Microsoft.Extensions.DependencyInjection;
using System.IO.Pipelines;
using DavidTielke.PMA.Data.DataStoring;
using DavidTielke.PMA.Data.FileStoring;
using DavidTielke.PMA.Logic.Domain.PersonManagement;

namespace Mappings
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationMappings(this IServiceCollection source)
        {
            source.AddTransient<IPersonManager, PersonManager>();
            source.AddTransient<IPersonRepository, PersonRepository>();
            source.AddTransient<IPersonParser, PersonParser>();
            source.AddTransient<IFileReader, FileReader>();
        }
    }
}
