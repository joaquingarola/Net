using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
        }

        public Usuarios()
        {
            _UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            string opc;
            do
            {
                Console.Clear();
                Console.WriteLine("1- Listado General");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        ListadoGeneral();
                        break;
                    case "2":
                        Consultar();
                        break;
                    case "3":
                        Agregar();
                        break;
                    case "4":
                        Modificar();
                        break;
                    case "5":
                        Eliminar();
                        break;
                }
            } while (opc != "6");
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario user in UsuarioNegocio.GetAll())
            {
                MostrarDatos(user);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingresar ID de Usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero");
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine();
                Console.WriteLine("No existe usuario con ese ID");
            }

            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingresar ID del Usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario user = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                user.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                user.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                user.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                user.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                user.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitacion de Usuario <1> Si <Otro> No: ");
                user.Habilitado = (Console.ReadLine() == "1");
                user.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(user);
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero");
            }

            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Console.Clear();
            Usuario nuevoUsuario = new Usuario();
            Console.Write("Ingrese Nombre: ");
            nuevoUsuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            nuevoUsuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            nuevoUsuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            nuevoUsuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            nuevoUsuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitacion de Usuario <1> Si <Otro> No: ");
            nuevoUsuario.Habilitado = (Console.ReadLine() == "1");
            nuevoUsuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(nuevoUsuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", nuevoUsuario.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingresar ID de Usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un numero");
            }

            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }

        public void MostrarDatos(Usuario user)
        {
            Console.WriteLine("Usuario: {0}", user.ID);
            Console.WriteLine("\t\tNombre: {0}", user.Nombre);
            Console.WriteLine("\t\tApellido: {0}", user.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", user.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", user.Clave);
            Console.WriteLine("\t\tEmail: {0}", user.Email);
            Console.WriteLine("\t\tHabilitado: {0}", user.Habilitado);
            Console.WriteLine();
        }
    }
}
