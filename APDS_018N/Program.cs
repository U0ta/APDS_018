using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using APDS_018.Data;
using APDS_018.Business.Services;
using APDS_018N.Forms;


namespace APDS_018N
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();

            services.AddDbContext<APDSContextDb>(options =>
                options.UseSqlite("Data Source=..\\..\\..\\..\\APDS_018.Data\\APDS_018DB.db"));

            services.AddTransient<MainForm>();
            //test
            services.AddTransient<TestCreation>();
            services.AddTransient<TestServices>();
            //question
            services.AddTransient<QuestionCreation>();
            services.AddTransient<QuestionServices>();
            //respondent
            services.AddTransient<RespondentForm>();
            services.AddTransient<RespondentServices>();
            var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);

        }
    }
}
