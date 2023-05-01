//using ApiRestService.Models;
using ApiRestDesktopClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

//using JsonSerializer = System.Text.Json.JsonSerializer;

//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations.Schema;


namespace ApiRestDesktopClient;


// In the class
//static HttpClient clientC = new HttpClient();

public partial class frmApiRest : Form
{
    string JWT = "";

    public frmApiRest()
    {
        InitializeComponent();
    }

    private async void frm_Load(object sender, EventArgs e)

    {
        Login login = new();
        login.Username = "Elmer";
        login.Password = "Pass123";

        btnNuevo.Enabled = false;
        btnFiltrar.Enabled = false;
        btnElimnar.Enabled = false;
        btnGuardar.Enabled = false;

        JWT = (await GenerateJWT(login)).ToString().Replace("\"", "");

      //MessageBox.Show(JWT);

        btnNuevo.Enabled = true;
        btnFiltrar.Enabled = true;
        btnElimnar.Enabled = true;
        btnGuardar.Enabled = true;

        btnFiltrar.PerformClick();

        //AllocConsole(); //Muestra Consola
        //Console.Clear();
        //Console.WriteLine("Token Generado:");
        //Console.WriteLine(JWT);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();


    private async void btnFiltrar_Click(object sender, EventArgs e)

    {

        //GetEmployeesAsync(textBox1.Text);
        //GetEmployeesDapper(textBox1.Text);


        //dataGridView1.DataSource = GetEmployeesSync(textBox1.Text);
        //dataGridView1.DataSource = await GetEmployeesAsync(textBox1.Text);


        //dataGridView1.DataSource = await GetEmployeesDapper(textBox1.Text);
        //dgvEmpleados.DataSource = await GetEmployeesEntityFramework(txtFiltro.Text, JWT);

        dgvEmpleados.DataSource = await ListEmployeesEntityFramework(txtFiltro.Text, JWT);


        //Se quedaba colgado con 
        //var Task = GenerateTokenAsync(login);
        //var result = await Task; 
        //MessageBox.Show(result,"JWT Async - PostAsync1");

        /*
        //Funcionan los 3 
        //GenerateTokenAsync(login);
        MessageBox.Show(await GenerateTokenAsync(login), "JWT Async - PostAsync");
        MessageBox.Show(GenerateTokenSync(login), "JWT Sync - PostAsync");
        MessageBox.Show(GenerateTokenSyncSend(login), "JWT Sync - Send");
        */

        //GetEmployeesEntityFramework(textBox1.Text);

        for (int i = 0; i <= dgvEmpleados.Columns.Count - 1; i++)
        {
            //dataGridView1.Columns[i].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
            dgvEmpleados.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

    }

    List<Employee> GetEmployeesSync(string filtro)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/EmployeesDapper/";
        string path_api = "ListEmployees?filtro=" + filtro;
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, path_api);

        var response = client.GetAsync(path_api).GetAwaiter().GetResult();
        Console.WriteLine(response);
        var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        Console.WriteLine(result);
        List<Employee> data = JsonConvert.DeserializeObject<List<Employee>>(result);
        //dataGridView1.DataSource = data;
        Console.WriteLine(data);
        return data;
    }

    async Task<List<Employee>> GetEmployeesAsync(string filtro)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/EmployeesDapper/";
        string path_api = "ListEmployees?filtro=" + filtro;
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var result = await client.GetStringAsync(path_api);
        List<Employee> data = JsonConvert.DeserializeObject<List<Employee>>(result);
        //dataGridView1.DataSource = data;
        return data;
    }


    async Task<List<Employee>> GetEmployeesDapper(string filtro)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/EmployeesDapper/";
        string path_api = "ListEmployees?filtro=" + filtro;
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.GetAsync(path_api);
        var response_str = await client.GetStringAsync(path_api);
        var data = JsonConvert.DeserializeObject<List<Employee>>(response_str);
        //dataGridView1.DataSource = data;
        return data;

        /*

         GET: GetAsync, GetStringAsync, GetByteArrayAsync, GetStreamAsync
         POST: PostAsync, PostAsJsonAsync, PostAsXmlAsync
         PUT: PutAsync, PutAsJsonAsync, PutAsXmlAsync
         DELETE: DeleteAsync
         Another HTTP method: Send

         // Assuming http://localhost:4354/api/ as BaseAddress // METODO GET 
         var response = await client.GetAsync("products");

         or

         // Assuming http://localhost:4354/api/ as BaseAddress // METODO POST 
         var product = new Product() { Name = "P1", Price = 100, Category = "C1" };
         var response = await client.PostAsJsonAsync("products", product);

         */

    }

    async Task<List<Employee>> GetEmployeesEntityFramework(string filtro, string JWT)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/EmployeesEntityFramework/";
        string path_api = "Listar?filtro=" + filtro;
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);

        var response = await client.GetAsync(path_api);
        var response_str = await client.GetStringAsync(path_api);
        var data = JsonConvert.DeserializeObject<List<Employee>>(response_str);
        dgvEmpleados.DataSource = data;
        return data;


    }


    async Task<string> GenerateTokenAsync(Login login)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/Login/";
        string path_api = "AuthToken";

        //var payload = "{\"username\": \"Elmer\",\"password\": \"Pass123\"}";
        var payload = "{\"username\": \"" + login.Username + "\",\"password\": \"" + login.Password + "\"}";



        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

        /*
        var result = await client.PostAsync(path_api, content);
        result.EnsureSuccessStatusCode();
        var response = await result.Content.ReadAsStringAsync();
        var deserializedToken = DeserializeResponse<string>(response);
        */

        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.PostAsync(path_api, content);
        //MessageBox.Show(response.ToString(), "JWT Async");
        var response_str = await response.Content.ReadAsStringAsync();
        //MessageBox.Show(response_str.ToString(), "JWT Async - PostAsync");
        return response_str;

    }



    string GenerateTokenSync(Login login)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/Login/";
        string path_api = "AuthToken";

        //var payload = "{\"username\": \"Elmer\",\"password\": \"Pass123\"}";
        var payload = "{\"username\": \"" + login.Username + "\",\"password\": \"" + login.Password + "\"}";
        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");


        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var response = client.PostAsync(path_api, content);
        //MessageBox.Show(response.ToString(), "JWT Sync");

        var response_stream = response.Result.Content.ReadAsStream();
        //StreamReader reader = new StreamReader(response_stream);
        //string response_str = reader.ReadToEnd();
        string response_str = (new StreamReader(response_stream)).ReadToEnd();
        //MessageBox.Show(response_str.ToString(), "JWT Sync");
        return response_str;

    }


    string GenerateTokenSyncSend(Login login)
    {
        HttpClient client = new HttpClient();
        string path_base = "https://localhost:7234/Login/";
        string path_api = "AuthToken";

        //var payload = "{\"username\": \"Elmer\",\"password\": \"Pass123\"}";
        var payload = "{\"username\": \"" + login.Username + "\",\"password\": \"" + login.Password + "\"}";
        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");


        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        var request = new HttpRequestMessage(HttpMethod.Post, path_base + path_api);
        request.Content = content;

        var response = client.Send(request);
        response.EnsureSuccessStatusCode();
        var response_stream = response.Content.ReadAsStream();
        string response_str = (new StreamReader(response_stream)).ReadToEnd();

        //MessageBox.Show(response_str, "JWT Sync POST");

        return response_str;

    }



    /* ------------------------------------- EVENTOS CLIENTE -----------------------------------------------*/

    private void dtpIngreso_ValueChanged(object sender, EventArgs e)
    { txtIngreso.Text = dtpIngreso.Text; }

    private void chkActivo_CheckedChanged(object sender, EventArgs e)
    { txtActivo.Text = (chkActivo.Checked) ? "True" : "False"; }

    private void dgvEmpleados_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        txtId.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        txtNombre.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
        txtDni.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
        txtEdad.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Edad"].Value.ToString();
        txtTelefono.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
        txtCorreo.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
        txtBasico.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Basico"].Value.ToString();
        txtIngreso.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Ingreso"].Value.ToString();
        txtActivo.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Activo"].Value.ToString();
        chkActivo.Checked = (txtActivo.Text.ToLower() == "true") ? true : false;
    }

    private void btnNuevo_Click(object sender, EventArgs e)
    {
        txtId.Text = "0";
        txtNombre.Text = "";
        txtDni.Text = "";
        txtEdad.Text = "0";
        txtTelefono.Text = "";
        txtCorreo.Text = "";
        txtBasico.Text = "0.00";
        txtIngreso.Text = (DateTime.Now).ToString("dd/MM/yyyy hh:mm");
        txtActivo.Text = "";
        chkActivo.Checked = false;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        var rpta = MessageBox.Show("Esta Ud. seguro en guardar esta informacion ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (Convert.ToString(rpta) == "OK")
        {
            Employee empleado = DataBind();
            if (empleado != null)
            {
                if (empleado.Id == 0)
                {
                    MessageBox.Show((await CreateEmployeesEntityFramework(empleado, JWT)).Replace("\"", ""), "API Rest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show((await SaveEmployeesEntityFramework(empleado, JWT)).Replace("\"", ""), "API Rest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            btnFiltrar.PerformClick();
        }
    }

    private async void btnElimnar_Click(object sender, EventArgs e)
    {
        var rpta = MessageBox.Show("Esta Ud. seguro en eliminar esta informacion ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (Convert.ToString(rpta) == "OK")
        {
            MessageBox.Show((await DeleteEmployeesEntityFramework(Convert.ToInt32(txtId.Text), JWT)).Replace("\"", ""), "API Rest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnFiltrar.PerformClick();
        }
    }

    private Employee DataBind()
    {
        Employee empleado = new();
        empleado.Id = Convert.ToInt32(txtId.Text);
        empleado.Nombre = Convert.ToString(txtNombre.Text);
        empleado.Nombre = Convert.ToString(txtNombre.Text);
        empleado.DNI = Convert.ToString(txtDni.Text);
        empleado.Edad = Convert.ToInt16(txtEdad.Text);
        empleado.Telefono = Convert.ToString(txtTelefono.Text);
        empleado.Correo = Convert.ToString(txtCorreo.Text);
        empleado.Basico = Convert.ToDecimal(txtBasico.Text);
        empleado.Ingreso = Convert.ToDateTime(txtIngreso.Text);
        empleado.Activo = Convert.ToBoolean(txtActivo.Text);
        return empleado;
    }




    /* ------------------------------------- CONSUMO API REST ----------------------------------------------*/


    async Task<string> GenerateJWT(Login login)
    {
        HttpClient client = new HttpClient();
        string path_base = System.Configuration.ConfigurationSettings.AppSettings["UrlApiLogin"]; //"https://localhost:7234/Login/";
        string path_api = "AuthToken";
        var payload = "{\"username\": \"" + login.Username + "\",\"password\": \"" + login.Password + "\"}";
        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.PostAsync(path_api, content);
        var response_str = await response.Content.ReadAsStringAsync();
        return response_str;
    }

    async Task<List<Employee>> ListEmployeesEntityFramework(string filtro, string JWT)
    {
        HttpClient client = new HttpClient();
        string path_base = System.Configuration.ConfigurationSettings.AppSettings["UrlApiEntityFramework"]; // "https://localhost:7234/EmployeesEntityFramework/";
        string path_api = "Listar?filtro=" + filtro;
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
        var response = await client.GetAsync(path_api);
        var response_str = await client.GetStringAsync(path_api);
        var data = JsonConvert.DeserializeObject<List<Employee>>(response_str);
        return data;
    }

    async Task<string> CreateEmployeesEntityFramework(Employee empleado, string JWT)
    {
        HttpClient client = new HttpClient();
        string path_base = System.Configuration.ConfigurationSettings.AppSettings["UrlApiEntityFramework"]; // "https://localhost:7234/EmployeesEntityFramework/";
        string path_api = "Adicionar";
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
        string jsonString = System.Text.Json.JsonSerializer.Serialize(empleado);
        HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(path_api, content);
        var response_str = await response.Content.ReadAsStringAsync();
        return response_str;
    }


    async Task<string> SaveEmployeesEntityFramework(Employee empleado, string JWT)
    {
        HttpClient client = new HttpClient();
        string path_base = System.Configuration.ConfigurationSettings.AppSettings["UrlApiEntityFramework"]; // "https://localhost:7234/EmployeesEntityFramework/";
        string path_api = "Editar";
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
        string jsonString = System.Text.Json.JsonSerializer.Serialize(empleado);
        HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(path_api, content);
        var response_str = await response.Content.ReadAsStringAsync();
        return response_str;
    }


    async Task<string> DeleteEmployeesEntityFramework(int id, string JWT)
    {
        HttpClient client = new HttpClient();
        string path_base = System.Configuration.ConfigurationSettings.AppSettings["UrlApiEntityFramework"]; // "https://localhost:7234/EmployeesEntityFramework/";
        string path_api = "Remover?id=" + id.ToString();
        client.BaseAddress = new Uri(path_base);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
        var response = await client.DeleteAsync(path_api);
        var response_str = await response.Content.ReadAsStringAsync();
        return response_str;
    }


    /* ------------------------------------- OBJECT RELATIONAL MAPPING -------------------------------------*/


    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public string? Nombre { get; set; }
    //    public string? DNI { get; set; }
    //    public short? Edad { get; set; }
    //    public string? Telefono { get; set; }
    //    public string? Correo { get; set; }
    //    public decimal? Basico { get; set; }
    //    public DateTime? Ingreso { get; set; }
    //}

}