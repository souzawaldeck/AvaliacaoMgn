<br><br>
<h1 align="center">Consulta</h1>
<div ng-controller="consultaCtrl" class="container box">

    <div class="table-responsive">
        <div ng-if="cadastrosucesso">
            <strong>Alteração Realizada com Sucesso</strong> <br>
        </div>
        <div ng-if="cadastroerro">
            <strong>Erro ao tentar Cadastrar!!!!</strong> <br>
        </div>
        <form class="form-group" role="form">
            <table>
                <tr>
                    <td>
                        <label>Nome:</label>
                    </td>
                    <td>
                        <input type="text" required ng-model="pessoa.nome" ng_focus="retiramensagem()" maxlength="100" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Cpf:</label>
                    </td>
                    <td>
                        <input type="text" required ng-model="pessoa.cpf" maxlength="11" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>RG:</label>
                    </td>
                    <td>
                        <input type="text" required ng-model="pessoa.rg" maxlength="14" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Logradouro:</label>
                    </td>
                    <td>
                        <input type="text" ng-model="pessoa.endereco.logradouro" maxlength="40" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Numero:</label>
                    </td>
                    <td>
                        <input type="text" ng-model="pessoa.endereco.numero" maxlength="9" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Bairro:</label>
                    </td>
                    <td>
                        <input type="text" ng-model="pessoa.endereco.bairro" maxlength="30" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Municipio:</label>
                    </td>
                    <td>
                        <input type="text" ng-model="pessoa.endereco.municipio" maxlength="30" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Uf:</label>
                    </td>
                    <td>
                        <input type="text" ng-model="pessoa.endereco.uf" maxlength="2" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Cep:</label>
                    </td>
                    <td>
                        <input type="text" ng-model="pessoa.endereco.cep" maxlength="10" />
                    </td>
                </tr>
            </table><br>
            <div>
                <label>Telefones:</label><br>
            </div>

            <input type="hidden" ng-model="pessoa.id_pessoa" />
            <input type="hidden" ng-model="tel.id_pessoa" />
            <input type="hidden" ng-model="tel.id_telefone" />

            <div>
                <table class="table table-bordered table-striped">
                    <tr>
                        <td>
                            <label>Tipo:</label>

                            <select ng-model="tel.tipo">
                                <option value="Celular" selected="selected">Celular</option>
                                <option value="Residencial">Residencial</option>
                                <option value="Trabalho">Trabalho</option>
                                <option value="Recado">Recado</option>
                            </select>
                        </td>
                        <td>
                            <label>Número: </label>

                            <input type="text" ng-model="tel.numero" maxlength="20" />
                        </td>
                        <td>
                            <div align="right">
                                <a href="#" class="btn btn-primary btn-sm btn-info" ng-click="IncluiTel(tel)"
                                   data-toggle="tooltip" title="Adicionar Telefone"
                                   ng-disabled="!tel.tipo || !tel.numero">Adicionar Telefone</a>
                            </div>
                        </td>
                    </tr>

                    <tr ng-repeat="tell in tels">
                        <td>{{tell.tipo}}</td>
                        <td>{{tell.numero}}</td>
                        <td><div align="right"><button type="button" name="apagar" id="apagartudo" ng-click="ExcluiTel(tell)" class="btn btn-primary btn-sm btn-danger">Excluir</button>  </div>   </td>
                    </tr>
                </table>
                <div>
                    <a href="#" class="btn btn-primary btn-sm btn-success" ng-click="AltPessoa(pessoa,tels)"
                       data-toggle="tooltip" ng-disabled="!pessoa.nome || !pessoa.cpf || !pessoa.rg" title="Altera Pessoa">Alterar</a>

                    <a href="#" class="btn btn-primary btn-sm btn-danger" ng-click="ExcluiPessoa(pessoa)"
                       data-toggle="tooltip" ng-disabled="!pessoa.nome || !pessoa.cpf || !pessoa.rg" title="Exclui Pessoa">Excluir</a>

                </div>
            </div>

        </form>
    </div>
</div>