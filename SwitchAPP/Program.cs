using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using System;
using Switch.Infra.CrossCutting.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using SwitchAPP.Reports;
using MySql.Data.MySqlClient;

namespace SwitchAPP
{
    class Program
    {
        //CHANGE TRACKER EXIBE TODA MODIFICAÇÃO DO CONTEXTO
        public static void ExibirChangeTracker(ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                Console.WriteLine("Nome da: " + entry.GetType().FullName);
                Console.WriteLine("Status da Entidade: " + entry.State);
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {

            Usuario usuario1;
            Usuario usuario2;
            Usuario usuario3;
            Usuario usuario4;
            Usuario usuario5;
            Usuario usuario6;
            Usuario usuario7;


            Usuario CriarUsuario(string nome)
            {
                return new Usuario()
                {
                    Nome = nome,
                    Sobrenome = "SobreUsuario",
                    Email = "marcelo.ebert@hotmail.com",
                    DataNascimento = DateTime.Now,
                    Sexo = Switch.Domain.Enum.SexoEnum.Masculino,
                    UrlFoto = @"C:\temp",
                    Senha = "123456"
                };
            }

            usuario1 = CriarUsuario("usuario1");
            usuario2 = CriarUsuario("usuario2");
            usuario3 = CriarUsuario("usuario3");
            usuario4 = CriarUsuario("usuario4");
            usuario5 = CriarUsuario("usuario5");
            usuario6 = CriarUsuario("usuario6");
            usuario7 = CriarUsuario("Maria");



            var optionBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionBuilder.UseLazyLoadingProxies();
            optionBuilder.UseMySql("Server=localhost;userid=root;password=123456789;database=SwitchDB", m => m.MigrationsAssembly("Switch.Infra.Data").MaxBatchSize(100));

            //habilita para visualizar o valor dos parametros 
            optionBuilder.EnableSensitiveDataLogging();

            try
            {
                using (var dbcontext = new SwitchContext(optionBuilder.Options))
                {
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());


                    //Inclusão 
                    //ID gerado pelo EF em tempo de execução é temporário até a execução do SaveChanges
                    //dbcontext.Usuarios.Add(usuario7);
                    //dbcontext.Usuarios.AddRange(usuario1,usuario2,usuario3,usuario4,usuario5,usuario6);
                    //dbcontext.SaveChanges();

                    //Consulta
                    // DEVOLVER LISTA DE TODOS OS USUÁRIOS
                    //var resultado = dbcontext.Usuarios.ToList();

                    //DEVOLVER OBJETO FILTRADO
                    //var resultado = dbcontext.Usuarios.Where(u => u.Nome == "usuario1");

                    //DEVOLVE O PRIMEIRO REGISTRO DA CONSULTA, SE NÃO HOUVER NENHUM ESTOURA EXCEÇÃO
                    //var resultado = dbcontext.Usuarios.First();

                    //DEVOLVE O PRIMEIRO REGISTRO DA CONSULTA, SE NÃO HOUVER, VOLTA NULL
                    //var resultado = dbcontext.Usuarios.FirstOrDefault();

                    //DEVOLVE O PRIMEIRO REGISTRO DA CONSULTA, SE NÃO HOUVER, ESTOURA EXCEÇÃO
                    //var resultado = dbcontext.Usuarios.Single();

                    //DEVOLVE O PRIMEIRO REGISTRO DA CONSULTA, SE NÃO HOUVER, VOLTA NULL
                    //var resultado = dbcontext.Usuarios.SingleOrDefault();

                    //DEVOLVE O INTEIRO COM QUANTIDADE DE RESULTADOS
                    //var resultado = dbcontext.Usuarios.Count(U => U.Nome == "USUARIO1");

                    //EXIBIR STATUS DO CHANGETRACKER
                    //ExibirChangeTracker(dbcontext.ChangeTracker);

                    //Remover
                    //var usuario = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuario1");
                    //dbcontext.Usuarios.Remove(usuario);
                    //dbcontext.Remove<Usuario>(usuario);
                    //dbcontext.SaveChanges();

                    //Atualizar
                    //var usuario = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuario1");
                    //usuario.Nome = "teste alterando";                    
                    //dbcontext.SaveChanges(); // Gera Update mais performatico somente da coluna alterada
                    //dbcontext.Update<Usuario>(usuario); // gera update mais lentos da tabela toda

                    //Evento para retornar estado da conexão
                    //dbcontext.Database.GetDbConnection().StateChange += Program_StateChange;

                    //Atualização com relacionamento
                    //var userMaria = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Maria");
                    //var instituicaoEnsino = dbcontext.InstituicoesEnsino.FirstOrDefault(u => u.Nome.Contains("Faculdade Direito"));
                    //instituicaoEnsino.Nome = "Fac. Direito";

                    //userMaria.InstituicoesEnsino.Add(new InstituicaoEnsino { Nome = "Faculdade Direito" });
                    //userMaria.InstituicoesEnsino.Add(new InstituicaoEnsino { Nome = "Faculdade Medicina" });


                    //Exclusão com relacionamento
                    //var userMaria = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Maria");
                    //var instituicaoEnsino = userMaria.InstituicoesEnsino.FirstOrDefault(i => i.Nome.Contains("Fac. Direito"));
                    //userMaria.InstituicoesEnsino.Remove(instituicaoEnsino);

                    //dbcontext.SaveChanges();


                    //Consulta SQL
                    //var sqlCommand = "select nome, sobrenome from usuarios";
                    //var usuarios = dbcontext.Usuarios.FromSql(sqlCommand).ToList();

                    //Consulta com Projeção de SQL
                    //var sql = "select nome, sobrenome from usuarios";
                    //var connection = dbcontext.Database.GetDbConnection();
                    //var listaUsuarios = new List<UsuarioDTO>();

                    //using (var command = connection.CreateCommand())
                    //{
                    //    connection.Open();
                    //    command.CommandText = sql;
                    //    using (var dataReader = command.ExecuteReader())
                    //    {
                    //        if(dataReader.HasRows)
                    //        {
                    //            while(dataReader.Read())
                    //            {
                    //                var usuarioDTO = new UsuarioDTO();
                    //                usuarioDTO.Nome = dataReader["nome"].ToString();
                    //                usuarioDTO.SobreNome = dataReader["SobreNome"].ToString();
                    //                listaUsuarios.Add(usuarioDTO);
                    //            }
                    //        }
                    //    }

                    //}



                    //Consulta com parametros
                    //var sql = "select nome, sobrenome from usuarios where nome = @nomeUsuario";
                    //var connection = dbcontext.Database.GetDbConnection();
                    //var listaUsuarios = new List<UsuarioDTO>();
                    //var filtroPesquisa = "' or 1='";

                    //using (var command = connection.CreateCommand())
                    //{
                    //    connection.Open();
                    //    command.CommandText = sql;

                    //    MySqlParameter param = new MySqlParameter("@nomeUsuario", MySqlDbType.VarChar);
                    //    param.Value = filtroPesquisa;
                    //    command.Parameters.Add(param);

                    //    using (var dataReader = command.ExecuteReader())
                    //    {
                    //        if (dataReader.HasRows)
                    //        {
                    //            while (dataReader.Read())
                    //            {
                    //                var usuarioDTO = new UsuarioDTO();
                    //                usuarioDTO.Nome = dataReader["nome"].ToString();
                    //                usuarioDTO.SobreNome = dataReader["SobreNome"].ToString();
                    //                listaUsuarios.Add(usuarioDTO);
                    //            }
                    //        }
                    //    }

                    //}


                    ////Consulta com procedures
                    //var sql = "call spObterTodosUsuarios()";
                    //var connection = dbcontext.Database.GetDbConnection();
                    //var listaUsuarios = new List<UsuarioDTO>();
                    //var filtroPesquisa = "' or 1='";

                    //using (var command = connection.CreateCommand())
                    //{
                    //    connection.Open();
                    //    command.CommandText = sql;

                    //    MySqlParameter param = new MySqlParameter("@nomeUsuario", MySqlDbType.VarChar);
                    //    param.Value = filtroPesquisa;                        
                    //    using (var dataReader = command.ExecuteReader())
                    //    {
                    //        if (dataReader.HasRows)
                    //        {
                    //            while (dataReader.Read())
                    //            {
                    //                var usuarioDTO = new UsuarioDTO();
                    //                usuarioDTO.Nome = dataReader["nome"].ToString();
                    //                usuarioDTO.SobreNome = dataReader["SobreNome"].ToString();
                    //                listaUsuarios.Add(usuarioDTO);
                    //            }
                    //        }
                    //    }

                    //}



                    //Consulta procedures com parametros                
                    var connection = dbcontext.Database.GetDbConnection();
                    var listaUsuarios = new List<UsuarioDTO>();                    

                    using (var command = connection.CreateCommand())
                    {

                        var sql = "call spObterUsuario(@usuarioId)";
                        MySqlParameter param = new MySqlParameter("@usuarioId", MySqlDbType.Int32);
                        param.Value = 10;

                        connection.Open();
                        command.CommandText = sql;
                        command.Parameters.Add(param);
                        
                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    var usuarioDTO = new UsuarioDTO();
                                    usuarioDTO.Nome = dataReader["nome"].ToString();
                                    usuarioDTO.SobreNome = dataReader["SobreNome"].ToString();
                                    listaUsuarios.Add(usuarioDTO);
                                }
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }         

            
        }

        private static void Program_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine("Estado Atual de conexão: " + e.CurrentState);
        }
    }
}
