//Classe de controle do angular
var app = angular.module("minhaApp", [])
  .config(function ($locationProvider) {
      $locationProvider.html5Mode({
          enabled: true,
          requireBase: false
      });
  });

app.controller("MeuCtrl", function ($scope, comentarioRepository) {
    $scope.comentario = {
        Nome: "",
        Email: "",
        Mensagem: "",
        IdPost: "",
        DataComentario: ""
    };

    $scope.comentarios = [];
    $scope.enviarComentario = enviarComentario;

    getComents();

    function getComents() {
        comentarioRepository.get()
                .success(function (data) {
                    var kct = JSON.parse(data);
                    $scope.comentarios = kct;

                });
    }

    function enviarComentario() {
        comentarioRepository.post($scope.comentario)
            .success(function (data) {

                $scope.comentarios.push($scope.comentario);
                zerarComentario();
            });

    }

    function zerarComentario() {
        $scope.comentario = {
            Nome: "",
            Email: "",
            Mensagem: "",
            IdPost: "",
            DataComentario: ""
        };
    }
});



app.factory("comentarioRepository", function ($http, $location) {
    var service = {
        post: post,
        get: get
    };

    var idPost = getPostId();

    return service;

    function get() {

        //Pegar a url atual para poder dar get
        return $http.get("http://localhost:22054/api/comentarios/" + idPost);
    }

    function getPostId() {
        return $location.url().split("/").pop();
    }

    function post(comentario) {
        comentario.IdPost = idPost;
        comentario.DataComentario = new Date();

        //fazer httpPost
        return $http.post("http://localhost:22054/api/comentarios/", comentario);
    }

});