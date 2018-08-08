
<br><br>
<h1 align="center">Lista de Pessoas</h1>
<div ng-controller="listaCtrl" class="container box">

    <div class="table-responsive">
        <form class="form-group" role="form">

            <input type="hidden" ng-model="pessoa.id_pessoa" />

            <div>
                <div class="form-group" align="right">
                    <label>Busca:</label><input ng-model="search">
                </div>
                <table class="table table-bordered table-striped">

                    <tr>
                        <td>Nome:</td>
                        <td>Cpf:</td>
                        <td>Rg:</td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr ng-repeat="pessoa in pessoas | filter:search">
                        <td>{{pessoa.nome}}</td>
                        <td>{{pessoa.cpf}}</td>
                        <td>{{pessoa.rg}}</td>
                        <td>
                            <div align="right">
                                <button type="button" name="alterar" id="Consultar" ng-click="ConsultaPessoa(pessoa)"
                                        class="btn btn-primary btn-sm btn-info">
                                    Consultar
                                </button>
                            </div>
                        </td>
                        <td>
                            <div align="right">
                                <button type="button" name="exclui" id="Exclui" ng-click="ExcluiPessoa(pessoa)"
                                        class="btn btn-primary btn-sm btn-danger">
                                    Excluir
                                </button>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

        </form>
    </div>
</div>