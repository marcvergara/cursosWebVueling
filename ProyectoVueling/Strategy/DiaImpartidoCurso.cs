using ProyectoVueling.Models;
using System;
using System.Collections.Generic;

namespace ProyectoVueling.Strategy
{
    public class DiaImpartidoCurso
    {
        readonly Curso Curso;
        readonly DateTime FechaInicio;
        readonly DateTime FechaFin;
        
        // ToDo: Crear la clase auxiliar ModulosImpartidos, que contrendrá:
        // - Profesor
        // - Fecha del día
        // - Modulo
        // - Minutos ?
        //
        //readonly IEnumerable<ModulosImpartidos> ModulosImpartidos;
    }
}