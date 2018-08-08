Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Return View()
        End Function

        Function Lista() As ActionResult
            Return View()
        End Function

        Function Consulta() As ActionResult
            Return View()
        End Function


        Public Function GetPessoas() As JsonResult

            Using ctx1 As New CadastroEntities

                Try

                    Dim pessoas = ctx1.pessoas.ToList()

                    Return Json(pessoas, JsonRequestBehavior.AllowGet)
                Catch ex As Exception
                    Throw ex
                End Try

            End Using
        End Function


        <HttpPost>
        Public Function ConsultaPessoa(novoPessoa As pessoa) As ActionResult
            Try
                Using ctx As New CadastroEntities
                    Using ctx1 As New CadastroEntities4

                        Dim Epessoa = ctx.pessoas.Find(novoPessoa.id_pessoa)

                        Dim endereco = ctx1.enderecoes.Find(novoPessoa.id_pessoa)

                        Epessoa.endereco = New endereco

                        Epessoa.endereco.bairro = endereco.bairro
                        Epessoa.endereco.cep = endereco.cep
                        Epessoa.endereco.logradouro = endereco.logradouro
                        Epessoa.endereco.municipio = endereco.municipio
                        Epessoa.endereco.numero = endereco.numero
                        Epessoa.endereco.uf = endereco.uf


                        Return Json(Epessoa, JsonRequestBehavior.AllowGet)

                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function

        <HttpPost>
        Public Function ConsultaTelefone(novoPessoa As pessoa) As ActionResult
            Try
                Using ctx As New CadastroEntities1

                    Dim telefones = ctx.telefones.SqlQuery("select * from telefones where id_pessoa = " & CStr(novoPessoa.id_pessoa))

                    Dim telefone = telefones.ToList()



                    'telefones.ToList()

                    Return Json(telefone, JsonRequestBehavior.AllowGet)

                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function

        <HttpPost>
        Public Function AlteraPessoa(novoPessoa As pessoa) As JsonResult
            Using ctx As New CadastroEntities5
                Try

                    Dim pessoa = ctx.pessoa.Find(novoPessoa.id_pessoa)

                    pessoa.nome = novoPessoa.nome
                    pessoa.cpf = novoPessoa.cpf
                    pessoa.rg = novoPessoa.rg
                    pessoa.endereco.bairro = novoPessoa.endereco.bairro
                    pessoa.endereco.cep = novoPessoa.endereco.cep
                    pessoa.endereco.logradouro = novoPessoa.endereco.logradouro
                    pessoa.endereco.municipio = novoPessoa.endereco.municipio
                    pessoa.endereco.numero = novoPessoa.endereco.numero
                    pessoa.endereco.uf = novoPessoa.endereco.uf

                    ctx.SaveChanges()


                    'Dim produtos = ctx.Produtos.ToList()
                    Return Json(novoPessoa, JsonRequestBehavior.AllowGet)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

        End Function

        <HttpPost>
        Public Function ExcluiTelefone(novoTelefone As telefone) As JsonResult
            Using ctxTelefone As New CadastroEntities1

                Try

                    Dim Etelefone = ctxTelefone.telefones.Find(novoTelefone.id_telefone)
                    ctxTelefone.telefones.Remove(Etelefone)
                    ctxTelefone.SaveChanges()

                    Dim telefones = ctxTelefone.telefones.SqlQuery("select * from telefones where id_pessoa = " & CStr(novoTelefone.id_pessoa))

                    Dim telefoness = telefones.ToList()

                    Return Json(telefoness, JsonRequestBehavior.AllowGet)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

        End Function

        'Incluir pessoa
        <HttpPost>
        Public Function IncluirPessoa(novoPessoa As pessoa) As JsonResult
            Using ctx As New CadastroEntities5
                Try

                    Dim pes As New pessoa() With {
                        .nome = novoPessoa.nome,
                        .cpf = novoPessoa.cpf,
                        .rg = novoPessoa.rg
                    }

                    Dim pesss As New pessoa()



                    ctx.pessoa.Add(pes)

                    ctx.endereco.Add(New endereco() With {
                          .cep = novoPessoa.endereco.cep,
                          .logradouro = novoPessoa.endereco.logradouro,
                           .numero = novoPessoa.endereco.numero,
                           .bairro = novoPessoa.endereco.bairro,
                          .municipio = novoPessoa.endereco.municipio,
                    .uf = novoPessoa.endereco.uf
                      })

                    ctx.SaveChanges()

                    novoPessoa.id_pessoa = pes.id_pessoa

                    Return Json(novoPessoa, JsonRequestBehavior.AllowGet)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

        End Function


        <HttpPost>
        Public Function IncluirTelefone(novoTelefone As telefone) As JsonResult
            Using ctxTelefone As New CadastroEntities1

                Try

                    Dim telefone = New telefone() With {
                        .numero = novoTelefone.numero,
                        .tipo = novoTelefone.tipo,
                    .id_pessoa = novoTelefone.id_pessoa
                    }


                    ctxTelefone.telefones.Add(telefone)

                    ctxTelefone.SaveChanges()

                    Dim telefones = ctxTelefone.telefones.SqlQuery("select * from telefones where id_pessoa = " & CStr(novoTelefone.id_pessoa))

                    Dim telefoness = telefones.ToList()


                    'Dim produtos = ctx.Produtos.ToList()
                    Return Json(telefoness, JsonRequestBehavior.AllowGet)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using

        End Function

        <HttpPost>
        Public Function ExcluirPessoa(delPessoa As pessoa) As JsonResult
            Using ctx As New CadastroEntities
                Using ctx2 As New CadastroEntities1
                    Using ctx3 As New CadastroEntities4

                        Try

                            Dim telefones = ctx2.telefones.SqlQuery("select * from telefones where id_pessoa = " & CStr(delPessoa.id_pessoa))

                            ctx2.telefones.RemoveRange(telefones)
                            ctx2.SaveChanges()

                            Dim enderecos = ctx3.enderecoes.SqlQuery("select * from endereco where id_pessoa = " & CStr(delPessoa.id_pessoa))

                            ctx3.enderecoes.RemoveRange(enderecos)
                            ctx3.SaveChanges()


                            Dim Epessoa = ctx.pessoas.Find(delPessoa.id_pessoa)
                            ctx.pessoas.Remove(Epessoa)
                            ctx.SaveChanges()
                            Dim pessoas = ctx.pessoas.ToList()
                            Return Json(pessoas, JsonRequestBehavior.AllowGet)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                End Using
            End Using
        End Function

    End Class
End Namespace