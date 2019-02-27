using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ProyectoVueling.Models;
using ProyectoVueling.Repositories;

namespace VuelingAcademy.Controllers
{
    public class CalendarioController : Controller
    {
        public CalendarioController(IRepository<Modulo> modulosRepo, IRepository<Profesor> profesoresRepo, IRepository<Curso> cursosRepo, IRepository<CursoImpartido> impartidosRepo)
        {
            ModulosRepo = modulosRepo;
            ProfesoresRepo = profesoresRepo;
            CursosRepo = cursosRepo;
            ImpartidosRepo = impartidosRepo;
        }

        public IRepository<Modulo> ModulosRepo { get; set; }
        public IRepository<Profesor> ProfesoresRepo { get; set; }
        public IRepository<Curso> CursosRepo { get; set; }
        public IRepository<CursoImpartido> ImpartidosRepo { get; set; }

        #region Index method  

        /// <summary>  
        /// GET: Home/Index method.  
        /// </summary>  
        /// <returns>Returns - index view page</returns>   
        public ActionResult Index()
        {
            // Info.  
            return this.View();
        }

        #endregion

        #region Get Calendar data method.  

        /// <summary>  
        /// GET: /Home/GetCalendarData  
        /// </summary>  
        /// <returns>Return data</returns>  
        public ActionResult GetCalendarData()
        {
            // Initialization.  
            JsonResult result = null;

            try
            {
                // Loading.  
                List<CalendarioModel> data = this.LoadData();

                // Processing.  
                result = this.Json(data);
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Return info.  
            return result;
        }

        #endregion

        #region Helpers  

        #region Load Data  

        /// <summary>  
        /// Load data method.  
        /// </summary>  
        /// <returns>Returns - Data</returns>  
        private List<CalendarioModel> LoadData()
        {
            // Initialization.  
            List<CalendarioModel> lst = new List<CalendarioModel>();

            try
            {
                // Initialization.  
                string line = string.Empty;
                string srcFilePath = "Content/files/PublicHoliday.txt";
                var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var fullPath = Path.Combine(rootPath, srcFilePath);
                string filePath = new Uri(fullPath).LocalPath;
                StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

                // Read file.  
                while ((line = sr.ReadLine()) != null)
                {
                    // Initialization.  
                    CalendarioModel infoObj = new CalendarioModel();
                    string[] info = line.Split(',');

                    // Setting.  
                    infoObj.Sr = Convert.ToInt32(info[0].ToString());
                    infoObj.Title = info[1].ToString();
                    infoObj.Desc = info[2].ToString();
                    infoObj.Start_Date = info[3].ToString();
                    infoObj.End_Date = info[4].ToString();

                    // Adding.  
                    lst.Add(infoObj);
                }

                // Closing.  
                sr.Dispose();
                sr.Close();
            }
            catch (Exception ex)
            {
                // info.  
                Console.Write(ex);
            }

            // info.  
            return lst;
        }

        #endregion

        #endregion
    }
}