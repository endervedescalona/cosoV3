using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChronosArena
{
    public static class CargadorLocal
    {
        private static string CarpetaImagenes
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Imagenes");
            }
        }

        public static void CargarImagen(PictureBox cuadro, string archivoOUrl)
        {
            if (cuadro == null)
            {
                return;
            }

            Image nueva = ObtenerImagen(archivoOUrl);
            Image anterior = cuadro.Image;

            cuadro.Image = nueva;

            if (anterior != null)
            {
                anterior.Dispose();
            }
        }

        public static void CargarImagen(Form formulario, string archivoOUrl)
        {
            if (formulario == null)
            {
                return;
            }

            Image nueva = ObtenerImagen(archivoOUrl);
            Image anterior = formulario.BackgroundImage;

            formulario.BackgroundImage = nueva;
            formulario.BackgroundImageLayout = ImageLayout.Stretch;

            if (anterior != null)
            {
                anterior.Dispose();
            }
        }

        private static Image ObtenerImagen(string archivoOUrl)
        {
            if (String.IsNullOrWhiteSpace(archivoOUrl))
            {
                return null;
            }

            try
            {
                string nombre = archivoOUrl.Trim();
                Uri uri;

                if (Uri.TryCreate(nombre, UriKind.Absolute, out uri) &&
                    (uri.Scheme == Uri.UriSchemeHttp ||
                     uri.Scheme == Uri.UriSchemeHttps))
                {
                    nombre = Path.GetFileName(uri.LocalPath);
                }
                else
                {
                    nombre = Path.GetFileName(nombre);
                }

                if (String.IsNullOrWhiteSpace(nombre))
                {
                    return null;
                }

                if (!Directory.Exists(CarpetaImagenes))
                {
                    return null;
                }

                string encontrada = Path.Combine(CarpetaImagenes, nombre);

                if (!File.Exists(encontrada))
                {
                    string baseNombre = Path.GetFileNameWithoutExtension(nombre);

                    while (baseNombre.IndexOf('.') >= 0)
                    {
                        baseNombre = Path.GetFileNameWithoutExtension(baseNombre);
                    }

                    string[] archivos = Directory.GetFiles(CarpetaImagenes);
                    encontrada = null;

                    foreach (string archivo in archivos)
                    {
                        string baseArchivo = Path.GetFileNameWithoutExtension(archivo);

                        if (String.Equals(
                            baseArchivo,
                            baseNombre,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            encontrada = archivo;
                            break;
                        }
                    }

                    if (encontrada == null)
                    {
                        return null;
                    }
                }

                using (FileStream stream = new FileStream(
                    encontrada,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
                {
                    using (Image imagenOriginal = Image.FromStream(stream))
                    {
                        return new Bitmap(imagenOriginal);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}