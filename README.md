# FilterSerilog

Esta lib irá permitir a geração de dois tipos de arquivos txt de log, um com os logs de todos os níveis mínimos e outro apenas com os logs de níveis: Erro, Warning e Fatal.
Permitindo mais facilidade ao identificar problemas na aplicação por meio de logs, utilizando Serilog.

OBS.: Nesta configuração foi adicionada uma restrição para ocultar informações de IP caso seja fornecida no log, afim de exemplificar a exclusão de alguma string específica, como nesse caso foi definido que caso na string do log contenha "IP" será excluída por completo (apenas nos logs filtrados).

Para conseguir utilizar precisa seguir os seguintes passos:

        *Baixar o pacote nuget: NuGet\Install-Package Util.Filter.LogSerilog -Version 1.0.0
        
        *Adicionar a referência da lib baixada na classe de startup da aplicação;
        
        *Adicionar no AppSettings da api a configuração do Serilog que irá permitir ou não a geração dos logs completos da aplicação
        e também que irá permitir mudar o caminho do arquivo por meio do AppSettings.
                "Serilog": {
                  "Enabled": true,
                  "FilePath": "../logs/"
                }
        *Adicionar na classe de startup da aplicação a nova configuração do Serilog:
                builder.Services.AddSerilog(ConfigurationSerilog.ConfigureSerilog(builder.Configuration));

