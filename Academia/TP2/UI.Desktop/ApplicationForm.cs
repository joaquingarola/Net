﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        public ModoForm _Modo;

        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta,
        }

        public ModoForm Modo
        {
            get { return _Modo; }
            set { _Modo = value; }
        }

        #region Metodos

        public virtual void MapearDeDatos() { }

        public virtual void MapearADatos() { }

        public virtual void GuardarCambios() { }

        public virtual bool Validar() { return false; }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        { 
            MessageBox.Show(mensaje, titulo, botones, icono); 
        }

        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        { 
            this.Notificar(this.Text, mensaje, botones, icono); 
        }

        #endregion
    }
}
