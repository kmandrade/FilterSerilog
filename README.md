# FilterSerilog

Esta lib irá permitir a geração de dois tipos de arquivos txt de log, um com os logs de todos os níveis mínimos e outro apenas com os logs de níves: Erro, Warning e Fatal.
Permitindo mais facilidade ao identificar problemas na aplicação por meio de logs, utilizando Serilog.

Para conseguir utilizar precisa seguir os seguintes passos:

        *Baixar o pacote nuget: dotnet add package Util.Filter.LogSerilog --version 1.0.0;
        
        *Adicionar a referência da lib baixada na classe de startup da aplicação;
        
        *Adicionar no AppSettings da api a configuração do Serilog que irá permitir ou não a geração dos logs completos a desejo de quem estiver configurando;
                "Serilog": {
                    "Enabled": true
                  }
        *Adicionar na classe de startup da aplicação a nova configuração do Serilog:
                builder.Services.AddSerilog(ConfigurationSerilog.ConfigureSerilog(builder.Configuration));
