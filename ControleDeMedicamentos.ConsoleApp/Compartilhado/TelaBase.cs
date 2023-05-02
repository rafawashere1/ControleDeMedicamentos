namespace ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<T> where T : EntidadeBase
    {
        public string nomeEntidade;
        public string sufixo;

        protected RepositorioBase<T> repositorioBase = null;

        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"[1] Inserir {nomeEntidade}");
            Console.WriteLine($"[2] para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"[3] para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"[4] para Excluir {nomeEntidade}{sufixo}");

            Console.WriteLine("[S] Voltar ao menu principal");

            Console.WriteLine();
            Console.Write("Digite uma opção: ");

            return Console.ReadLine().ToUpper();
        }

        public virtual void VisualizarRegistros(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
                Console.WriteLine();
                Console.WriteLine("Visualizando registros já cadastrados...");
            }

            List<T> registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                Utils.MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow, TipoMensagem.READKEY);
                return;
            }

            MostrarTabela(registros);
        }

        public virtual void InserirNovoRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}s");

            T registro = ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro();

                return;
            }

            repositorioBase.Inserir(registro);

            Utils.MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        public virtual void EditarRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo}");
            Console.WriteLine();
            Console.WriteLine("Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            T registro = EncontrarRegistro("Digite o id do registro: ");

            T registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(registro, registroAtualizado);

            Utils.MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        public virtual void ExcluirRegistro()
        {
            Console.WriteLine($"Cadastro de {nomeEntidade}s");
            Console.WriteLine();
            Console.WriteLine("Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            T registro = EncontrarRegistro("Digite o id do registro: ");

            repositorioBase.Excluir(registro);

            Utils.MostrarMensagem("Registro excluído com sucesso!", ConsoleColor.Green, TipoMensagem.READKEY);
        }

        public virtual T EncontrarRegistro(string mensagem)
        {
            bool idInvalido;

            T registroSelecionado = null;

            do
            {
                idInvalido = false;

                Console.Write("\n" + mensagem);
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());

                    registroSelecionado = repositorioBase.SelecionarPorId(id);

                    if (registroSelecionado == null)
                        idInvalido = true;
                }
                catch (FormatException)
                {
                    idInvalido = true;
                }

                if (idInvalido)
                    Utils.MostrarMensagem("Id inválido, tente novamente", ConsoleColor.Red, TipoMensagem.READKEY);

            } while (idInvalido);

            return registroSelecionado;
        }

        protected bool TemErrosDeValidacao(T registro)
        {
            bool temErros = false;

            List<string> erros = registro.Validar();

            if (erros.Count > 0)
            {
                temErros = true;

                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }

                Console.ResetColor();
                Console.ReadLine();
            }

            return temErros;
        }

        protected abstract T ObterRegistro();

        protected abstract void MostrarTabela(List<T> registros);
    }
}

