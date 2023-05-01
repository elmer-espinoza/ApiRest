using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using ApiRestService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Dapper;
using Microsoft.IdentityModel.Tokens;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using static ApiRestService.Models.Employee;
//using System.Reflection.Metadata.Ecma335;

namespace ApiRestService.Controllers
{
    [ApiController]
    [Route("[controller]", Name = "API Employees (Dapper)", Order = 2)]
    [DisplayName("API Employees (Dapper)")]

    public class EmployeesDapperController : ControllerBase
    {
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        //[Authorize(Users = "Diana,Lady")]
        [Authorize]
        [Route("ReadEmployee")]
        public Employee ReadEmpleado(int id)
      //  public dynamic ReadEmpleado(int id)
        {
            /*
            //Employee employee = new();
            //id = (String.IsNullOrEmpty(id.ToString())) ? -1 : id;
            //var sql = "sp_ApiRest_Leer @Id";
            //SqlConnection cn = new SqlConnection(new DataBase().StringConnection());
            //employee = cn.Query<Employee>(sql, new { @Id = id }).First();
            //return employee;
            */
            try
            {
                return (new SqlConnection(new DataBase().StringConnection())).Query<Employee>("sp_ApiRest_Leer @Id", new { @Id = id }).First();
            }
            catch (Exception ex)
            {
                return null; // NotFound("Empleado con Id " + id.ToString() + " no existe");
            }
            ;
            
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmpleado(Employee employee)
        {
            var rpta = (new SqlConnection(new DataBase().StringConnection())).Query<Employee>("sp_ApiRest_Crear @Nombre, @DNI, @Edad, @Telefono, @Correo, @Basico, @Ingreso, @Activo", new { @Nombre = employee.Nombre, @DNI = employee.DNI, @Edad = employee.Edad, @Telefono = employee.Telefono, @Correo = employee.Correo, @Basico = employee.Basico, @Ingreso = employee.Ingreso, @Activo = employee.Activo }).SingleOrDefault();
            return Ok("Se agregó satisfactoriamente el nuevo registro del Empleado");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmpleado(Employee employee)
        {
            var rpta = (new SqlConnection(new DataBase().StringConnection())).Query<Employee>("sp_ApiRest_Editar @Id, @Nombre, @DNI, @Edad, @Telefono, @Correo, @Basico, @Ingreso, @Activo", new { @Id = employee.Id, @Nombre = employee.Nombre, @DNI = employee.DNI, @Edad = employee.Edad, @Telefono = employee.Telefono, @Correo = employee.Correo, @Basico = employee.Basico, @Ingreso = employee.Ingreso, @Activo = employee.Activo }).SingleOrDefault();
            return Ok("Se actualizó satisfactoriamente el registro "+employee.Id.ToString()+ " del Empleado");
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmpleado(String id)
        {
            var rpta = (new SqlConnection(new DataBase().StringConnection())).Query<Employee>("sp_ApiRest_Remover @Id", new { @Id = id }).SingleOrDefault();
            return Ok("Se elimino satisfactoriamente el registro "+id.ToString()+" del Empleado");
        }


        [HttpGet]
        [Route("ListEmployees")]
        public List<Employee> ListEmpleados(string? filtro)
        {
            List<Employee> Employees = new List<Employee>();
            filtro = (String.IsNullOrEmpty(filtro)) ? "" : filtro;
            string cnStr = new DataBase().StringConnection();

            var sql = "select * from ApiRest where nombre like '%'+@filtro+'%'"; // "sp_ApiRest_Listar @Filtro";

            //var parameters = new DynamicParameters();
            //parameters.Add("@Filtro", filtro, DbType.String, ParameterDirection.Input, filtro.Length);
            try
            {
                using (SqlConnection cn = new SqlConnection(new DataBase().StringConnection()))
                {
                    //Employees = cn.Query<Employee>(sql, parameters).ToList();
                    Employees = cn.Query<Employee>(sql, new { @Filtro = filtro }).ToList();
                }

                return Employees;

            }
            catch (Exception ex)
            {
                return new List<Employee> { new Employee { Nombre = ex.Message } } ;
            }

            /*
            
            using (SqlConnection cn = new SqlConnection(cnStr))
            {

                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ApiRest_Listar ''"))
                {
                    cmd.Connection = cn;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetValue("Nombre").ToString().Trim() + ", " + dr.GetValue("Edad").ToString().Trim() + ", " + Convert.ToDateTime(dr.GetValue("Ingreso")).ToString("dd/MMM/yyyy").Trim());

                            //l_empleados.Add(new Employee(
                            //    Convert.ToInt32(dr.GetValue("Id")),
                            //    Convert.ToString(dr.GetValue("Nombre")),
                            //    Convert.ToString(dr.GetValue("DNI")),
                            //    Convert.ToInt16(dr.GetValue("Edad")),
                            //    Convert.ToString(dr.GetValue("Telefono")),
                            //    Convert.ToString(dr.GetValue("Correo")),
                            //    Convert.ToDecimal(dr.GetValue("Basico")),
                            //    Convert.ToDateTime(dr.GetValue("Ingreso")),
                            //    Convert.ToBoolean(dr.GetValue("Activo"))
                            //    ));

                            Employee emp = new Employee  // Usar cuando no tiene constructor 
                            {
                                Id = Convert.ToInt32(dr.GetValue("Id")),
                                Nombre = Convert.ToString(dr.GetValue("Nombre")),
                                DNI = Convert.ToString(dr.GetValue("DNI")),
                                Edad = Convert.ToInt16(dr.GetValue("Edad")),
                                Telefono = Convert.ToString(dr.GetValue("Telefono")),
                                Correo = Convert.ToString(dr.GetValue("Correo")),
                                Basico = Convert.ToDecimal(dr.GetValue("Basico")),
                                Ingreso = Convert.ToDateTime(dr.GetValue("Ingreso")),
                                Activo = Convert.ToBoolean(dr.GetValue("Activo"))
                            };
                            l_empleados.Add(emp);
                        }
                    }
                }
                cn.Close();
            }

            return l_empleados.ToList();

            */

        }

    }


    [ApiController]
    [Route("[controller]", Name = "API Employees (Entity Framework)", Order = 1)]
    [DisplayName("API Employees (Entity Framework)")]
    public class EmployeesEntityFrameworkController : ControllerBase
    {

        private readonly EmployeeContext _dbContext;

        public EmployeesEntityFrameworkController(EmployeeContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        [Authorize]
        [Route("Leer")]
        public Employee Leer(int id)
        {
            var _empleados = _dbContext.Employees.FirstOrDefault(e => e.Id == id); ;
            return _empleados;
        }

        [HttpPost]
        [Authorize]
        [Route("Adicionar")]
        public IActionResult AdicionarEmpleado(Employee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
            //return Created("Empleado con Id " + employee.Id.ToString() + " fue creado", employee);
            //return Created(new Uri($"{Request.Path}/{employee.Id}", UriKind.Relative), employee);
            return Created(new Uri($"{Request.Path}/{employee.Id}", UriKind.Relative), "Empleado con Id " + employee.Id.ToString() + " fue creado");
        }

        [HttpPut]
        [Authorize]
        [Route("Editar")]
       //public IActionResult Editar(int id, Employee empleado)
         public IActionResult Editar(Employee empleado)
        {
            /*
            var _empleado = _dbContext.Employees.SingleOrDefault(e => e.Id == empleado.Id);
          //var _empleado = _dbContext.Employees.SingleOrDefault(e => e.Id == id);
            if (_empleado == null)
            {
                return NotFound("Empleado con Id " + empleado.Id.ToString() + " no fue encontrado");
            }
            else
            {
                Ok("Empleado con Id " + empleado.Id.ToString() + " fue encontrado");
            }
            */

            if (empleado.Id == null || empleado.Id == 0)
            {
                return NotFound("Empleado con Id no valido");
            }

            try
            {
                _dbContext.Update(empleado);
                _dbContext.SaveChanges();
                return Ok("Empleado con Id " + empleado.Id.ToString() + " fue editado");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

   
        [HttpDelete]
        [Authorize]
        [Route("Remover")]
        public IActionResult Remover(int id)
        {
            var _empleado = _dbContext.Employees.FirstOrDefault(e => e.Id == id); 
            if (_empleado == null)
            {
                return NotFound("Empleado con Id " + id.ToString() + " no fue encontrado");
            }
            try
            {
                _dbContext.Remove(_empleado);
                _dbContext.SaveChanges();
                return Ok("Empleado con Id " + id.ToString() + " fue removido");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        [Authorize]
        [Route("Listar")]
        public IEnumerable<Employee> Listar(string? filtro)
        {
            if (filtro == null) { filtro = ""; }
            //var _empleados = _dbContext.Employees;
            var _empleados = _dbContext.Employees.Where(e => e.Nombre.Contains(filtro));

            return _empleados.ToArray();
        }

    }



    [ApiController]
    [Route("[controller]")]
    [NonController]
    public class CountriesController : ControllerBase
    {
        private static readonly string[] l_paises = new[] { "PERU", "CHILE", "ARGENTINA", "VENEZUELA", "COLOMBIA", "BRASIL" };

        [HttpGet]
        [Route("GetPaises")]
      //[NonAction]
        public List<Country> GetPaises()
        {
            //IEnumerable<Country> a_paises = new List<Country>() { new Country { CountryName = "ESTADOS UNIDOS" } };
            //IEnumerable<Country> a_paises = new List<Country>() { new Country (countryname: "ESTADOS UNIDOS" ) };
            //List<Country> a_paises = new();
            List<Country> a_paises = new() { new Country(countryname: "ESTADOS UNIDOS") };

            foreach (string o_pais in l_paises)
            {
              //a_paises.Append<Country>(new Country { CountryName = o_pais });
              a_paises.Add(new Country(o_pais));
            }  

            return a_paises.ToList();   
        }

        [HttpGet]
        [Route("GetCountries")]
        public IEnumerable<Country> GetCountries()
        {
            //List<Country> _paises = new List<Country>();
            //List<Country> _paises = new();
            //_paises.Add(new Country("PANAMA"));
            //_paises.Add(new Country("MEXICO"));
            //_paises.Add(new Country("CUBA"));

            //List<Country> _paises = new()
            //   {
            //    new Country{CountryName = "PANAMA"},
            //    new Country{CountryName = "MEXICO"},
            //    new Country{CountryName = "CUBA"},
            //    new Country{CountryName = "NICARAGUA"}
            //   };

            List<Country> _paises = new()
               {
                new Country(countryname: "PANAMA"),
                new Country(countryname: "MEXICO"),
                new Country(countryname: "CUBA"),
                new Country(countryname: "COSTA RICA")
               };

            return _paises.ToArray();
        }

        [HttpGet]
        [Route("GetEmpleados")]
        public List<Employee> GetEmpleados()

        {
            List<Employee> l_empleados = new();

            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration _configuration = builder.Build();
            var cnStr = _configuration.GetConnectionString("DBServer");

            //Console.WriteLine(cnStr);

            using (SqlConnection cn = new SqlConnection(cnStr)) {

                cn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ApiRest_Listar ''"))
                {
                    cmd.Connection = cn; 

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetValue("Nombre").ToString().Trim()+", "+ dr.GetValue("Edad").ToString().Trim() + ", " + Convert.ToDateTime(dr.GetValue("Ingreso")).ToString("dd/MMM/yyyy").Trim());

                            //l_empleados.Add(new Employee(
                            //    Convert.ToInt32(dr.GetValue("Id")),
                            //    Convert.ToString(dr.GetValue("Nombre")),
                            //    Convert.ToString(dr.GetValue("DNI")),
                            //    Convert.ToInt16(dr.GetValue("Edad")),
                            //    Convert.ToString(dr.GetValue("Telefono")),
                            //    Convert.ToString(dr.GetValue("Correo")),
                            //    Convert.ToDecimal(dr.GetValue("Basico")),
                            //    Convert.ToDateTime(dr.GetValue("Ingreso")),
                            //    Convert.ToBoolean(dr.GetValue("Activo"))
                            //    ));

                            Employee emp = new Employee  // Usar cuando no tiene constructor 
                            {
                                Id = Convert.ToInt32(dr.GetValue("Id")),
                                Nombre = Convert.ToString(dr.GetValue("Nombre"))+".",
                                DNI = Convert.ToString(dr.GetValue("DNI")),
                                Edad = Convert.ToInt16(dr.GetValue("Edad")),
                                Telefono = Convert.ToString(dr.GetValue("Telefono")),
                                Correo = Convert.ToString(dr.GetValue("Correo")),
                                Basico = Convert.ToDecimal(dr.GetValue("Basico")),
                                Ingreso = Convert.ToDateTime(dr.GetValue("Ingreso")),
                                Activo = Convert.ToBoolean(dr.GetValue("Activo"))
                            };
                            l_empleados.Add(emp);

                        }
                    }
                }
                cn.Close();
            }

             
            return l_empleados.ToList();
        }
         
    }


    [ApiController]
    [Route("[controller]")]
    [NonController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /*
        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}
        */

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Weather> Get()
        {
            return Enumerable.Range(1, 3).Select(index => new Weather
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public class DataBase
    {
        public string StringConnection ()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            IConfiguration _configuration = builder.Build();

            return _configuration.GetConnectionString("DBServer");
        }
    }

}