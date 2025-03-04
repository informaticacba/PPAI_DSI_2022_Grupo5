﻿using PPAI_DSI_Grupo5.CapaDatos;
using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using PPAI_DSI_Grupo5.CapaDominio.FabricacionPura;
using PPAI_DSI_Grupo5.Presentacion.ABM_Turno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI_DSI_Grupo5.Presentacion.Transacciones
{
    public partial class RegistrarTurno : Form
    {
        //ATRIBUTOS
        private GestorReservaDeTurno gestor;
        private AltaTurno ventana;


        //METODOS

        // --> Metodo constructor
        public RegistrarTurno()
        {
            InitializeComponent();
            Sesion sesion = LoadData.loadSesion();
            ventana = new AltaTurno();
            gestor = new GestorReservaDeTurno(this, ventana, sesion);
            gestor.nuevaReservaTurno();
        }

        // --> Muestra en el ComboBox los tipos de recursos disponibles
        internal void mostrarYSolicitarSeleccionTipoRT(List<string> lista)
        {
            cmbTipoRecurso.Items.AddRange(lista.ToArray());
        }

        // --> Se dispara cuando se selecciona el tipo de recurso tecnologico
        private void cmbTipoRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            gestor.tomarSeleccionTipoRecursoTecnologico(cmbTipoRecurso.SelectedItem.ToString());
        }

        internal void MostrarYSolicitarRTAUtilizar(List<RecursoTecnologicoMuestra> listaRecursosMuestra)
        {
            dgrRecursos.Rows.Clear();
            foreach (var recurso in listaRecursosMuestra)
            {
                dgrRecursos.Rows.Add(recurso.getNumetoInventario(), recurso.getCentroInvestigacion().getNombre(), recurso.getMarca(), recurso.getModelo(), recurso.getEstado());
            };
            for (int i = 0; i < dgrRecursos.Rows.Count; i++)
            {
                colorear(i, listaRecursosMuestra[i].getColor());
            }
            dgrRecursos.ClearSelection();
        }

        private void colorear(int fila, int color)
        {
            switch (color)
            {
                case 1:
                    dgrRecursos.Rows[fila].Cells[0].Style.BackColor = Color.LightBlue;
                    dgrRecursos.Rows[fila].Cells[1].Style.BackColor = Color.LightBlue;
                    dgrRecursos.Rows[fila].Cells[2].Style.BackColor = Color.LightBlue;
                    dgrRecursos.Rows[fila].Cells[3].Style.BackColor = Color.LightBlue;
                    dgrRecursos.Rows[fila].Cells[4].Style.BackColor = Color.LightBlue;
                    break;           
                case 2:              
                    dgrRecursos.Rows[fila].Cells[0].Style.BackColor = Color.LightSeaGreen;
                    dgrRecursos.Rows[fila].Cells[1].Style.BackColor = Color.LightSeaGreen;
                    dgrRecursos.Rows[fila].Cells[2].Style.BackColor = Color.LightSeaGreen;
                    dgrRecursos.Rows[fila].Cells[3].Style.BackColor = Color.LightSeaGreen;
                    dgrRecursos.Rows[fila].Cells[4].Style.BackColor = Color.LightSeaGreen;
                    break;           
                case 3:              
                    dgrRecursos.Rows[fila].Cells[0].Style.BackColor = Color.LightGray;
                    dgrRecursos.Rows[fila].Cells[1].Style.BackColor = Color.LightGray;
                    dgrRecursos.Rows[fila].Cells[2].Style.BackColor = Color.LightGray;
                    dgrRecursos.Rows[fila].Cells[3].Style.BackColor = Color.LightGray;
                    dgrRecursos.Rows[fila].Cells[4].Style.BackColor = Color.LightGray;
                    break;
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgrRecursos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un Tipo de recurso", "Reserva de truno");
            }
            else
            {
                gestor.tomarSeleccionRTAUtilizar(dgrRecursos.CurrentRow);
                ventana.ShowDialog();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea cancelar?", "Cancelar reserva de truno", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
