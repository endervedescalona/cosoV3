using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace ChronosArena
{
    public static class CargadorLocal
    {
        private static string CarpetaImagenes = Path.Combine(Application.StartupPath, "Imagenes");

        public static void CargarImagen(PictureBox pb, string nombreArchivo)
        {
            if (pb == null || string.IsNullOrEmpty(nombreArchivo)) return;

            try
            {
                if (!Directory.Exists(CarpetaImagenes))
                {
                    pb.Image = null;
                    return;
                }

                string rutaEncontrada = null;
                string rutaExacta = Path.Combine(CarpetaImagenes, nombreArchivo);

                // 1. Buscar coincidencia exacta
                if (File.Exists(rutaExacta))
                {
                    rutaEncontrada = rutaExacta;
                }
                else
                {
                    // 2. Si falla por extensión (.jpg vs .jpeg), extraer el nombre base (ej: "Hanzo")
                    string nombreBase = nombreArchivo.Split('.')[0];
                    string[] archivosCoincidentes = Directory.GetFiles(CarpetaImagenes, nombreBase + ".*");

                    if (archivosCoincidentes.Length > 0)
                    {
                        rutaEncontrada = archivosCoincidentes[0];
                    }
                }

                // 3. Cargar la imagen en memoria si se encontró alguna variante
                if (!string.IsNullOrEmpty(rutaEncontrada) && File.Exists(rutaEncontrada))
                {
                    using (FileStream fs = new FileStream(rutaEncontrada, FileMode.Open, FileAccess.Read))
                    {
                        if (pb.Image != null)
                        {
                            pb.Image.Dispose();
                        }
                        pb.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    pb.Image = null;
                }
            }
            catch (Exception)
            {
                pb.Image = null;
            }
        }
    }
}