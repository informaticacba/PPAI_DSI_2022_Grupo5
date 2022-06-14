﻿using System;
using System.Collections.Generic;
using PPAI_DSI_Grupo5.CapaDominio.FabricacionPura;
namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    internal class Turno
    {
        //Atributos privados
        private DateTime fechaGeneracion { get; set; }
        private DayOfWeek diaSemana { get; set; }
        private DateTime fechaHoraInicio { get; set; }
        private DateTime fechaHoraFin { get; set; }
        private List<CambioEstadoTurno> cambioEstadoTurno { get; set; }

        //Set and Get publicos
        public DateTime FechaGeneracion
        {
            get { return fechaGeneracion; }
            set { fechaGeneracion = value; }
        }
        public DateTime FechaHoraInicio
        {
            get { return fechaHoraInicio; }
            set { fechaHoraInicio = value; }
        }
        public DayOfWeek DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }
        public DateTime FechaHoraFin
        {
            get { return fechaHoraFin; }
            set { fechaHoraFin = value; }
        }

        //Generador
        public Turno(DateTime fechaGeneracion, DayOfWeek diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstadoTurno)
        {
            this.fechaGeneracion = fechaGeneracion;
            this.diaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.cambioEstadoTurno = cambioEstadoTurno;
        }

        //Simple validacion si la fechaInicio del turno es posterior a la fecha actual
        public bool validarFechaHoraInicio()
        {
            if (DateTime.Compare(this.fechaHoraInicio, DateTime.Now) > 0)
                return true;
            else
                return false;
        }

        //Turno x Estado
        public TurnoEstado mostrarTurnos()
        {
            //Busca el actual, retorna lo pedido
            foreach (CambioEstadoTurno cambioEstadoTurno in this.cambioEstadoTurno)
                if (cambioEstadoTurno.esActual())
                    return (new TurnoEstado(this, cambioEstadoTurno.Estado)) ;

            //A incluir en el frontend un mensaje de error
            throw new Exception("Error");

        }

    }

}