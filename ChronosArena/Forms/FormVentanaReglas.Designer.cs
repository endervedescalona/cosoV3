using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormVentanaReglas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlObjetivo;
        private System.Windows.Forms.Panel pnlEquipos;
        private System.Windows.Forms.Panel pnlClases;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlTurnos;
        private System.Windows.Forms.Panel pnlVictoria;

        private System.Windows.Forms.Label lblObjetivoTitulo;
        private System.Windows.Forms.Label lblObjetivoTexto;
        private System.Windows.Forms.Label lblEquiposTitulo;
        private System.Windows.Forms.Label lblEquiposTexto;
        private System.Windows.Forms.Label lblClasesTitulo;
        private System.Windows.Forms.Label lblClasesTexto;
        private System.Windows.Forms.Label lblAccionesTitulo;
        private System.Windows.Forms.Label lblAccionesTexto;
        private System.Windows.Forms.Label lblTurnosTitulo;
        private System.Windows.Forms.Label lblTurnosTexto;
        private System.Windows.Forms.Label lblVictoriaTitulo;
        private System.Windows.Forms.Label lblVictoriaTexto;

        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaReglas));
        	this.lblTitulo = new System.Windows.Forms.Label();
        	this.lblSubtitulo = new System.Windows.Forms.Label();
        	this.pnlObjetivo = new System.Windows.Forms.Panel();
        	this.lblObjetivoTitulo = new System.Windows.Forms.Label();
        	this.lblObjetivoTexto = new System.Windows.Forms.Label();
        	this.pnlEquipos = new System.Windows.Forms.Panel();
        	this.lblEquiposTitulo = new System.Windows.Forms.Label();
        	this.lblEquiposTexto = new System.Windows.Forms.Label();
        	this.pnlClases = new System.Windows.Forms.Panel();
        	this.lblClasesTitulo = new System.Windows.Forms.Label();
        	this.lblClasesTexto = new System.Windows.Forms.Label();
        	this.pnlAcciones = new System.Windows.Forms.Panel();
        	this.lblAccionesTitulo = new System.Windows.Forms.Label();
        	this.lblAccionesTexto = new System.Windows.Forms.Label();
        	this.pnlTurnos = new System.Windows.Forms.Panel();
        	this.lblTurnosTitulo = new System.Windows.Forms.Label();
        	this.lblTurnosTexto = new System.Windows.Forms.Label();
        	this.pnlVictoria = new System.Windows.Forms.Panel();
        	this.lblVictoriaTitulo = new System.Windows.Forms.Label();
        	this.lblVictoriaTexto = new System.Windows.Forms.Label();
        	this.btnCerrar = new System.Windows.Forms.Button();
        	this.pnlObjetivo.SuspendLayout();
        	this.pnlEquipos.SuspendLayout();
        	this.pnlClases.SuspendLayout();
        	this.pnlAcciones.SuspendLayout();
        	this.pnlTurnos.SuspendLayout();
        	this.pnlVictoria.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 27F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblTitulo.ForeColor = System.Drawing.Color.Purple;
        	this.lblTitulo.Location = new System.Drawing.Point(25, 18);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(800, 55);
        	this.lblTitulo.TabIndex = 0;
        	this.lblTitulo.Text = "CHRONOS ARENA";
        	// 
        	// lblSubtitulo
        	// 
        	this.lblSubtitulo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
        	this.lblSubtitulo.Location = new System.Drawing.Point(25, 75);
        	this.lblSubtitulo.Name = "lblSubtitulo";
        	this.lblSubtitulo.Size = new System.Drawing.Size(800, 28);
        	this.lblSubtitulo.TabIndex = 1;
        	this.lblSubtitulo.Text = "REGLAMENTO OFICIAL  |  CONOCE LAS REGLAS DEL COMBATE";
        	// 
        	// pnlObjetivo
        	// 
        	this.pnlObjetivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
        	this.pnlObjetivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlObjetivo.Controls.Add(this.lblObjetivoTitulo);
        	this.pnlObjetivo.Controls.Add(this.lblObjetivoTexto);
        	this.pnlObjetivo.Location = new System.Drawing.Point(25, 125);
        	this.pnlObjetivo.Name = "pnlObjetivo";
        	this.pnlObjetivo.Size = new System.Drawing.Size(385, 142);
        	this.pnlObjetivo.TabIndex = 2;
        	// 
        	// lblObjetivoTitulo
        	// 
        	this.lblObjetivoTitulo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold);
        	this.lblObjetivoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblObjetivoTitulo.Location = new System.Drawing.Point(16, 12);
        	this.lblObjetivoTitulo.Name = "lblObjetivoTitulo";
        	this.lblObjetivoTitulo.Size = new System.Drawing.Size(345, 27);
        	this.lblObjetivoTitulo.TabIndex = 0;
        	this.lblObjetivoTitulo.Text = "01  OBJETIVO";
        	// 
        	// lblObjetivoTexto
        	// 
        	this.lblObjetivoTexto.Font = new System.Drawing.Font("Courier New", 9.5F);
        	this.lblObjetivoTexto.ForeColor = System.Drawing.Color.White;
        	this.lblObjetivoTexto.Location = new System.Drawing.Point(16, 46);
        	this.lblObjetivoTexto.Name = "lblObjetivoTexto";
        	this.lblObjetivoTexto.Size = new System.Drawing.Size(345, 85);
        	this.lblObjetivoTexto.TabIndex = 1;
        	this.lblObjetivoTexto.Text = "Derrota al equipo rival eliminando a sus cinco personajes. En este modo te enfren" +
        	"tarás contra la computadora.";
        	// 
        	// pnlEquipos
        	// 
        	this.pnlEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
        	this.pnlEquipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlEquipos.Controls.Add(this.lblEquiposTitulo);
        	this.pnlEquipos.Controls.Add(this.lblEquiposTexto);
        	this.pnlEquipos.Location = new System.Drawing.Point(425, 125);
        	this.pnlEquipos.Name = "pnlEquipos";
        	this.pnlEquipos.Size = new System.Drawing.Size(385, 142);
        	this.pnlEquipos.TabIndex = 3;
        	// 
        	// lblEquiposTitulo
        	// 
        	this.lblEquiposTitulo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold);
        	this.lblEquiposTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblEquiposTitulo.Location = new System.Drawing.Point(16, 12);
        	this.lblEquiposTitulo.Name = "lblEquiposTitulo";
        	this.lblEquiposTitulo.Size = new System.Drawing.Size(345, 27);
        	this.lblEquiposTitulo.TabIndex = 0;
        	this.lblEquiposTitulo.Text = "02  EQUIPOS";
        	// 
        	// lblEquiposTexto
        	// 
        	this.lblEquiposTexto.Font = new System.Drawing.Font("Courier New", 9.5F);
        	this.lblEquiposTexto.ForeColor = System.Drawing.Color.White;
        	this.lblEquiposTexto.Location = new System.Drawing.Point(16, 46);
        	this.lblEquiposTexto.Name = "lblEquiposTexto";
        	this.lblEquiposTexto.Size = new System.Drawing.Size(345, 85);
        	this.lblEquiposTexto.TabIndex = 1;
        	this.lblEquiposTexto.Text = "Cada equipo está formado por cinco personajes distintos. El jugador selecciona su" +
        	"s cartas y la IA forma su propio equipo.";
        	// 
        	// pnlClases
        	// 
        	this.pnlClases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
        	this.pnlClases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlClases.Controls.Add(this.lblClasesTitulo);
        	this.pnlClases.Controls.Add(this.lblClasesTexto);
        	this.pnlClases.Location = new System.Drawing.Point(25, 285);
        	this.pnlClases.Name = "pnlClases";
        	this.pnlClases.Size = new System.Drawing.Size(385, 142);
        	this.pnlClases.TabIndex = 4;
        	// 
        	// lblClasesTitulo
        	// 
        	this.lblClasesTitulo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold);
        	this.lblClasesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblClasesTitulo.Location = new System.Drawing.Point(16, 12);
        	this.lblClasesTitulo.Name = "lblClasesTitulo";
        	this.lblClasesTitulo.Size = new System.Drawing.Size(345, 27);
        	this.lblClasesTitulo.TabIndex = 0;
        	this.lblClasesTitulo.Text = "03  CLASES Y ELEMENTOS";
        	// 
        	// lblClasesTexto
        	// 
        	this.lblClasesTexto.Font = new System.Drawing.Font("Courier New", 9.5F);
        	this.lblClasesTexto.ForeColor = System.Drawing.Color.White;
        	this.lblClasesTexto.Location = new System.Drawing.Point(16, 46);
        	this.lblClasesTexto.Name = "lblClasesTexto";
        	this.lblClasesTexto.Size = new System.Drawing.Size(345, 85);
        	this.lblClasesTexto.TabIndex = 1;
        	this.lblClasesTexto.Text = "Tanques: destacan por su resistencia. Guerreros: destacan por su ataque. Magos: u" +
        	"tilizan habilidades especiales. Elementos: Fuego, Agua, Aire y Tierra.";
        	// 
        	// pnlAcciones
        	// 
        	this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
        	this.pnlAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlAcciones.Controls.Add(this.lblAccionesTitulo);
        	this.pnlAcciones.Controls.Add(this.lblAccionesTexto);
        	this.pnlAcciones.Location = new System.Drawing.Point(425, 285);
        	this.pnlAcciones.Name = "pnlAcciones";
        	this.pnlAcciones.Size = new System.Drawing.Size(385, 142);
        	this.pnlAcciones.TabIndex = 5;
        	// 
        	// lblAccionesTitulo
        	// 
        	this.lblAccionesTitulo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold);
        	this.lblAccionesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblAccionesTitulo.Location = new System.Drawing.Point(16, 12);
        	this.lblAccionesTitulo.Name = "lblAccionesTitulo";
        	this.lblAccionesTitulo.Size = new System.Drawing.Size(345, 27);
        	this.lblAccionesTitulo.TabIndex = 0;
        	this.lblAccionesTitulo.Text = "04  ACCIONES";
        	// 
        	// lblAccionesTexto
        	// 
        	this.lblAccionesTexto.Font = new System.Drawing.Font("Courier New", 8.5F);
        	this.lblAccionesTexto.ForeColor = System.Drawing.Color.White;
        	this.lblAccionesTexto.Location = new System.Drawing.Point(16, 43);
        	this.lblAccionesTexto.Name = "lblAccionesTexto";
        	this.lblAccionesTexto.Size = new System.Drawing.Size(345, 91);
        	this.lblAccionesTexto.TabIndex = 1;
        	this.lblAccionesTexto.Text = resources.GetString("lblAccionesTexto.Text");
        	// 
        	// pnlTurnos
        	// 
        	this.pnlTurnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
        	this.pnlTurnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlTurnos.Controls.Add(this.lblTurnosTitulo);
        	this.pnlTurnos.Controls.Add(this.lblTurnosTexto);
        	this.pnlTurnos.Location = new System.Drawing.Point(25, 445);
        	this.pnlTurnos.Name = "pnlTurnos";
        	this.pnlTurnos.Size = new System.Drawing.Size(385, 142);
        	this.pnlTurnos.TabIndex = 6;
        	// 
        	// lblTurnosTitulo
        	// 
        	this.lblTurnosTitulo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold);
        	this.lblTurnosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblTurnosTitulo.Location = new System.Drawing.Point(16, 12);
        	this.lblTurnosTitulo.Name = "lblTurnosTitulo";
        	this.lblTurnosTitulo.Size = new System.Drawing.Size(345, 27);
        	this.lblTurnosTitulo.TabIndex = 0;
        	this.lblTurnosTitulo.Text = "05  TURNOS";
        	// 
        	// lblTurnosTexto
        	// 
        	this.lblTurnosTexto.Font = new System.Drawing.Font("Courier New", 9.5F);
        	this.lblTurnosTexto.ForeColor = System.Drawing.Color.White;
        	this.lblTurnosTexto.Location = new System.Drawing.Point(16, 46);
        	this.lblTurnosTexto.Name = "lblTurnosTexto";
        	this.lblTurnosTexto.Size = new System.Drawing.Size(345, 85);
        	this.lblTurnosTexto.TabIndex = 1;
        	this.lblTurnosTexto.Text = "Cada turno dispone de 30 segundos. Si el tiempo termina, el jugador pierde su tur" +
        	"no y la computadora realiza su acción.";
        	// 
        	// pnlVictoria
        	// 
        	this.pnlVictoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(57)))));
        	this.pnlVictoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlVictoria.Controls.Add(this.lblVictoriaTitulo);
        	this.pnlVictoria.Controls.Add(this.lblVictoriaTexto);
        	this.pnlVictoria.Location = new System.Drawing.Point(425, 445);
        	this.pnlVictoria.Name = "pnlVictoria";
        	this.pnlVictoria.Size = new System.Drawing.Size(385, 142);
        	this.pnlVictoria.TabIndex = 7;
        	// 
        	// lblVictoriaTitulo
        	// 
        	this.lblVictoriaTitulo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold);
        	this.lblVictoriaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblVictoriaTitulo.Location = new System.Drawing.Point(16, 12);
        	this.lblVictoriaTitulo.Name = "lblVictoriaTitulo";
        	this.lblVictoriaTitulo.Size = new System.Drawing.Size(345, 27);
        	this.lblVictoriaTitulo.TabIndex = 0;
        	this.lblVictoriaTitulo.Text = "06  VICTORIA Y RENDICIÓN";
        	// 
        	// lblVictoriaTexto
        	// 
        	this.lblVictoriaTexto.Font = new System.Drawing.Font("Courier New", 9.5F);
        	this.lblVictoriaTexto.ForeColor = System.Drawing.Color.White;
        	this.lblVictoriaTexto.Location = new System.Drawing.Point(16, 46);
        	this.lblVictoriaTexto.Name = "lblVictoriaTexto";
        	this.lblVictoriaTexto.Size = new System.Drawing.Size(345, 85);
        	this.lblVictoriaTexto.TabIndex = 1;
        	this.lblVictoriaTexto.Text = "Gana quien derrote a los cinco personajes del equipo rival. Si el jugador se rind" +
        	"e y vuelve al menú, la victoria será para la IA.";
        	// 
        	// btnCerrar
        	// 
        	this.btnCerrar.BackColor = System.Drawing.Color.Purple;
        	this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnCerrar.FlatAppearance.BorderSize = 0;
        	this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnCerrar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.btnCerrar.ForeColor = System.Drawing.Color.White;
        	this.btnCerrar.Location = new System.Drawing.Point(325, 605);
        	this.btnCerrar.Name = "btnCerrar";
        	this.btnCerrar.Size = new System.Drawing.Size(200, 42);
        	this.btnCerrar.TabIndex = 2;
        	this.btnCerrar.Text = "VOLVER";
        	this.btnCerrar.UseVisualStyleBackColor = false;
        	this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
        	// 
        	// FormVentanaReglas
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(21)))), ((int)(((byte)(34)))));
        	this.ClientSize = new System.Drawing.Size(850, 675);
        	this.Controls.Add(this.lblTitulo);
        	this.Controls.Add(this.lblSubtitulo);
        	this.Controls.Add(this.pnlObjetivo);
        	this.Controls.Add(this.pnlEquipos);
        	this.Controls.Add(this.pnlClases);
        	this.Controls.Add(this.pnlAcciones);
        	this.Controls.Add(this.pnlTurnos);
        	this.Controls.Add(this.pnlVictoria);
        	this.Controls.Add(this.btnCerrar);
        	this.Font = new System.Drawing.Font("Courier New", 9F);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        	this.MaximizeBox = true;
        	this.MinimizeBox = false;
        	this.Name = "FormVentanaReglas";
        	this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Chronos Arena - Reglamento";
        	this.pnlObjetivo.ResumeLayout(false);
        	this.pnlEquipos.ResumeLayout(false);
        	this.pnlClases.ResumeLayout(false);
        	this.pnlAcciones.ResumeLayout(false);
        	this.pnlTurnos.ResumeLayout(false);
        	this.pnlVictoria.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
    }
}
