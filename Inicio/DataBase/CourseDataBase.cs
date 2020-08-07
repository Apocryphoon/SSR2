using Inicio.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inicio.DataBase
{
    public class ClienteDatabase
    {
        public void Salvar(ClienteDTO trab)
        {
            string query = "insert into tb_cliente (nm_name, nr_phone, nr_cellphone, nr_cep, nr_cpf, ds_uf, ds_email) VALUES (@name, @phone, @cellphone, @cep, @cpf, @uf, @email)";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("name", trab.Nome));
            param.Add(new MySqlParameter("phone", trab.Telefone));
            param.Add(new MySqlParameter("cellphone", trab.Celular));
            param.Add(new MySqlParameter("cep", trab.Cep));
            param.Add(new MySqlParameter("cpf", trab.Cpf));
            param.Add(new MySqlParameter("uf", trab.Estado));
            param.Add(new MySqlParameter("email", trab.Email));


            Database db = new Database();
            db.ExecuteInsert(query, param);
        }

        public void Salvar(DTOUser vam)
        {

            string query = "insert into consultarcartao (nm_name, nr_cpf, ds_email, nr_valor, dt_data, nr_vezes) VALUES (@name, @cpf, @email, @valor, @data, @vezes)";
            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("name", vam.Nome));
            param.Add(new MySqlParameter("cpf", vam.Cpf));
            param.Add(new MySqlParameter("email", vam.Email));
            param.Add(new MySqlParameter("valor", vam.Valor));
            param.Add(new MySqlParameter("vezes", vam.Vezes));
            param.Add(new MySqlParameter("data", vam.Data));

            Database db = new Database();
            db.ExecuteInsert(query, param);

        }

        public void Salvar(FudeuDTO hist)
        {
            string query = "insert into tb_historico (ds_estetico, ds_alergico, ds_tratamento, ds_acido, ds_cuidados, ds_fumante, ds_queloide, ds_gestante, ds_diabete, ds_sol, nm_Textbox, bl_respostaum, bl_respostadois, bl_respostatres, bl_respostaquatro, bl_respostacinco, bl_respostaseis, bl_respostasete, bl_respostaoito, bl_respostanove, bl_respostadez VALUES @estetico, @alergico, @tratamento, @acido, @cuidados, @fumante, @queloide, @gestante, @diabete, @sol, @textbox, @respostaum, @respostadois, @respostatres, @respostaquatro, @respostacinco, @respostaseis, @respostasete, @respostaoito, @respostanove, @respostadez)";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("estetico", hist.Historicoum));
            param.Add(new MySqlParameter("alergico", hist.Historicodois));
            param.Add(new MySqlParameter("tratamento", hist.Historicotres));
            param.Add(new MySqlParameter("acido", hist.Historicoquatro));
            param.Add(new MySqlParameter("cuidados", hist.Historicocinco));
            param.Add(new MySqlParameter("fumante", hist.Historicoseis));
            param.Add(new MySqlParameter("queloide", hist.Historicosete));
            param.Add(new MySqlParameter("gestante", hist.Historicoito));
            param.Add(new MySqlParameter("diabete", hist.Historiconove));
            param.Add(new MySqlParameter("sol", hist.Historicodez));

            param.Add(new MySqlParameter("textbox", hist.Textbox));

            param.Add(new MySqlParameter("respostaum", hist.Radioum));
            param.Add(new MySqlParameter("respostadois", hist.Radiodois));
            param.Add(new MySqlParameter("respostatres", hist.Radiotres));
            param.Add(new MySqlParameter("respostaquatro", hist.Radioquatro));
            param.Add(new MySqlParameter("respostacinco", hist.Radiocinco));
            param.Add(new MySqlParameter("respostaseis", hist.Radioseis));
            param.Add(new MySqlParameter("respostasete", hist.Radiosete));
            param.Add(new MySqlParameter("respostaoito", hist.Radioito));
            param.Add(new MySqlParameter("respostanove", hist.Radionove));
            param.Add(new MySqlParameter("respostadez", hist.Radiodez));


            Database db = new Database();
            db.ExecuteInsert(query, param);
        }

        public List<ClienteDTO> Listar()
        {
            string script = "Select * from tb_cliente";


            Database d = new Database();
            MySqlDataReader r = d.ExecuteSelect(script, null);

            List<ClienteDTO> itens = new List<ClienteDTO>();

            while (r.Read())
            {
                ClienteDTO t = new ClienteDTO();
                t.Id = r.GetInt32("id_cliente");
                t.Nome = r.GetString("nm_name");
                t.Telefone = r.GetString("nr_phone");
                t.Celular = r.GetString("nr_cellphone");
                t.Cep = r.GetString("nr_cep");
                t.Estado = r.GetString("ds_uf");
                t.Email = r.GetString("ds_email");
                t.Cpf = r.GetString("nr_cpf");

                itens.Add(t);
            }
            return itens;
        }

        public List<ClienteDTO> Filtro(string nome, string cpf)
        {
            string script = "SELECT * FROM tb_cliente WHERE nm_name like @nome and nr_cpf like @cpf";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("nome", "%" + nome + "%"));
            param.Add(new MySqlParameter("cpf", "%" + cpf + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelect(script, param);

            List<ClienteDTO> itens = new List<ClienteDTO>();

            while (reader.Read())
            {
                ClienteDTO c = new ClienteDTO();
                c.Id = reader.GetInt32("id_cliente");
                c.Nome = reader.GetString("nm_name");
                c.Telefone = reader.GetString("nr_phone");
                c.Celular = reader.GetString("nr_cellphone");
                c.Cep = reader.GetString("nr_cep");
                c.Estado = reader.GetString("ds_uf");
                c.Email = reader.GetString("ds_email");
                c.Cpf = reader.GetString("nr_cpf");

                itens.Add(c);
            }
            return itens;
        }

        public List<ClienteDTO> Filtrar(string nome, string cpf)
        {
            string script = "select * from tb_cliente where nm_name like @name and nr_cpf like @cpf";

            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("name", "%" + nome + "%"));
            param.Add(new MySqlParameter("cpf", "%" + cpf + "%"));

            Database db = new Database();
            MySqlDataReader reader = db.ExecuteSelect(script, param);

            List<ClienteDTO> c = new List<ClienteDTO>();
            while (reader.Read() == true)
            {
                ClienteDTO cliente = new ClienteDTO();

                cliente.Id = reader.GetInt32("id_cliente");
                cliente.Nome = reader.GetString("nm_name");
                cliente.Telefone = reader.GetString("nr_phone");
                cliente.Celular = reader.GetString("nr_cellphone");
                cliente.Estado = reader.GetString("ds_uf");
                cliente.Email = reader.GetString("ds_email");
                cliente.Cep = reader.GetString("nr_cep");
                cliente.Cpf = reader.GetString("nr_cpf");

                c.Add(cliente);
            }

            return c;
        }

        public void Alterar(ClienteDTO dto)
        {
            string script = " Update tb_cliente set" +
                " nm_name = @name," +
                " nr_phone = @phone," +
                " nr_cellphone = @cellphone," +
                " nr_cep = @cep," +
                " ds_uf = @uf," +
                " nr_cpf = @cpf," +
                " ds_email = @email WHERE" +
                " id_cliente = @id";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id", dto.Id));
            parameters.Add(new MySqlParameter("name", dto.Nome));
            parameters.Add(new MySqlParameter("phone", dto.Telefone));
            parameters.Add(new MySqlParameter("cellphone", dto.Celular));
            parameters.Add(new MySqlParameter("cep", dto.Cep));
            parameters.Add(new MySqlParameter("uf", dto.Estado));
            parameters.Add(new MySqlParameter("email", dto.Email));
            parameters.Add(new MySqlParameter("cpf", dto.Cpf));

            Database db = new Database();
            db.ExecuteInsert(script, parameters);
        }

        public void Remover(int id)
        {
            string script = "DELETE FROM tb_cliente where id_cliente = @id";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id", id));

            Database db = new Database();
            db.ExecuteInsert(script, parameters);
        }
    }
}
