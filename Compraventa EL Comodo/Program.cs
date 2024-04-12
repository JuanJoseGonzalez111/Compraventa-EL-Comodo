using Compraventa_EL_Comodo.Datos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compraventa_EL_Comodo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var configuration = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json")
                       .Build();
            var servicecolletion = new ServiceCollection();

            servicecolletion.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            servicecolletion.AddScoped<IEmpeñar, Empeñar>();
            servicecolletion.AddScoped<IRetirar, Retirar>();
            servicecolletion.AddScoped<IClienteDatos, ClienteDatos>();
            servicecolletion.AddScoped<Form1>();
            servicecolletion.AddScoped<EmpeñarForms>();
            servicecolletion.AddScoped<Abonar>();
            servicecolletion.AddScoped<ClienteForms>();

            servicecolletion.AddScoped<IConfiguration>((s) => configuration);
            var serviceprovaider = servicecolletion.BuildServiceProvider();

            //Aqui va el log registro de errores
            Application.EnableVisualStyles();
            var mainform = serviceprovaider.GetService<Form1>();
            Application.Run(mainform);

        }
    }
}
