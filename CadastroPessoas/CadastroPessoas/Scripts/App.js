//define aplicação angular e o controller
var app = angular.module("pessoasApp", []);

//Controller da página Lista
app.controller("listaCtrl", function ($scope, $http) {
    $http.get('/home/GetPessoas/')
        .success(function (result) {
            $scope.pessoas = result;
        })
        .error(function (data) {
            alert(data);
            console.log(data);
        });
        
    //Consulta Pessoa
    $scope.ConsultaPessoa = function (pessoa) {
        window.location.replace("/home/Consulta/?id=" + pessoa.id_pessoa);        
    }

    //chama o  método ExcluirPessoa do controlador
    $scope.ExcluiPessoa = function (pessoa) {
        if (confirm("Confirma Exclusão?")) {
            $http.post('/home/ExcluirPessoa/', { delPessoa: pessoa })
            .success(function (result) {
                $scope.pessoas = result;
            })
            .error(function (data) {
                console.log(data);
            });
        }
    }
    
});


//Controller da página Consulta
app.controller("consultaCtrl", function ($scope, $http) {
   
    function _getParameter(querystring) {
        var querystr = new Array();
        loc = window.location.search.substr(1).split('&');
        if ((loc != '') && (loc != null)) {
            for (var icnt = 0; icnt < loc.length; icnt++) {
                var q = loc[icnt].split('=');
                querystr[q[0]] = q[1];
            }
            return querystr[querystring];
        }
        else {
            return (null);
        }
    }
    
    var request = { getParameter: _getParameter };
   
    var id = request.getParameter("id")
        
    var e_pessoa = new Object
    e_pessoa.id_pessoa = id;
           
    $http.post('/home/ConsultaPessoa/', { novoPessoa: e_pessoa })
        .success(function (result) {
            $scope.pessoa = result;
        })
        .error(function (data) {
            alert(data);
            console.log(data);
        });
   
    $http.post('/home/ConsultaTelefone/', { novoPessoa: e_pessoa })
       .success(function (result) {           
           $scope.tels = result;
       })
       .error(function (data) {
           alert(data);
           console.log(data);
       });

    
    $scope.tels = [];

    $scope.cadastrosucesso = false;
        
    //Alterar Pessoa
    $scope.AltPessoa = function (pessoa, tels) {        
        if (confirm("Confirma Alteração?")) {
            $http.post('/home/AlteraPessoa/', { novoPessoa: pessoa })
                .success(function (result) {
                    $scope.pessoa = result;
                    $scope.cadastrosucesso = true;
                })
            .error(function (data) {
                $scope.cadastroerro = true;
                // $scope.cadastrosucesso = false;
                console.log(data);
            });
        };
    }

     
    $scope.ExcluiPessoa = function (pessoa) {

        if (confirm("Confirma Exclusão?")) {

            $http.post('/home/ExcluirPessoa/', { delPessoa: pessoa })
            .success(function (result) {
                delete $scope.pessoa;
                delete $scope.tels
                $scope.cadastrosucesso = true;
                
            })
            .error(function (data) {
                $scope.cadastroerro = true
                console.log(data);
            });
        }
    };
    
    $scope.IncluiTel = function (telefone) {
        
        telefone.id_pessoa = $scope.pessoa.id_pessoa;

        $http.post('/home/IncluirTelefone/', { novoTelefone: telefone })
                           .success(function (result) {                              
                               $scope.tels = result
                           })
                    .error(function (data) {      
                        console.log(data);
                        alert(data.description);
                    });
     };

    $scope.ExcluiTel = function (telefone) {

        if (confirm("Confirma Exclusão")) {
           // telefone.id_pessoa = $scope.id_pessoa
            $http.post('/home/ExcluiTelefone/', { novoTelefone: telefone })
            .success(function (result) {
                $scope.tels = result;       
            })
            .error(function (data) {
                console.log(data);
            });
        }
    }

    $scope.retiramensagem = function () {
        try {
            $scope.cadastrosucesso = false;
            $scope.cadastroerro = false;           

        } catch (e) {
            alert(e.description);
        }
    };


});

//Controller da view Pessoas
app.controller("pessoasCtrl", function ($scope, $http) {

    /* IMPORTANTE PARA INICIAR VETOR COM VAZIO< SENÂO NÂO INCLUI DA TABLE */
    $scope.tels = [];

    $scope.cadastrosucesso = false; 
   
    //Adicionar pessoa
    $scope.AddPessoa = function (pessoa, tels) { 
        $http.post('/home/IncluirPessoa/', { novoPessoa: pessoa })
            .success(function (result) {                
                $scope.pessoa = result;
                $scope.cadastrosucesso = true;
                var matriz = tels;
                for (var i = 0; i < matriz.length; i++) {
                   
                    matriz[i].id_pessoa = result.id_pessoa;
                                       
                    $http.post('/home/IncluirTelefone/', { novoTelefone: matriz[i] })
                             .success(function (result) {
                             })
                      .error(function (data) {
                          //$scope.cadastrosucesso = false;
                          $scope.cadastroerro = true;
                          console.log(data);
                          alert(data.description);
                      });

                }                

                delete $scope.pessoa;
                delete $scope.tels;
                
                $scope.tels = [];
                
            })
        .error(function (data) {
            $scope.cadastroerro = true;            
            console.log(data);
        });               
    }    
    
    $scope.addTel = function (tel) {
        try {

            $scope.tels.push(angular.copy(tel));
            delete $scope.tel
        } catch (e) {
            alert(e.description);
        }
    };
    $scope.DeletaTel = function (tell) {
        try {
            var index = $scope.tels.indexOf(tell);
            $scope.tels.splice(index, 1);

        } catch (e) {
            alert(e.description);
        }
    };
        
    $scope.retiramensagem = function () {
        try {
            $scope.cadastrosucesso = false;
            $scope.cadastroerro = false;
        } catch (e) {
            alert(e.description);
        }
    };

});