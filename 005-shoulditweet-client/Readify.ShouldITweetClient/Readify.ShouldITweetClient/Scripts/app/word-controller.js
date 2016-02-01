angular.module('TweetApp')
    .controller('wordCtrl', function ($scope, $http) {
      

        $http.get("/api/Word")
              .then(function (response) {
                  $scope.words = response.data;
              });

        $scope.createWord = function()
        {
            var word = { "WordText": $scope.txtWordName,"WordId":0 };
            $http.post("/api/Word", word).then(function (res) {
                window.location.href = "/Home/ManageWords";
            },
            function ()
            {
                alert("An error has occured. Please check with your system administrator.")
            });
        }

        $scope.openEditModal = function (word) {

            $("#modalEdit").modal();
            $scope.wordToEdit = angular.copy(word);
        }

        $scope.editWord = function()
        {
            $http.put("/api/Word/" + $scope.wordToEdit.wordID, $scope.wordToEdit).then(function (res) {
                window.location.href = "/Home/ManageWords";
            },
           function () {
               alert("An error has occured. Please check with your system administrator.")
           });

        }

        $scope.deleteWord = function (id) {
            $http.delete("/api/Word/" + id).then(function (res) {
                window.location.href = "/Home/ManageWords";
            },
            function () {
                alert("An error has occured. Please check with your system administrator.")
            });
        }
    });